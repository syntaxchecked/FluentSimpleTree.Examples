namespace SyntaxChecked.FluentSimpleTree.Examples
{
  public enum StorageUnitType { Directory, File }

  public class StorageUnit
  {
    public StorageUnitType Type { get; set; }
    public string Name { get; set; }
    public string? Title { get; set; }
    public uint? Size { get; set; }
    public string? Extension { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Flags { get; set; }

    public StorageUnit(StorageUnitType type,
                      string name,
                      string creationDate,
                      string? flags = null,
                      string? extension = null,
                      uint? size = null,
                      string? title = null)
    {
      Type = type;
      Name = name;
      CreationDate = DateTime.Parse(creationDate);
      Flags = flags;
      Extension = extension;
      Title = title;

      if (type == StorageUnitType.Directory)
        Size = 4096;
      else
        Size = size;
    }
  }
}