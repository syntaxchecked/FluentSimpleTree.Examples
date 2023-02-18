namespace SyntaxChecked.FluentSimpleTree.Examples.NodeSearching
{
  public class Example6
  {
    public static void Run()
    {
      var myTree = new Tree<string>("college");

      var math = myTree.RootNode
                          .AddChildren(new[] { "areas" })[0]
                            .AddChildren(new[] { "Mathematics", "Physics", "Chemistry" })[0]; //Mathematics

      math
        .AddChildren(new[] { "professors", "students" })[0] //professors
          .AddChildren(new[] { "Andrew Dykstra", "James Burton" })[0] //Andrew Dykstra
          .Parent //professors
        .NextSibling //students
          .AddChildren(new[] { "Paul", "Jean" });

      var physics = myTree.RootNode.GetDescendants(item => item == "Physics")[0];

      physics
        .AddChildren(new[] { "professors", "students" })[0] //professors
          .AddChildren(new[] { "Megan M. Smith", "Adam Lark" })[0] //Megan M. Smith
          .Parent //professors
        .NextSibling //students
          .AddChildren(new[] { "James", "Richard" });

      var chemistry = myTree.RootNode.GetDescendants(item => item == "Chemistry")[0];

      chemistry
        .AddChildren(new[] { "professors", "students" })[0] //professors
          .AddChildren(new[] { "Max Majireck", "Michael Welsh" })[0] //
          .Parent //professors
        .NextSibling //students
          .AddChildren(new[] { "Robert", "Monica" });

      var professorsBranches = myTree.RootNode.GetDescendants(item => item == "professors");

      var namesWithPrefixM = professorsBranches
                              .SelectMany(item => item
                                                  .GetChildren(professorName => professorName.StartsWith("M")));

      Console.WriteLine("Listing professors whose name starts with letter M:\n");

      foreach (var node in namesWithPrefixM)
        Console.WriteLine(node.Data);

      var areasBranches = myTree.RootNode.GetDescendants(item => item == "areas");

      var namesWithPrefixJ = areasBranches
                              .SelectMany(item => item
                                                  .GetDescendants(item => item.StartsWith("J")));

      Console.WriteLine("\nListing all people from any area whose name starts with the letter J:\n");

      foreach (var node in namesWithPrefixJ)
        Console.WriteLine(node.Data);
    }
  }
}