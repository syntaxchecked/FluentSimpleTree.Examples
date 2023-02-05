
### 1 - Tree creation
<details>
 <summary>1.1 - Basic example with nodes of strings</summary>
 <br>
 
 ![](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/TreeCreation/basictree1.svg)

 Code:
 ```csharp
      var myTree = new Tree<string>("a");
      var root = myTree.RootNode; //a

      root
        .AddChildren(new[] { "b", "c", "d", "g" })[1] //c
          .AddChildren(new[] { "e", "f" })[0] //e
            .AddChildren(new[] { "h", "i" })[0] //h
            .Parent //e
          .NextSibling //f
            .AddChildren(new[] { "j" })[0] //j
              .AddChildren(new[] { "r", "s", "t" })[2] //t
                .AddChildren(new[] { "z", "k" });
 ```
 Output:

 ![](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/TreeCreation/output1.png)

 [Full code here](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/TreeCreation/Example1.cs).
 <hr>
</details>

<details>
 <summary>1.2 - Example with nodes of some user-defined type</summary>
 <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/Family_tree.svg/1024px-Family_tree.svg.png" width="60%"/>

 Code:
 ```csharp
       var p1 = new Person("Lucas") { Age = 80 };
       var p2 = new Person("Mary") { Age = 60 };
       var p3 = new Person("Jason") { Age = 58 };
       var p4 = new Person("Peter") { Age = 55 };
       var p5 = new Person("Fred") { Age = 35 };
       var p6 = new Person("Jane") { Age = 32 };
       var p7 = new Person("Sean") { Age = 29 };
       var p8 = new Person("Jessica") { Age = 31 };
       var p9 = new Person("Hannah") { Age = 33 };
       var p10 = new Person("Joseph") { Age = 12 };
       var p11 = new Person("John") { Age = 8 };
       var p12 = new Person("Laura") { Age = 3 };

      var myTree = new Tree<Person>(p1);
      var root = myTree.RootNode; //Lucas

      root
        .AddChildren(new Person[] { p2, p3, p4 })[0] //Mary
          .AddChildren(new Person[] { p5, p6 })[0] //Fred
          .Parent //Mary
        .NextSibling //Jason
          .AddChildren(new Person[] { p7, p8, p9 })[1] //Jessica
            .AddChildren(new Person[] { p10, p11, p12 });
 ```
 Output:

 ![](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/TreeCreation/output2.png)

 [Full code here](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/TreeCreation/Example2.cs).
 <hr>
</details>
 
<details>
 <summary>1.3 - Nodes with IDs</summary>
 <img src="src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/TreeCreation/tree_ids.svg" width="75%"/>

 <p></p>
 
 Code:
 ```csharp
       var myTree = new Tree<string>();
       var root = myTree.RootNode;

       root
         .AddChildren(new[] { ("CEO", "John Smith") })[0] //CEO
           .AddChildren(new[] { ("VP_Marketing", "Susan Jones"),
                                ("VP_Sales", "Rachel Parker"),
                                ("VP_Production", "Tom Allen") })[0] //VP Marketing
             .AddChildren(new[] { ("Manager1", "Alice Johnson") })[0] //Manager1
             .Parent //VP Marketing
           .NextSibling //VP Sales
             .AddChildren(new[] { ("Manager2", "Michael Gross") })[0] //Manager2
             .Parent //VP Sales
           .NextSibling //VP Production
             .AddChildren(new[] { ("Manager3", "Kathy Roberts") }); //Manager3
 ```
 Output:

 ![](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/TreeCreation/output3.png)

 [Full code here](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/TreeCreation/Example3.cs).
 <hr>
</details>

### 2 - Getting nodes
<details>
 <summary>2.1 - By ID</summary> 
 <img src="src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/NodeSearching/node_searching.svg" width="75%"/>
 
 <p></p>
 
 Code:
 ```csharp
      var myTree = new Tree<string>("a");
      var root = myTree.RootNode; //a

      root
        .AddChildren(new[] { ("CEO", "John Smith") })[0] //CEO
          .AddChildren(new[] { ("VP_Marketing", "Susan Jones"),
                               ("VP_Sales", "Rachel Parker"),
                               ("VP_Production", "Tom Allen") })[0] //VP Marketing
            .AddChildren(new[] { ("Manager1", "Alice Johnson") })[0] //Manager1
            .Parent //VP Marketing
          .NextSibling //VP Sales
            .AddChildren(new[] { ("Manager2", "Michael Gross") })[0] //Manager2
            .Parent //VP Sales
          .NextSibling //VP Production
            .AddChildren(new[] { ("Manager3", "Kathy Roberts") }); //Manager3

      //You can search the whole tree
      var vp_sales = myTree.GetNodeById("VP_Sales");

      //Or from a specific node
      var manager3 = root.GetDescendant("Manager3");
 ```
 Output:
 
 ![](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/NodeSearching/output1.png)
 
 [Full code here](src/SyntaxChecked.FluentSimpleTree.Examples/SyntaxChecked.FluentSimpleTree.Examples/NodeSearching/Example4.cs).
 <hr>
</details> 

<details>
 <summary>2.2 - By predicate</summary>
<hr> 
</details> 

### 3 - Deleting nodes
<details>
 <summary>3.1 -By ID</summary>
<hr> 
</details> 

<details>
 <summary>3.2 -By predicate</summary>
<hr> 
</details> 

### 4 - Appending nodes
Basic example of how to append a node to another one
  
### 5- Simulating DOM (Document Object Model)
