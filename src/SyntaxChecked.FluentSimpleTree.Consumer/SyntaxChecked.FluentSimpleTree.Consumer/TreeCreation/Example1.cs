
namespace SyntaxChecked.FluentSimpleTree.Consumer.TreeCreation
{
  public static class Example1
  {
    public static void Run()
    {
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

      OutputHelper.ToConsole(myTree);
    }
  }
}