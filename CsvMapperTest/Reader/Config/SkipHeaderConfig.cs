using CsvMapper.Reader.Config;

namespace CsvMapperTest.Reader.Config {
	internal class SkipHeaderConfig : DefaultReaderConfig {

		public override bool SkipHeader => true;

		public override int HeaderRow => 5;

	}
}
