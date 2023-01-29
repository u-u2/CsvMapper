# CsvMapper

csv reading, writing and mapping to class

https://www.nuget.org/packages/CsvMapperNet

## Read

```c#
    var csv = "example.csv";
    using (var reader = new CsvReader(new StreamReader(csv))){
        foreach(var field in reader.ReadFields()){
        }
    }
```

```c#
    var csv = "example.csv";
    using (var reader = new CsvReader(new StreamReader(csv))){
        foreach(var record in reader.ReadTable()){
            for(let i = 0; i < record.length; i++){
                var field = record[i];
            }
        }
    }
```

## Write

```c#
    var csv = "example.csv";
    var foo = new List<Foo>();
    foo.Add(foo1);
    foo.Add(foo2);
    using (var writer = new CsvWriter(new StreamWriter(csv))) {
        writer.WriteRecords(foo);
    }
```

## Map

```c#
    var csv = "example.csv";
    using (var reader = new CsvReader(new StreamReader(csv))){
        foreach(var record in reader.ReadRecords<Foo>()){
        }
    }
```
