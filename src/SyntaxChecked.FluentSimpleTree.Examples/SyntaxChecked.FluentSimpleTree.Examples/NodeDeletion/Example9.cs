namespace SyntaxChecked.FluentSimpleTree.Examples.NodeDeletion
{
  public static class Example9
  {
    public static void Run()
    {
      var myTree = new Tree<string>();
      var root = myTree.RootNode;

      root
        .AddChildren(new[] { "Lucas" })[0] //Lucas
          .AddChildren(new[] { "Mary", "Jason", "Peter" })[0] //Mary
            .AddChildren(new[] { "Fred", "Jane" })[0] //Fred
            .Parent //Mary
          .NextSibling //Jason
            .AddChildren(new[] { "Sean", "Jessica", "Hannah" })[1] //Jessica
              .AddChildren(new[] { "Joseph", "John", "Jennifer" });

      Console.WriteLine("Tree before node deletion:\n");
      OutputHelper.ToConsole(myTree);

      root.RemoveDescendants(item => item == "Jane" || item.StartsWith("Je"));

      Console.WriteLine();
      Console.WriteLine("Tree after node deletion:\n");
      OutputHelper.ToConsole(myTree);
    }
  }
}