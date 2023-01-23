using System.Collections.Generic;

namespace CsvMapperNet.Writer {
	internal interface IWriter {

		/// <summary>
		/// Write Fields to csv file
		/// </summary>
		void WriteFields(IEnumerable<string> fields);

		/// <summary>
		/// Write Header to csv file
		/// </summary>
		void WriteHeader<T>(T t);

		/// <summary>
		/// Write Record to csv file
		/// </summary>
		void WriteRecord<T>(T t);

		/// <summary>
		/// Write Records to csv file
		/// </summary>
		void WriteRecords<T>(IEnumerable<T> records);

	}
}
