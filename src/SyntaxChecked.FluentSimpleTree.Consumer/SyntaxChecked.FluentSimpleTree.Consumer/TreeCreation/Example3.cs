namespace SyntaxChecked.FluentSimpleTree.Consumer.TreeCreation
{
  public static class Example3
  {
    public static void Run()
    {
      var myTree = new Tree<string>();
      var root = myTree.RootNode;

      root
        .AddChildren(new[] { ("CEO", "John Smith") })[0] //CEO
          .AddChildren(new[] { ("VP Marketing", "Susan Jones"), ("VP Sales", "Rachel Parker"), ("VP Production", "Tom Allen") })[0] //VP Marketing
            .AddChildren(new[] { ("Manager1", "Alice Johnson") })[0] //Manager1
            .Parent //VP Marketing
          .NextSibling //VP Sales
            .AddChildren(new[] { ("Manager2", "Michael Gross") })[0] //Manager2
            .Parent //VP Sales
          .NextSibling //VP Production
            .AddChildren(new[] { ("Manager3", "Kathy Roberts") }); //Manager3

      OutputHelper.ToConsole(myTree);
    }
  }
}