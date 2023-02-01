namespace SyntaxChecked.FluentSimpleTree.Consumer.TreeCreation
{
  public static class Example2
  {
    public static void Run()
    {
      var p1 = new Person("Lucas") { Age = 80 };
      var p2 = new Person("Mary") { Age = 60 };
      var p3 = new Person("Jason") { Age = 58 };
      var p4 = new Person("Peter") { Age = 55 };
      var p5 = new Person("Fred") { Age = 35 };
      var p6 = new Person("Jane") { Age = 32 };
      var p7 = new Person("Sean") { Age = 29 };
      var p8 = new Person("Jessica") { Age = 31 };
      var p9 = new Person("Hannah") { Age = 33 };
      var p10 = new Person("Joseph") { Age = 12 };
      var p11 = new Person("John") { Age = 8 };
      var p12 = new Person("Laura") { Age = 3 };

      var myTree = new Tree<Person>(p1);
      var root = myTree.RootNode; //Lucas

      root
        .AddChildren(new Person[] { p2, p3, p4 })[0] //Mary
          .AddChildren(new Person[] { p5, p6 })[0] //Fred
          .Parent //Mary
        .NextSibling //Jason
          .AddChildren(new Person[] { p7, p8, p9 })[1] //Jessica
            .AddChildren(new Person[] { p10, p11, p12 });

      OutputHelper.ToConsole(myTree);
    }
  }
}
