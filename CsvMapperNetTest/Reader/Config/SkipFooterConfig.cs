using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvMapperNet.Reader.Config;

namespace CsvMapperTest.Reader.Config {
	internal class SkipFooterConfig : DefaultReaderConfig {

		public override bool SkipFooter => true;

		public override int FooterRowCount => 2;

	}
}
