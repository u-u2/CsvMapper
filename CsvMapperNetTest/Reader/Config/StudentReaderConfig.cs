using CsvMapperNet.Reader.Config;

namespace CsvMapperTest.Reader.Config {
	internal class StudentReaderConfig : DefaultReaderConfig {

		public override int HeaderRow => 5;

	}
}
