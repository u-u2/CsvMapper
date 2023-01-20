using System.Collections.Generic;

namespace CsvMapper.Writer {
	internal interface IWriter {

		void WriteFields(IEnumerable<string> fields);

		void WriteHeader<T>(T t);

		void WriteRecord<T>(T t);

		void WriteRecords<T>(IEnumerable<T> records);

	}
}
