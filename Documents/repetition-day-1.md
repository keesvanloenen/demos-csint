# Repetition day 1 20260413

1. What is the correct way to declare a nullable value type?

   a. `int x = null;`  
   b. `int? x = null;`  
   c. `nullable<int> x = null;`  
   d. `var x = int.null;`

1. What will this print?

   ```cs
   int? x = null;
   Console.WriteLine(x.HasValue);
   ```

   a. true  
   b. false  
   c. null  
   d. Exception is thrown

1. What does this mean in C# ?

   ```cs
   string? name;
   ```

   a. The variable is always null  
   b. The variable can contain null  
   c. The variable is immutable  
   d. The variable is a value type

1. What happens here (with nullable enabled)?

   ```cs
   string name = null;
   ```

   a. Compile error  
   b. Runtime error  
   c. Warning  
   d. No issue

1. What does `!` do in this context?

   ```cs
   string? name = GetName();
   Console.WriteLine(name!.Length);
   ```

   a. Throws exception if null  
   b. Converts to non-nullable at runtime  
   c. Suppresses compiler null warning  
   d. Initializes value

1. Why would you use this?

   ```cs
   public string Name { get; set; } = null!;
   ```

   a. Forces runtime null check  
   b. Prevents null assignment  
   c. Suppresses compiler warning for uninitialized non-nullable property  
   d. Makes property nullable

1. What is the output?

   ```cs
   string? input = null;
   Console.WriteLine(input ?? "default");
   ```

   a. exception is thrown  
   b. default  
   c. ""  
   d. warning

1. What does this do?

   ```cs
   string? name = null;
   name ??= "Mo";
   ```

   a. Always assigns "Mo"  
   b. Assigns only if null  
   c. Throws exception if null  
   d. Does nothing

1. What will this output?

   ```cs
   string? s = null;
   Console.WriteLine(s?.Length ?? -1);
   ```

   a. 0  
   b. -1  
   c. null  
   d. Exception

1. What is the default underlying type of an enum?

   a. byte  
   b. short  
   c. int  
   d. long

1. Given

   ```cs
   enum Status { Active = 1, Inactive = 2 }
   ```

   What is `(int)Status.Active`?

   a. 0  
   b. 1  
   c. "Active"  
   d. Exception

1. What is the purpose of `[Flags]`?

   a. Allows multiple enum values combined with bitwise operations  
   b. Makes enum faster  
   c. Makes enum nullable  
   d. Enables reflection

1. Given

   ```cs
   [Flags]
   enum Permission { Read = 1, Write = 2, Execute = 4 }

   var p = Permission.Read | Permission.Write;
   ```

   What is p?

   a. 3  
   b. ReadWrite  
   c. Read, Write  
   d. Both a and c

1. hat does this mean?

   ```cs
   public int Age { get; }
   ```

   a. Read/write property  
   b. Read-only property  
   c. Write-only property  
   d. Static property

1. When should you prefer a struct?

   a. Large mutable objects  
   b. Small, immutable data types  
   c. For inheritance  
   d. Objects with a unique identifier

1. Which of the following statements best explains why _all members of a struct_ in C# must have a value before the struct is used?

   a. Because structs are stored on the heap and require explicit memory allocation  
   b. Because structs are value types and must be fully initialized to avoid undefined data  
   c. Because structs automatically assign null to uninitialized members  
   d. Because structs cannot contain fields without default values  

1. What is the output?

   ```cs
   var t = (Name: "Eileen", Age: 30);
   Console.WriteLine(t.Name);
   ```

   a. Eileen  
   b. 30  
   c. (Eileen, 30)  
   d. Exception

1. What does this do?

   ```cs
   var (name, age) = ("Eileen", 30);
   ```

   a. Creates object  
   b. Splits tuple into variables  
   c. Converts types  
   d. Serializes data

1. What is a key feature of records?

   a. Mutable state  
   b. Reference equality  
   c. Value-based equality  
   d. Cannot have methods

1. Classify the following:

   ```cs
   struct A {}
   class B {}
   record C(int X);
   record struct D(int X);
   ```

   Which is correct?

   a. A = value, B = reference, C = reference, D = value  
   b. All are reference types  
   c. A & D = reference  
   d. Only B is reference

1. What does this allow?

   ```cs
   public int this[int index] { get; set; }
   ```

   a. Method overloading  
   b. Access object like an array  
   c. LINQ queries  
   d. Reflection

1. What is happening?

   ```cs
   var obj = new MyCollection();
   obj[0] = 10;
   ```

   What is happening?

   a. Method call  
   b. Field access  
   c. Indexer invocation  
   d. Array initialization
