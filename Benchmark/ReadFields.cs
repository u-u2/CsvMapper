﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using CsvMapperNet.Reader;
using Microsoft.VisualBasic.FileIO;

namespace Benchmark {
	public class ReadFields {

		private readonly string _csv = @"csv\organizations-100000.csv";

		[Benchmark]
		public void CsvReader() {
			using (var reader = new CsvReader(new StreamReader(_csv))) {
				foreach (var fields in reader.ReadFields()) {
				}
			}
		}

		[Benchmark]
		public void StreamReader() {
			using (var reader = new StreamReader(_csv)) {
				string line;
				while ((line = reader.ReadLine()) != null) {
					line.Split(',');
				}
			}
		}

		[Benchmark]
		public void TextFieldParser() {
			using (var parser = new TextFieldParser(_csv)) {
				parser.SetDelimiters(",");
				while (!parser.EndOfData) {
					parser.ReadFields();
				}
			}
		}


	}
}
