using CsvMapperNet.Attributes;

namespace CsvMapperTest.Entity {
	internal class StudentSmall {

		[Column(0, Name = "Id")]
		public long Id { get; set; }

		[Column(1, Name = "Name")]
		public string Name { get; set; }

		public override string ToString() {
			return $"{Id},{Name}";
		}

	}
}
