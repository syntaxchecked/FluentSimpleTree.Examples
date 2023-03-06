using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntaxChecked.FluentSimpleTree.Examples.NodeDeletion
{
  public static class Example8
  {
    public static void Run()
    {
      var myTree = new Tree<string>();
      var root = myTree.RootNode;

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

      Console.WriteLine("Tree before node deletion:\n");
      OutputHelper.ToConsole(myTree);

      root.RemoveDescendant("VP_Sales");
      root.RemoveDescendant("Manager1");

      Console.WriteLine();
      Console.WriteLine("Tree after node deletion:\n");
      OutputHelper.ToConsole(myTree);
    }
  }
}