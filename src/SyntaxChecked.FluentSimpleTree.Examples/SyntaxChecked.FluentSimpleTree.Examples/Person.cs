namespace SyntaxChecked.FluentSimpleTree.Examples
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