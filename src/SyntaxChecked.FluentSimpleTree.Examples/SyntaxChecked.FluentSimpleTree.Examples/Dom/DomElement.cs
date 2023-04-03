namespace SyntaxChecked.FluentSimpleTree.Examples.Dom
{
  public class DomElement
  {
    public string Tag { get; set; }
    public bool EmptyTag { get; set; } = false;
    public string? Text { get; set; }
    public CssStyle Style { get; set; } = new CssStyle();

    private readonly Dictionary<string, string?> _attributes = new();

    public DomElement(string tag, (string name, string value)[]? attributes = null, string? text = null, bool emptyTag = false)
    {
      Tag = tag;
      Text = text;
      EmptyTag = emptyTag;

      if (attributes != null)
        Array.ForEach(attributes, (attribute) => { _attributes.Add(attribute.name, attribute.value); });
    }

    public DomElement(string tag, string text) : this(tag, null, text) { }

    public DomElement(string tag, bool emptyTag) : this(tag, null, null, emptyTag) { }

    public string? GetAttribute(string name)
    {
      if (_attributes.ContainsKey(name))
        return _attributes[name];
      else
        return null;
    }

    public void SetAttribute(string name, string value)
    {
      if (_attributes.ContainsKey(name))
        _attributes[name] = value;
      else
        _attributes.Add(name, value);
    }

    public Dictionary<string, string?> GetAllAttributes() => _attributes;
  }
}