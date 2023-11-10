# TimelineSort

+ Sample
```Csharp
List<List<object>> a = new List<List<object>>
{
    new List<object>{ "A", "B", "C", "D", "E", "H" },
    new List<object>{ "A", "C", "D", "E", "F", "B", "H"},
    new List<object>{ "A", "D", "E", "H", "G"}
};

var ts = new TimelineSort(a);
var pattern = ts.Pattern;  // A B C D E F B H G
var list1 = ts.Get(a[0]);  // A B C D E     H
var list2 = ts.Get(a[1]);  // A   C D E F B H
var list3 = ts.Get(a[2]);  // A     D E     H G
```
