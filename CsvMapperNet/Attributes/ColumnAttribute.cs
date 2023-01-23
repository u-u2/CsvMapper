using System;

namespace CsvMapperNet.Attributes {
	[AttributeUsage(AttributeTargets.Property,
		AllowMultiple = false,
		Inherited = false)]
	public class ColumnAttribute : Attribute {

		public int Index { get; }

		public string Name { get; set; }

		public ColumnAttribute(int index) {
			Index = index;
		}

	}
}
