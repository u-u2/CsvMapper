using CsvMapperNet.Reader.Config;

namespace CsvMapperTest.Reader.Config {
	internal class DisableValidateFieldLengthConfig : DefaultReaderConfig {

		public override bool ValidateFieldLength => false;

	}
}
