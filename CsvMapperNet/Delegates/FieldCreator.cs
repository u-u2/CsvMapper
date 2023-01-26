using System;
using System.Linq;
using System.Reflection;
using CsvMapperNet.Attributes;

namespace CsvMapperNet.Delegates {
	public class FieldCreator {

		public FieldCreator() {

		}

		public Func<T, string[]> CreateHeaderCreator<T>() {
			return t => typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Where(p => p.GetCustomAttribute<ColumnAttribute>(false) != null)
			.Select(p => p.GetCustomAttribute<ColumnAttribute>(false).Name)
			.ToArray();
		}

		public Func<T, string[]> CreateRecordCreator<T>() {
			return t => typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Where(p => p.GetCustomAttribute<ColumnAttribute>(false) != null)
			.Select(p => p.GetValue(t))
			.Select(o => o != null ? o.ToString() : string.Empty)
			.ToArray();
		}
	}
}
