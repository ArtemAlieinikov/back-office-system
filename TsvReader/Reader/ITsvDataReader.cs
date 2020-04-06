using System.Collections.Generic;

namespace TsvReader.Reader
{
	/// <summary>
	/// Contract of Tsv data reader
	/// </summary>
	/// <typeparam name="T">Type of mapped objects</typeparam>
	public interface ITsvDataReader<T> where T : ITsvConvertable, new()
	{
		/// <summary>
		/// Checks whether tsv file exists or not
		/// </summary>
		/// <returns></returns>
		bool IsDataExist();

		/// <summary>
		/// Reads tsv file
		/// </summary>
		/// <returns>Collection of objects pupulated with data from tsv file</returns>
		IEnumerable<T> ReadData();
	}
}
