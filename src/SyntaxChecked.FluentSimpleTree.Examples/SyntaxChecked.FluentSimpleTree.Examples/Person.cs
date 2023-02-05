namespace SyntaxChecked.FluentSimpleTree.Consumer.TreeCreation
{
  public class Person
  {
    public string Name { get; set; }
    public int? Age { get; set; }

    public Person(string name)
    {
      Name = name;
    }
  }
}