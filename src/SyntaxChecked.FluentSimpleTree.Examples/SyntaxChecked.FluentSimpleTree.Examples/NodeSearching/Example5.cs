namespace SyntaxChecked.FluentSimpleTree.Examples.NodeSearching
{
  public static class Example5
  {
    public static void Run()
    {
      var myTree = new Tree<int>(34);
      var root = myTree.RootNode;

      root
        .AddChildren(new[] { 21, 13 })[0] //21
          .AddChildren(new[] { 13, 8 })[0] //13
            .AddChildren(new[] { 8, 5 })[0] //8
              .AddChildren(new[] { 5, 3 })[0] //5
                .AddChildren(new[] { 3, 2 })[0] //3
                  .AddChildren(new[] { 2, 1 })[0] //2
                    .AddChildren(new[] { 1, 1 });

      var oddElements = myTree
                          .GetNodes(data => data % 2 != 0)
                          .Select(node => node.Data);

      var EvenElements = myTree
                          .GetNodes(data => data % 2 == 0)
                          .Select(node => node.Data);

      foreach (var number in oddElements)
        Console.Write(number + " ");

      Console.WriteLine();

      foreach (var number in EvenElements)
        Console.Write(number + " ");
    }
  }
}