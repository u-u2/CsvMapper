using System;
using System.Linq;
using System.Reflection;
using CsvMapperNet.Attributes;

namespace CsvMapperNet.Mapper {
	internal class ObjectCreator {

		private readonly bool _validateFieldLength;

		public ObjectCreator(bool validateFieldLengh) {
			_validateFieldLength = validateFieldLengh;
		}

		public Func<string[], T> Create<T>() where T : new() {
			var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.GetCustomAttribute<ColumnAttribute>(false) != null)
				.ToArray();
			return s => {
				if (_validateFieldLength && s.Length != properties.Length) {
					throw new NotSupportedException();
				}
				var obj = new T();
				foreach (var property in properties) {
					var columnAttribute = property.GetCustomAttribute<ColumnAttribute>(false);
					var value = Convert.ChangeType(s[columnAttribute.Index], property.PropertyType);
					property.SetValue(obj, value);
				}
				return obj;
			};
		}

	}
}
