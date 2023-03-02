using SyntaxChecked.FluentSimpleTree.Examples.TreeCreation;

namespace SyntaxChecked.FluentSimpleTree.Examples
{
  public static class OutputHelper
  {
    public static void ToConsole<T>(Tree<T> tree)
    {
      var rootNode = tree.RootNode;
      dynamic nodes = new IGenericTreeNode<T>[] { rootNode };

      ToConsoleDefault(nodes);
    }

    public static void ToConsole(IGenericTreeNode<StorageUnit>[] nodes)
    {
      string titleInfo, sizeInfo, extensionInfo, flagsInfo;

      foreach (var node in nodes)
      {
        titleInfo = node.Data.Title == null ? "" : $"Title: {node.Data.Title}\n";
        sizeInfo = node.Data.Size == null ? "" : $"Size: {node.Data.Size} bytes\n";
        extensionInfo = node.Data.Extension == null ? "" : $"Extension: {node.Data.Extension}\n";
        flagsInfo = node.Data.Flags == null ? "" : $"Flags: {node.Data.Flags}\n";

        var path = "";
        var currentNode = node;

        while (!currentNode.IsRootNode)
        {
          path = path.Insert(0, "/" + currentNode.Data.Name);
          currentNode = currentNode.Parent;
        }

        var msg = $"Name : {node.Data.Name}\n" +
                    $"Path: {path}\n" +
                    $"{sizeInfo}" +
                    $"{extensionInfo}" +
                    $"{titleInfo}" +
                    $"{flagsInfo}" +
                    $"Creation date/time: {node.Data.CreationDate}\n";

        Console.WriteLine(msg);
      }
    }

    private static void ToConsoleDefault<T>(IGenericTreeNode<T>[] nodes)
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
          ToConsoleDefault(children);
      }
    }
  }
}