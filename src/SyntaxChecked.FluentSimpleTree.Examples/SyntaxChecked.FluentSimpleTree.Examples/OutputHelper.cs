using SyntaxChecked.FluentSimpleTree.Examples.Dom;

namespace SyntaxChecked.FluentSimpleTree.Examples
{
  public static class OutputHelper
  {
    public static void ToHtmlFile(Tree<DomElement> domTree)
    {
      using var htmlFile = File.CreateText("output.html");

      ToHtmlFile(new IGenericTreeNode<DomElement>[] { domTree.RootNode }, htmlFile);
    }

    public static void ToHtmlFile(IGenericTreeNode<DomElement>[] elements, StreamWriter htmlFile)
    {
      foreach (var element in elements)
      {
        var spaces = new string(' ', element.Level * 2);

        htmlFile.Write(spaces + "<" + element.Data.Tag);

        foreach (var attribute in element.Data.GetAllAttributes())
          htmlFile.Write($" {attribute.Key}=\"{attribute.Value}\"");

        var style = "";

        if (element.Data.Style.BackgroundColor != null)
          style = $"background-color:{element.Data.Style.BackgroundColor};";

        if (element.Data.Style.Color != null)
          style += $"color:{element.Data.Style.Color};";

        if (element.Data.Style.Padding != null)
          style += $"padding:{element.Data.Style.Padding};";

        if (element.Data.Style.TextAlign != null)
          style += $"text-align:{element.Data.Style.TextAlign};";

        if (element.Data.Style.Width != null)
          style += $"width:{element.Data.Style.TextAlign};";

        if (style != "")
          style = $" style=\"{style}\"";

        htmlFile.WriteLine($"{style}>");

        if (element.Data.Text != null)
          htmlFile.WriteLine($"{spaces}  {element.Data.Text}");

        var children = element.GetAllChildren();

        if (children.Any())
          ToHtmlFile(children, htmlFile);

        if (!element.Data.EmptyTag)
          htmlFile.WriteLine(spaces + "</" + element.Data.Tag + ">");
      }
    }

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