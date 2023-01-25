using System.IO;
using System.Linq;
using CsvMapperTests.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvMapperNet.Writer.Tests {
	[TestClass()]
	public class CsvWriterTests {

		[TestMethod()]
		public void CreateTestCsv() {
			int recordCount = 5;
			var students = Enumerable.Range(1, recordCount)
				.Select(i => new StudentLarge {
					Id = i,
					Name = "Bob",
					Age = 84,
					Post = "This, is a, test",
				}
				);
			var fileName = $"students_{recordCount}.csv";
			using (var writer = new CsvWriter(new StreamWriter(fileName))) {
				writer.WriteRecords(students);
			}
			var lines = File.ReadAllLines(fileName);
			for (int i = 0; i < lines.Length; i++) {
				var expect = $"{i + 1},Bob,84,\"This, is a, test\"";
				Assert.AreEqual(expect, lines[i]);
			}
			Assert.AreEqual(recordCount, lines.Length);
		}

		[TestMethod()]
		public void WriteHeaderTest() {
			var student = new StudentLarge();
			var fileName = "student_header.csv";
			using (var writer = new CsvWriter(new StreamWriter(fileName))) {
				writer.WriteHeader(student);
			}
			var actual = File.ReadAllLines(fileName);
			var expect = "Id,Name,Age,Post";
			Assert.IsTrue(actual.Length == 1);
			Assert.AreEqual(expect, actual[0]);
		}

	}
}
