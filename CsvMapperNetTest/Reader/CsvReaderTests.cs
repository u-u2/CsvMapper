using System;
using System.IO;
using System.Linq;
using CsvMapperTest.Entity;
using CsvMapperTest.Reader.Config;
using CsvMapperTests.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvMapperNet.Reader.Tests {
	[TestClass()]
	public class CsvReaderTests {

		private static readonly int s_recordCount = 3;
		private static readonly int s_fieldsWidth = 4;
		private static readonly string s_records = string.Format(
			"{0}\n{1}\n{2}",
			"Id,\"Name\",Age,\"Post\"",
			"1,\"Bob\",84,\"This, is a, test\"",
			"2,\"Bob\",84,\"This, is a, test\"");

		[TestMethod()]
		public void ReadFieldsTest() {
			using (var reader = new CsvReader(new StringReader(s_records))) {
				var fields = reader.ReadFields().ToArray();
				for (int i = 0; i < fields.Length; i++) {
					Assert.AreEqual(s_fieldsWidth, fields[i].Length);
					Assert.AreEqual((i + 1).ToString(), fields[i][0]);
					Assert.AreEqual("\"Bob\"", fields[i][1]);
					Assert.AreEqual("84", fields[i][2]);
					Assert.AreEqual("\"This, is a, test\"", fields[i][3]);
				}
				// skipped header
				Assert.AreEqual(s_recordCount - 1, fields.Length);
			}
		}

		[TestMethod()]
		public void ReadCustomFieldTest() {
			var config = new DisableValidateFieldLengthConfig();
			using (var reader = new CsvReader(new StringReader(s_records), config)) {
				var records = reader.ReadRecords<StudentSmall>().ToArray();
				for (int i = 0; i < records.Length; i++) {
					var expect = $"{i + 1},\"Bob\"";
					Assert.AreEqual(expect, records[i].ToString());
				}
			}
		}

		[TestMethod()]
		public void SkipHeaderTest() {
			// set HeaderRow to 2
			var skipRow = 2;
			var config = new SkipHeaderConfig();
			using (var reader = new CsvReader(new StringReader(s_records), config)) {
				var records = reader.ReadRecords<StudentLarge>().ToArray();
				for (int i = 0; i < records.Length; i++) {
					var expect = $"{i + 1 + skipRow},\"Bob\",84,\"This, is a, test\"";
					Assert.AreEqual(expect, records[i].ToString());
				}
			}
		}

		[TestMethod()]
		public void ThrowException_NotMatchColumCounts() {
			var e = Assert.ThrowsException<NotSupportedException>(() => {
				// enables ValidateFieldLength by default.
				using (var reader = new CsvReader(new StringReader(s_records))) {
					foreach (var student in reader.ReadRecords<StudentSmall>()) {
					}
				}
			});
			Console.WriteLine(e);
		}
	}
}