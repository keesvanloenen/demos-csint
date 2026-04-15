# Repetition day 2 20260414

1. What is a correct collection initializer in C#?

   a.

   ```cs
   var names = new List<string>()
   {
       "Alice",
       "Bob",
       "Charlie"
   };
   ```

   b.

   ```cs
   var names = new List<string>
   (
       "Alice",
       "Bob",
       "Charlie"
   );
   ```

   c.

   ```cs
   var names = new List<string>
   {
       = "Alice",
       = "Bob",
       = "Charlie"
   };
   ```

   d.

   ```cs
   var names = new ()
   (
       "Alice",
       "Bob",
       "Charlie"
   );
   ```

1. What is required for a collection to support collection initializer syntax?

   a. It must inherit from `Array` and implement `IEnumerable`  
   b. It must implement `IEnumerable` and have an `Add` method  
   c. It must be a `List<T>` and have an `Add` method  
   d. It must be static and use `yield return`  

1. What is a collection expression (C# 12)?

   a. Syntax to declare interfaces with static methods  
   b. Syntax using `[]` to create collections  
   c. Syntax using `{}` when creating an object, eg. `User user = new User { Name = "An" };`  
   d. A loop construct with `yield return`

1. What can an interface define? Choose all that apply. Also add a name to each of your choices

   a. `string Name`  
   b. `string Name { get; }`  
   c. `void DoWork`  
   d. `event EventHandler SomethingHappened`  
   e. `int this[int index] { get; set; }`

1. What is `IEnumerable` used for?

   a. store collections in memory and guarantees fast random access to elements by index  
   b. Representing a sequence that can be iterated over  
   c. Modify collections dynamically while iterating over them  
   d. Creating threads

1. What is substitution (Liskov Substitution Principle)?

   a.

   ```cs
   void Feed(Dog dog) { }

   Feed(new Animal());
   ```

   b.

   ```cs
   void Feed(Animal animal) { }

   Feed(new Dog());
   ```

   c.

   ```cs
   void Feed(Animal animal) { }

   Feed((Animal)new object());
   ```

   d.

   ```cs
   void Feed(Dog dog) { }

   Feed(new Dog());
   ```

1. What are default implementations in interfaces?

   a. Interfaces cannot have implementations (since C# 1)  
   b. Only abstract classes support implementations (since C# 1)  
   c. They are deprecated (since C# 12)  
   d. Interfaces can provide method bodies (since C# 8)

1. What does `yield return` do?

   a. Returns all values at once  
   b. Ends a method immediately  
   c. Returns values one at a time in an iterator  
   d. Throws an exception

1. Assume we've got this interface:

   ```cs
   interface IAnimal
   {
      void Speak();
   }
   ```

   What is explicit interface implementation?

   a.

   ```cs
   class Dog : IAnimal
   {
       public void Speak() { }
   }
   ```

   b.

   ```cs
   class Dog : IAnimal
   {
       void IAnimal.Speak() { }
   }
   ```

   c.

   ```cs
   class Dog : IAnimal
   {
       private void Speak() { }
   }
   ```

   d.

   ```cs
   class Dog
   {
       public void Speak() { }
   }
   ```

1. When do you use explicit interface implementation? Choose all that apply.

   a. When methods must be static  
   b. When you want to hide interface members from the class API  
   c. When using structs only  
   d. When 2 interfaces provide a method with the same name

1. Given this code:

   ```cs
   record Person { public int Age; public string Name; }
   object p = new Person { Age = 20, Name = "Alice" };
   ```

   Which example correctly uses pattern matching to check two properties of an object?

   a.

   ```cs
   if (obj is Person { Age: > 18, Name: "Alice" })
      Console.WriteLine("Match");
   ```

   b.

   ```cs
   if (obj is Person && obj.Age > 18 && obj.Name == "Alice")
      Console.WriteLine("Match");
   ```

   c.

   ```cs
   if (obj is Person(Age > 18, Name is "Alice"))
      Console.WriteLine("Match");
   ```

   d.

   ```cs
   if (obj == Person { Age: > 18, Name: "Alice" })
      Console.WriteLine("Match");
   ```

1. What does the `params` keyword allow?

   a. Passing parameters of different types in a single argument list  
   b. Passing a variable number of arguments  
   c. Makes method parameters optional so they can be omitted when calling the method  
   d. Passing arguments by reference automatically without using `ref` or `out`

1. What are explicit conversions?

   a. Automatic conversions  
   b. Conversions that require a cast  
   c. Only for interfaces  
   d. Only for structs

1. What does overloading the `+` operator in a struct like `Point` allow?

   a. Concatenating strings  
   c. Allow implicit conversion  
   b. Allow explicit conversion  
   d. Adding two Point objects using +
