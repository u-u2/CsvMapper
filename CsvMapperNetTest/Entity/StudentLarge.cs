using CsvMapperNet.Attributes;

namespace CsvMapperTests.Entity {
	internal class StudentLarge {

		[Column(0, Name = "Id")]
		public long Id { get; set; }

		[Column(1, Name = "Name")]
		public string Name { get; set; }

		[Column(2, Name = "Age")]
		public int Age { get; set; }

		[Column(3, Name = "AttendanceRate")]
		public double AttendanceRate { get; set; }

		public override string ToString() {
			return string.Format(
				"{0},{1},{2},{3}",
				Id,
				Name,
				Age,
				AttendanceRate);
		}

	}
}
