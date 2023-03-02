namespace SyntaxChecked.FluentSimpleTree.Examples.NodeSearching
{
  public static class Example7
  {
    public static void Run()
    {
      var creationDate = "02/15/2020";
      var InitialDirsNames = new string[] { "/", "bin", "etc", "lib", "init.d", "udev", "rules.d" };
      var InitialDirs = new List<StorageUnit>();

      foreach (var name in InitialDirsNames)
        InitialDirs.Add(new StorageUnit(StorageUnitType.Directory, name, creationDate, "s")); //s = sys

      var executableFilesNames = new string[] { "bash", "cat", "ssh", "cron" };
      var executableFiles = new List<StorageUnit>();

      foreach (var name in executableFilesNames)
        executableFiles.Add(new StorageUnit(StorageUnitType.File, name, creationDate, "x")); //x = executable

      executableFiles[0].Size = 1273694; //bash
      executableFiles[1].Size = 44032; //cat
      executableFiles[2].Size = 4096; //ssh
      executableFiles[3].Size = 3072; //cron

      var directoriesLevel1 = new StorageUnit[4];

      Array.Copy(InitialDirs.ToArray(), 1, directoriesLevel1, 0, 3);

      directoriesLevel1[3] = new StorageUnit(StorageUnitType.Directory, "home", creationDate, "s");

      var deviceConfigFilesNames = new string[] { "dm", "crda" };

      var deviceConfigFiles = new List<StorageUnit>();

      foreach (var name in deviceConfigFilesNames)
        deviceConfigFiles.Add(new StorageUnit(StorageUnitType.File, name, creationDate, "d", "rules")); //devices configs

      deviceConfigFiles[0].Size = 7168;
      deviceConfigFiles[1].Size = 69;

      var myDirectory = new StorageUnit(StorageUnitType.Directory,
                                        "myself",
                                        DateTime.Today.ToString("MM/dd/yyyy"),
                                        "u");

      var pdfDocument = new StorageUnit(StorageUnitType.File,
                                        "algebra",
                                        DateTime.Today.ToString("MM/dd/yyyy"),
                                        "u",
                                        "pdf",
                                        1024000,
                                        "Introduction to Algebra");

      var DirTree = new Tree<StorageUnit>(InitialDirs[0]);

      DirTree
        .RootNode
          .AddChildren(directoriesLevel1)[0] //bin
            .AddChildren(new[] { executableFiles[0], executableFiles[1] })[0] //bash
            .Parent //bin
          .NextSibling //etc
            .AddChildren(new[] { InitialDirs[4] })[0] //init.d
              .AddChildren(new[] { executableFiles[2], executableFiles[3] })[0] //ssh
              .Parent //init.d
              .Parent //etc
            .NextSibling //lib
              .AddChildren(new[] { InitialDirs[5] })[0] //udev
                .AddChildren(new[] { InitialDirs[6] })[0] //rules.d
                  .AddChildren(deviceConfigFiles.ToArray());

      var homeDir = DirTree.RootNode.GetChildren(item => item.Name == "home")[0];

      homeDir
        .AddChildren(new[] { myDirectory })[0]
          .AddChildren(new[] { pdfDocument });

      var sysDirs = DirTree.GetNodes(item => item.Name != "/" &&
                                      item.Type == StorageUnitType.Directory &&
                                      item.Flags == "s");

      var shBinaries = DirTree.GetNodes(item => item.Name.EndsWith("sh") &&
                                        item.Type == StorageUnitType.File &&
                                        item.Flags == "x");

      var utilBinaries = DirTree.GetNodes(item => item.Type == StorageUnitType.File &&
                                          item.Flags == "x" &&
                                          (item.Name == "cat" || item.Name == "cron"));

      var configRulesFiles = DirTree.GetNodes(item => item.Type == StorageUnitType.File &&
                                          item.Flags == "d" &&
                                          item.Extension?.Contains("rules") == true);

      var userDirs = DirTree.GetNodes(item => item.Type == StorageUnitType.Directory &&
                                          item.Flags == "u");

      var userDocAlgebra = DirTree.GetNodes(item => item.Type == StorageUnitType.File &&
                                          item.Flags == "u" &&
                                          item.Extension?.Contains("pdf") == true &&
                                          item.Title?.Contains("Algebra") == true);

      Console.WriteLine("Listing all system directories in the tree:\n");
      OutputHelper.ToConsole(sysDirs);

      Console.WriteLine("Listing shells binaries in the tree:\n");
      OutputHelper.ToConsole(shBinaries);

      Console.WriteLine("Listing other executable files in the tree:\n");
      OutputHelper.ToConsole(utilBinaries);

      Console.WriteLine("Listing device rules files in the tree:\n");
      OutputHelper.ToConsole(configRulesFiles);

      Console.WriteLine("Listing user directories in the tree:\n");
      OutputHelper.ToConsole(userDirs);

      Console.WriteLine("Listing specific user document in the tree:\n");
      OutputHelper.ToConsole(userDocAlgebra);
    }
  }
}