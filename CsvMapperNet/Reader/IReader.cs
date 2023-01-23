using System.Collections.Generic;

namespace CsvMapperNet.Reader {
	internal interface IReader {

		IEnumerable<string[]> ReadFields();

		IEnumerable<T> ReadRecords<T>() where T : new();

	}
}
