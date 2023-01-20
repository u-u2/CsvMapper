using System.Collections.Generic;

namespace CsvMapper.Reader {
	internal interface IReader {

		IEnumerable<string[]> ReadFields();

		IEnumerable<T> ReadRecords<T>() where T : new();

	}
}
