using CsvMapperNet.Reader.Config;

namespace CsvMapperTest.Reader.Config {
	internal class SkipHeaderConfig : DefaultReaderConfig {

		public override bool SkipHeader => true;

		public override int HeaderRow => 2;

		public override bool ValidateFieldLength => false;

	}
}
