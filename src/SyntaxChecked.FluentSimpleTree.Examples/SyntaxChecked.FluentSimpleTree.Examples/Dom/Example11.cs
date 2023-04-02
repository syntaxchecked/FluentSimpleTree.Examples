namespace SyntaxChecked.FluentSimpleTree.Examples.Dom
{
  public class Example11
  {
    public static void Run()
    {
      //Building DOM Tree

      var document = new Tree<DomElement>(new DomElement("html", new[] { ("lang", "en") }));
      var htmlElement = document.RootNode;

      htmlElement
        .AddChildren(new[] { new DomElement("head") })[0]
          .AddChildren(new[] {
            new DomElement("meta", new[] {("charset", "utf-8")}),
            new DomElement("title", "HTML Example Page"),
            new DomElement("style",
                            ".intro-green {" +
                            "  background-color:green" +
                            "}"),
            new DomElement("script", new[] { ("src", "script.js") })
          });

      htmlElement
        .AddChildren(new[] { new DomElement("body") })[0]
          .AddChildren(new[] { new DomElement("header") })[0]
            .AddChildren(new[] {
              new DomElement("h1", new[] {("class","intro-green")}, "HTML5 Example Page")
            });

      var bodyElement = htmlElement.GetChildren(elem => elem.Tag == "body")[0]; //js: document.body

      bodyElement
        .AddChildren(new[] { new DomElement("p") })[0]
          .AddChildren(new[] { ("welcome-msg", new DomElement("span", "Welcome message")) });

      bodyElement
        .AddChildren(new[] { ("main-nav", new DomElement("nav")) })[0]
          .AddChildren(new[] { new DomElement("ul") });

      var navUlElement = bodyElement
                          .GetDescendants(elem => elem.Tag == "ul")[0];

      for (var i = 1; i <= 3; i++)
      {
        navUlElement
          .AddChildren(new[] { new DomElement("li") });
      };

      var navUlInnerLinks = new[] {
            new DomElement("a", new[]{("href", "#")}, "Home"),
            new DomElement("a", new[]{("href", "about.html")}, "About"),
            new DomElement("a", new[]{("href", "contact.html")}, "Contact"),
      };

      for (uint i = 0; i <= navUlInnerLinks.Length - 1; i++)
      {
        navUlElement
          .GetChild(i)
            .AddChildren(new[] { navUlInnerLinks[i] });
      }

      //Manipulating elements

      //js: document.getElementById("main-nav").textContent
      document.GetNodeById("main-nav").Data.Text = "Navigation Links";

      var firstParagraph = document.GetNodes(elem => elem.Tag == "p")[0]; //js: document.querySelector("p")
      var allParagraphs = document.GetNodes(elem => elem.Tag == "p"); //js: document.querySelectorAll("p")

      //js: document.getElementsByClassName("intro-green")[0]
      var header1 = document.GetNodes(elem => elem.Attributes?["class"] == "intro-green")[0];

      //Adding new CSS class

      htmlElement
        .GetDescendants(elem => elem.Tag == "style")[0] //js: document.documentElement.getElementsByTagName("style")[0]
          .Data
            .Text += "\n.intro-blue {" +
                      "  background-color:blue" +
                      "}";

      header1.Data.Attributes["class"] = "intro-blue"; //js: header1.classList.toggle("intro-blue")

      //Changing the style of an element

      var welcomeText = document.GetNodeById("welcome-msg");

      welcomeText.Data.Style.BackgroundColor = "yellow";
      welcomeText.Data.Style.Color = "blue";

      //Gerar Output após manipular os elementos


    }
  }
}