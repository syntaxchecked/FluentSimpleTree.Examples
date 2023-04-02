namespace SyntaxChecked.FluentSimpleTree.Examples.Dom
{
  public class DomElement
  {
    public string Tag { get; set; }
    public bool EmptyTag { get; set; } = false;
    public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
    public string? Text { get; set; }
    public CssStyle Style { get; set; } = new CssStyle();

    public DomElement(string tag, (string name, string value)[]? attributes = null, string? text = null, bool emptyTag = false)
    {
      Tag = tag;
      Text = text;
      EmptyTag = emptyTag;

      if (attributes != null)
        Array.ForEach(attributes, (attribute) => { Attributes.Add(attribute.name, attribute.value); });
    }

    public DomElement(string tag, string text) : this(tag, null, text) { }

    public DomElement(string tag, bool emptyTag) : this(tag, null, null, emptyTag) { }
  }
}