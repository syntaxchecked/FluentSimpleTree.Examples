namespace SyntaxChecked.FluentSimpleTree.Consumer.NodeSearching
{
  public static class Example4
  {
    public static void Run()
    {
      var myTree = new Tree<string>("a");
      var root = myTree.RootNode; //a

      root
        .AddChildren(new[] { ("CEO", "John Smith") })[0] //CEO
          .AddChildren(new[] { ("VP_Marketing", "Susan Jones"), ("VP_Sales", "Rachel Parker"), ("VP_Production", "Tom Allen") })[0] //VP Marketing
            .AddChildren(new[] { ("Manager1", "Alice Johnson") })[0] //Manager1
            .Parent //VP Marketing
          .NextSibling //VP Sales
            .AddChildren(new[] { ("Manager2", "Michael Gross") })[0] //Manager2
            .Parent //VP Sales
          .NextSibling //VP Production
            .AddChildren(new[] { ("Manager3", "Kathy Roberts") }); //Manager3

      //You can search the whole tree
      var vp_sales = myTree.GetNodeById("VP_Sales");

      Console.WriteLine($"Id: {vp_sales.Id}, {vp_sales.Data}");

      //Or from a specific node
      var manager3 = root.GetDescendant("Manager3");

      if (manager3 != null)
        Console.WriteLine($"Id: {manager3.Id}, {manager3.Data}");
    }
  }
}