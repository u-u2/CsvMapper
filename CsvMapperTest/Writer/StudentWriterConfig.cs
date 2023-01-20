using CsvMapper.Writer.Config;

namespace CsvMapperTest2.Writer {
	internal class StudentWriterConfig : IWriterConfig {
		public string Delimiter => "\t";

		public string NewLine => "\n";
	}
}
