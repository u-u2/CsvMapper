using CsvMapper.Writer.Config;

namespace CsvMapperTest.Writer.Config {
	internal class StudentWriterConfig : DefaultWriterConfig {

		public override string NewLine => "\n";

	}
}
