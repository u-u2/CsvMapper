using System;
using System.IO;
using System.Linq;
using CsvMapperTest2.Entity;
using CsvMapperTest2.Reader;
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
				var fields = reader.ReadFields().ToArray();
				var expect = 10;
				Assert.AreEqual(expect, fields.Length);
			}
		}

		[TestMethod()]
		public void ReadAllFieldTest() {
			using (var reader = new CsvReader(new StreamReader(s_fileName))) {
				// ReadAllField by default.
				foreach (var student in reader.ReadRecords<StudentLarge>()) {
					Console.WriteLine(student);
				}
			}
		}

		[TestMethod()]
		public void ReadCustomFieldTest() {
			// Disabled ReadAllField in StudentReaderConfig
			using (var reader = new CsvReader(new StreamReader(s_fileName), new StudentReaderConfig())) {
				foreach (var student in reader.ReadRecords<StudentSmall>()) {
					Console.WriteLine(student);
				}
			}
		}

		[TestMethod]
		public void SkipHeaderTest() {
			// set HeaderRow to 5 in StudentReaderConfig
			using (var reader = new CsvReader(new StreamReader(s_fileName), new StudentReaderConfig())) {
				foreach (var student in reader.ReadRecords<StudentSmall>()) {
					Console.WriteLine(student);
				}
			}
		}

		[TestMethod]
		public void HeaderIgnoreTest() {
			// Disabled ReadHeader in StudentReaderConfig
			using (var reader = new CsvReader(new StreamReader(s_fileName), new StudentReaderConfig())) {
				foreach (var student in reader.ReadRecords<StudentSmall>()) {
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