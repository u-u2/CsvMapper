using System;
using System.IO;
using CsvMapperTest.Entity;
using CsvMapperTest.Reader.Config;
using CsvMapperTests.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvMapper.Reader.Tests {
	[TestClass()]
	public class CsvReaderTests {

		// this file created by CsvWriterTests
		private static readonly string s_fileName = "students_10.csv";

		[TestMethod()]
		public void ReadFieldsTest() {
			using (var reader = new CsvReader(new StreamReader(s_fileName))) {
				foreach (var fields in reader.ReadFields()) {
					foreach (var field in fields) {
						Console.WriteLine(field);
					}
				}
			}
		}

		[TestMethod()]
		public void ReadCustomFieldTest() {
			// Disabled ReadAllField
			var config = new DisableReadAllFieldConfig();
			using (var reader = new CsvReader(new StreamReader(s_fileName), config)) {
				foreach (var student in reader.ReadRecords<StudentSmall>()) {
					Console.WriteLine(student);
				}
			}
		}

		[TestMethod]
		public void SkipHeaderTest() {
			// set HeaderRow to 5
			var config = new SkipHeaderConfig();
			using (var reader = new CsvReader(new StreamReader(s_fileName), config)) {
				foreach (var student in reader.ReadRecords<StudentLarge>()) {
					Console.WriteLine(student);
				}
			}
		}

		[TestMethod()]
		public void ThrowException_NotMatchColumCounts() {
			var e = Assert.ThrowsException<NotSupportedException>(() => {
				// ReadAllField by default.
				using (var reader = new CsvReader(new StreamReader(s_fileName))) {
					foreach (var student in reader.ReadRecords<StudentSmall>()) {
						Console.WriteLine(student);
					}
				}
			});
			Console.WriteLine(e);
		}
	}
}