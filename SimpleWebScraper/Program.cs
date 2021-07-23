//Fields
//Properties
//keep fields private, we want to keep fields private so other classes cant change the data, we protect fields
//they are implicitly private, but its prolly good to be explict

//we expose data out through properties, properties provide a layer of abstraction in relation to the fields

//a constructor is a special type of method within a class, no return type, same name as a class
//the constructor runs during the instantiation of the class 

//OOP, objects are the building blocks of OOP
//OOP helps to make devopment easier, it has evolved
//OOP comes with very powerful features, encapsulation, inheritance, polymorphism, abstraction

//objects provide the ablility to expose functionallity, but hide the implmentation
//abstaction is the ablility to expose functionality but hide the implementation

//When we do this we are making it easier for other developers to use our code
//developers only need to see what is returned, and the process that will be done 
//for them, they have expectation, 
//when they use a certain method that method will hide its implementation, yet it will return something
//this makes it easier for developers to work together, 
//larger teams can be form and have a bigger impact on the world

//inheriting from a class means that you get access to their methods and properities
//we get to reuse alot of code through inheritance

//encapsulation prevents access to implementaion details, aka allows us to do information hiding
//phone example, as a user we know that if we click the button the phone will turn on
//the implementation has been hiden from us, yet the functionality has exposed out to us as a user
//encapsulation is acheived by access specifier, public private internal 

//abstraction and encapsulation same concept//
//encapsulation happens on a class level, controlls what a class exposes and what a class hides
//abstraction happens at a higher degree
//abstraction uses encapsulation
//encapsulation allows the developer to implement the desired level of abstraction

//one button on all phones in the world for on/off, the type of phone is being abstracted away
//all the different types of phones have the same interface, that is abstraction 
//through encapslation you hide the implmentation details

//access specifies
//classes are internal by default
//public
//private
//internal - only available within the project, other classes have access
//protected - only avilable within the base class AND the class thats inheriting it

//the using statement allows us to IMPORT! IMPORT! the class

//[assembly: InternalsVisibleTo("NewProject")] - use this to edit the AssemblyInfo.cs file, 
//allows other projects to see the internals

//the using statement is used to import namespaces, you are importing a namespace
//using keyword taking in an object that encapsulates resources
//the objects resources are availble with in the block and THEN gets disposed of properly
//this keeps us from have to dispose of the resources our self

//building pattern is one designed pattern, a standard, a general repeated soulution to a common problem
//properties can get out of control for objects, think of a person, making creating objects difficult 
//builder pattern allows us to build complex objects out of simple ones
//complex objects can have alot of properties - create builder
//DRY!

//Single responsiblity principle - seperate your concerns
//keep your code function sperated, easier to reuse

//Regex
//dotnet framework provides a regular expression engine
////regex
//MatchCollection matches = Regex.Matches("This is my cat", "This is my [a-z]at");

//  foreach (var match in matches)
//  {
//      Console.WriteLine(match);
//  }

//keeping up with all these properties is riduclus, what if we start growing properties, DRY!
//  Person person1 = new Person("John", "Smith", 30, 42, 5555);
//  Person person2 = new Person("John", "Smith", 30, 52, 5555);
//  Person person3= new Person("John", "Smith", 30, 62, 5555);

//  Person person4 = new PersonBuilder().Build();
//  Person person5 = new PersonBuilder().WithAge(35).Build();
//  Person person6 = new PersonBuilder().WithFirstName("Jay").Build();



//using statement
//WebClient is a resourse that we want to dispose of properlly

//using (WebClient client = new WebClient())
//{
//    string googleMainPage = client.DownloadString("http://www.google.com");
//    Console.WriteLine(googleMainPage);
//}

using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper
{
    class Program
    {
        

        private const string Method = "search";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter which city you would like to scrape information from:");
                var craigslistCity = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Please enter the craigs list catagory that you would like to scrape:");
                var craigslistCatagoryName = Console.ReadLine() ?? string.Empty;

                using (WebClient webClient = new WebClient())
                {
                    string content = webClient.DownloadString($"http://{craigslistCity.Replace(" ", string.Empty)}.craigslist.org/{Method}/{craigslistCatagoryName}");

                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                        .WithData(content)
                        .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                        .WithRegexOptions(RegexOptions.ExplicitCapture)
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@">(.*?)</a>")
                            .WithRegexOption(RegexOptions.Singleline)
                            .Build())
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@"href=\""(.*?)\""")
                            .WithRegexOption(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Scraper scraper = new Scraper();

                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements) Console.WriteLine(scrapedElement);
                    }
                    else
                    {
                        
                        Console.WriteLine("There were no matches for the specified scrape criteria.");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }
    }
}



        

    

