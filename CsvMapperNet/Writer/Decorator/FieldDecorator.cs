using System.Linq;

namespace CsvMapperNet.Writer.Decorator {
	internal class FieldDecorator {

		private readonly char _delimiter;

		public FieldDecorator(char delimiter) {
			_delimiter = delimiter;
		}

		public string Decorate(string field) {
			if (field.Contains(_delimiter)) {
				return $"\"{field}\"";
			}
			return field;
		}

	}
}
