using System;
using System.IO;
using System.Linq;
using CsvMapperTest.Entity;
using CsvMapperTest.Reader.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvMapperNet.Reader.Tests {
	[TestClass()]
	public class CsvReaderTests {

		// this file created by CsvWriterTests
		private static readonly string s_fileName = "students_5.csv";

		[TestMethod()]
		public void ReadFieldsTest() {
			using (var reader = new CsvReader(new StreamReader(s_fileName))) {
				var fields = reader.ReadFields().ToArray();
				for (int i = 0; i < fields.Length; i++) {
					Assert.AreEqual(4, fields[i].Length);
					Assert.AreEqual((i + 1).ToString(), fields[i][0]);
					Assert.AreEqual("Bob", fields[i][1]);
					Assert.AreEqual("84", fields[i][2]);
					Assert.AreEqual("\"This, is a, test\"", fields[i][3]);
				}
				Assert.AreEqual(5, fields.Length);
			}
		}

		[TestMethod()]
		public void ReadCustomFieldTest() {
			var config = new DisableValidateFieldLengthConfig();
			using (var reader = new CsvReader(new StreamReader(s_fileName), config)) {
				var records = reader.ReadRecords<StudentSmall>().ToArray();
				for (int i = 0; i < records.Length; i++) {
					var expect = $"{i + 1},Bob";
					Assert.AreEqual(expect, records[i].ToString());
				}
			}
		}

		[TestMethod]
		public void SkipHeaderTest() {
			// set HeaderRow to 2
			var skipRow = 2;
			var config = new SkipHeaderConfig();
			using (var reader = new CsvReader(new StreamReader(s_fileName), config)) {
				var records = reader.ReadRecords<StudentSmall>().ToArray();
				for (int i = 0; i < records.Length; i++) {
					var expect = $"{i + 1 + skipRow},Bob";
					Assert.AreEqual(expect, records[i].ToString());
				}
			}
		}

		[TestMethod()]
		public void ThrowException_NotMatchColumCounts() {
			var e = Assert.ThrowsException<NotSupportedException>(() => {
				// enables ValidateFieldLength by default.
				using (var reader = new CsvReader(new StreamReader(s_fileName))) {
					foreach (var student in reader.ReadRecords<StudentSmall>()) {
					}
				}
			});
			Console.WriteLine(e);
		}
	}
}