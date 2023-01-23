using System.IO;
using System.Linq;
using CsvMapperTest.Writer.Config;
using CsvMapperTests.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvMapperNet.Writer.Tests {
	[TestClass()]
	public class CsvWriterTests {

		[TestMethod()]
		public void CreateTestCsv() {
			int recordCount = 10;
			var startIndex = 1;
			var students = Enumerable.Range(startIndex, recordCount)
				.Select(i => {
					if (i % 2 == 0) {
						return new StudentLarge();
					}
					return new StudentLarge {
						Id = i,
						Name = "Bob",
						Age = 84,
						AttendanceRate = 0.5,
					};
				});
			var fileName = $"students_{recordCount}.csv";
			using (var writer = new CsvWriter(new StreamWriter(fileName))) {
				writer.WriteRecords(students);
			}
		}

		[TestMethod()]
		public void WriteHeaderTest() {
			var student = new StudentLarge();
			var fileName = "student_header.csv";
			using (var writer = new CsvWriter(new StreamWriter(fileName))) {
				writer.WriteHeader(student);
			}
			var actual = File.ReadAllLines(fileName);
			var expect = "Id,Name,Age,AttendanceRate";
			Assert.IsTrue(actual.Length == 1);
			Assert.AreEqual(expect, actual[0]);
		}

		[TestMethod()]
		public void WriteRecordsTest() {
			int recordCount = 10;
			var startIndex = 1;
			var students = Enumerable.Range(startIndex, recordCount)
				.Select(i => new StudentLarge {
					Id = i,
					Name = "Bob",
					Age = 84,
					AttendanceRate = 0.5,
				});
			var fileName = $"students_{recordCount}.csv";
			using (var writer = new CsvWriter(new StreamWriter(fileName), new StudentWriterConfig())) {
				writer.WriteRecords(students);
			}
			var actual = File.ReadAllLines(fileName);
			var expect = Enumerable.Range(startIndex, recordCount)
				.Select(i => $"{i},Bob,84,0.5")
				.ToArray();
			Assert.IsTrue(actual.Length == recordCount);
			CollectionAssert.AreEqual(expect, actual);
		}

	}
}
