using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvMapperNet.Reader.Config;

namespace CsvMapperTest.Reader.Config {
	internal class BufferConfig : DefaultReaderConfig {

		public override int BufferSize => 3;

	}
}
