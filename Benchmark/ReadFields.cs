using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using CsvMapperNet.Reader;
using Microsoft.VisualBasic.FileIO;

namespace Benchmark {

	[MemoryDiagnoser]
	[ShortRunJob]
	[MaxColumn, MinColumn]
	public class ReadFields {

		private readonly string _csv;

		public ReadFields() {
			var header = "column1,column2,column3,column4,column5,column6\n";
			var recordCount = 100000;
			var builder = new StringBuilder(header);
			for (int i = 0; i < recordCount; i++) {
				builder.Append("A,B,C,D,E,F").Append('\n');
			}
			_csv = builder.ToString();
		}

		[Benchmark]
		public void CsvReader_ReadTable() {
			using (var reader = new CsvReader(new StringReader(_csv))) {
				foreach (var fields in reader.ReadTable()) {
					foreach (var field in fields) {
					}
				}
			}
		}

		[Benchmark]
		public void TextFieldParser() {
			using (var parser = new TextFieldParser(new StringReader(_csv))) {
				parser.SetDelimiters(",");
				while (!parser.EndOfData) {
					foreach (var field in parser.ReadFields()) {
					}
				}
			}
		}

		[Benchmark]
		public void StreamReader() {
			using (var reader = new StringReader(_csv)) {
				string line;
				while ((line = reader.ReadLine()) != null) {
					line.Split(',');
				}
			}
		}

	}
}
