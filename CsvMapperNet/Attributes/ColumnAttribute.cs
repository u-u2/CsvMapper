using System;

namespace CsvMapperNet.Attributes {
	[AttributeUsage(AttributeTargets.Property,
		AllowMultiple = false,
		Inherited = false)]
	public class ColumnAttribute : Attribute {

		/// <summary>
		/// start at 0
		/// </summary>
		public int Index { get; }

		/// <summary>
		/// Name of Column
		/// </summary>
		public string Name { get; set; }

		public ColumnAttribute(int index) {
			Index = index;
		}

	}
}
