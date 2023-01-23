using CsvMapper.Reader.Config;

namespace CsvMapperTest.Reader.Config {
	internal class StudentReaderConfig : DefaultReaderConfig {

		public override bool ReadAllField => false;
		public override int HeaderRow => 5;

	}
}
