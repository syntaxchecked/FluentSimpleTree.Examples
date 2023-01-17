
## Usage
* ### Tree creation
  * [Basic example with nodes of strings](#basic-tree-creation)
  * [Example with nodes of some user-defined type](#example-with-nodes-of-some-user-defined-type) 
  * [Tree of nodes having ID]
  
* [Searching nodes]
* [Deleting nodes]
* [Appending nodes]

## Basic tree creation

![](src/SyntaxChecked.FluentSimpleTree.Consumer/SyntaxChecked.FluentSimpleTree.Consumer/TreeCreation/basictree1.svg)

```csharp
      var myTree = new Tree<string>("a");

      var root = myTree.RootNode;

      root
        .AddChildren(new[] { "b", "c", "d", "g" })[1] //c
          .AddChildren(new[] { "e", "f" })[0] //e
            .AddChildren(new[] { "h", "i" })[0] //h
          .Parent //e
          .Parent //c
          .GetChild(1) //f
            .AddChildren(new[] { "j" })[0] //j
              .AddChildren(new[] { "r", "s", "t" })[2] //t
                .AddChildren(new[] { "z", "k" });
```
Output from the object myTree:

![](src/SyntaxChecked.FluentSimpleTree.Consumer/SyntaxChecked.FluentSimpleTree.Consumer/TreeCreation/output1.png)

[Full code here](src/SyntaxChecked.FluentSimpleTree.Consumer/SyntaxChecked.FluentSimpleTree.Consumer/TreeCreation/Example1.cs).

## Example with nodes of some user-defined type
![](https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/Family_tree.svg/1024px-Family_tree.svg.png)
