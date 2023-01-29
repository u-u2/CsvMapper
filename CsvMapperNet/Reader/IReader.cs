using System.Collections.Generic;

namespace CsvMapperNet.Reader {
	internal interface IReader {

		/// <summary>
		/// read csv as 2d array.
		/// </summary>
		/// <returns><see cref="IEnumerable{T}" /> of type <see cref="string[]"/></returns>
		IEnumerable<string[]> ReadTable();

		/// <summary>
		/// read fields of each line.
		/// </summary>
		/// <returns><see cref="string"/> field</returns>
		IEnumerable<string> ReadFields();

		/// <summary>
		/// read all fields in csv file.
		/// </summary>
		/// <returns><see cref="IEnumerable{T}"/> records </returns>
		IEnumerable<T> ReadRecords<T>() where T : new();

	}
}
