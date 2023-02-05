using SyntaxChecked.FluentSimpleTree.Consumer.TreeCreation;

namespace SyntaxChecked.FluentSimpleTree.Consumer
{
  public static class OutputHelper
  {
    public static void ToConsole<T>(Tree<T> tree)
    {
      var rootNode = tree.RootNode;

      ToConsole(new IGenericTreeNode<T>[] { rootNode });
    }

    private static void ToConsole<T>(IGenericTreeNode<T>[] nodes)
    {
      foreach (var node in nodes)
      {
        var spaces = new string(' ', node.Level * 2);

        if (node.IsRootNode && node.Data is null)
          Console.WriteLine($"Id: root, Data: null");

        if (node.Data is string)
        {
          if (!node.IsRootNode && node.Id != null)
            Console.WriteLine($"{spaces}Id: {node.Id}, Data: {node.Data}");
          else
            Console.WriteLine(spaces + node.Data);
        }

        if (node.Data is Person)
          Console.WriteLine($"{spaces}Name: {(node.Data as Person)!.Name}, Age: {(node.Data as Person)!.Age}");

        var children = node.GetAllChildren();

        if (children.Any())
          ToConsole(children);
      }
    }
  }
}