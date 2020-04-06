using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TsvReader.Reader
{
	/// <summary>
	/// Implementatin of tsv reader
	/// </summary>
	/// <typeparam name="T">Type of mapped objects</typeparam>
	public class TsvReader<T> : ITsvDataReader<T> where T : ITsvConvertable, new()
	{
		private const char TrimChar = '"';
		private readonly char[] Delimeter = new char[] { '\t' };

		private string filePath;

		/// <summary>
		/// Creates class
		/// </summary>
		/// <param name="filePath">Absolute path to the tsv file</param>
		public TsvReader(string filePath)
		{
			this.filePath = filePath;
		}

		/// <summary>
		/// Checks whether tsv file exists or not
		/// </summary>
		/// <returns></returns>
		public bool IsDataExist() => File.Exists(filePath);

		/// <summary>
		/// Reads tsv file
		/// </summary>
		/// <returns>Collection of objects pupulated with data from tsv file</returns>
		public IEnumerable<T> ReadData()
		{
			List<T> records = new List<T>();

			if (IsDataExist())
			{
				try
				{
					var tsvAssociations = GetColumnPropertyAssosiation();
					StreamReader streamReader = new StreamReader(filePath);
					var columnHeaders = streamReader.ReadLine().Split(Delimeter).Select(x => x.Trim(TrimChar)).ToList();

					while (streamReader.Peek() > 0)
					{
						var values = streamReader.ReadLine().Split(Delimeter).Select(x => x.Trim(TrimChar)).ToList();

						if (values.Count != columnHeaders.Count)
						{
							continue;
						}

						var record = new T();
						for (var i = 0; i < columnHeaders.Count(); ++i)
						{
							var tsvAssosiation = tsvAssociations.First(x => x.tsvColumnName == columnHeaders[i]);
							var propertyInfo = record.GetType().GetProperty(tsvAssosiation.entityPropertyName);

							var propValue = ConverPropertyValue(propertyInfo, values[i]);

							propertyInfo.SetValue(record, propValue);
						}

						records.Add(record);
					}
				}
				catch (Exception ex)
				{
					return records;
				}
			}

			return records;
		}

		private object ConverPropertyValue(PropertyInfo propertyInfo, string valueToConvert)
		{
			TypeConverter typeConverter = TypeDescriptor.GetConverter(propertyInfo.PropertyType);
			object propValue = typeConverter.ConvertFromString(valueToConvert);

			return propValue;
		}

		private List<(string tsvColumnName, string entityPropertyName)> GetColumnPropertyAssosiation()
		{
			var result = new List<(string tsvColumnName, string entityPropertyName)>();
			var properties = typeof(T).GetProperties();
			foreach (var property in properties)
			{
				if (property.GetCustomAttribute(typeof(TsvColumnNameAttribute)) is TsvColumnNameAttribute attribute)
				{
					result.Add((attribute.tsvColumnName, property.Name));
				}
			}

			return result;
		}
	}
}
