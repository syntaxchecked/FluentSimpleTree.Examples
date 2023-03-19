namespace SyntaxChecked.FluentSimpleTree.Examples.NodeAppending
{
  public class Example10
  {
    public static void Run()
    {
      var tree1 = new Tree<string>("a");
      var t1_root = tree1.RootNode;

      t1_root
        .AddChildren(new[] { "b", "c", "d" })[1] //c
          .AddChildren(new[] { "e", "f" })[0] //e
            .AddChildren(new[] { "h", "i" });

      Console.WriteLine("Tree 1 before node removal:\n");
      OutputHelper.ToConsole(tree1);

      var removedNodes = t1_root.RemoveDescendants(node => node == "e");

      Console.WriteLine();
      Console.WriteLine("Tree 1 after node removal:\n");
      OutputHelper.ToConsole(tree1);

      var tree2 = new Tree<string>("j");
      var t2_root = tree2.RootNode;

      t2_root
        .AddChildren(new[] { "k", "l" })[0] //k
          .AddChildren(new[] { "m", "n" })[0] //m
          .Parent //k
        .NextSibling //l
          .AddChildren(new[] { "o" });

      var node_l = t2_root.GetDescendants(node => node == "l")[0];

      Console.WriteLine();
      Console.WriteLine("Tree 2 before appending the nodes that were removed from tree 1:\n");
      OutputHelper.ToConsole(tree2);

      node_l.AppendNodes(removedNodes);

      Console.WriteLine();
      Console.WriteLine("Tree 2 after node appending:\n");
      OutputHelper.ToConsole(tree2);
    }
  }
}