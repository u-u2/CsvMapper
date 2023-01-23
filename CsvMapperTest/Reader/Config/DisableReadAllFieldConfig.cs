using CsvMapper.Reader.Config;

namespace CsvMapperTest.Reader.Config {
	public class DisableReadAllFieldConfig : DefaultReaderConfig {

		public override bool ReadAllField => false;

	}
}
