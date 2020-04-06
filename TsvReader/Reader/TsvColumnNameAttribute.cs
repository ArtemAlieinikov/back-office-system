using System;

namespace TsvReader.Reader
{
	/// <summary>
	/// Allows to set up associated tsv column name
	/// </summary>
	public class TsvColumnNameAttribute : Attribute
	{
		/// <summary>
		/// Tsv column name
		/// </summary>
		public string tsvColumnName;

		/// <summary>
		/// Creates class
		/// </summary>
		/// <param name="tsvColumnName">Associated tsv column name</param>
		public TsvColumnNameAttribute(string tsvColumnName)
		{
			this.tsvColumnName = tsvColumnName;
		}
	}
}
