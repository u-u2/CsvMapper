using System.Collections.Generic;

namespace CsvMapperNet.Reader {
	internal interface IReader {

		/// <summary>
		/// Get all fields in csv file
		/// </summary>
		/// <returns><see cref="IEnumerable{T}" /> of type <see cref="string[]"/> records</returns>
		IEnumerable<string[]> ReadTable();

		IEnumerable<string> ReadFields();

		/// <summary>
		/// Get all fields in csv file
		/// </summary>
		/// <returns><see cref="IEnumerable{T}"/> records </returns>
		IEnumerable<T> ReadRecords<T>() where T : new();

	}
}
