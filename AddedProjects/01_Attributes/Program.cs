using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Attributes
{
    // Here we learn about attributes how to use it and how to make a special attributes 
    // we but the attribue above the declaration of the element between square brackets
    // the attribute take the arguments the same as the methods 
    // by convention , all attribute names end with Attribute word.

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            //Update[] updates = {new Update("Security Update",1),
            //                    new Update("Graphics Card Update",2),
            //                    new Update("Bugs Fix Update",3) };
            //UpdateProcessor.Download(updates);
            //UpdateProcessor.Install(updates);
            //UpdateProcessor.DownloadAndInstall(updates);
            List<Player> players = new List<Player>
            {
                new Player {Name ="Mohammed Salah", BallControl=85,Speed=89,Passing=80,Power=87},
                new Player {Name ="Cristiano Ronaldo", BallControl=20,Speed=88,Passing=83,Power=90},
                new Player {Name ="Lionel Messi", BallControl=94,Speed=86,Passing=88,Power=82}
            };
            List<Error> errors = new List<Error>();// make list of errors
            foreach (Player p in players)
            {
                // Here we use Reflection
                var properties = p.GetType().GetProperties();// var properties contain info about the properties that Player class have
                foreach (var property in properties)
                {
                    var skillsAttribute = property.GetCustomAttribute<SkillAttribute>();// this code return The properties that have a SkillAttribute
                    if (skillsAttribute is not null)// if the property have the attribute then the condition is true 
                    {
                        var value = property.GetValue(p);// her for this property this code return the value of Object(p) at this property
                        if (!skillsAttribute.IsValid(value))// this ckeck if the value is valid o
                        {
                            errors.Add(new Error(property.Name, $"Invalid Value for {p.Name}"));// add new error have the name of property that have invalid value to errors list 
                        }
                    }
                }

            }
            if (errors.Count > 0)
            {
                foreach (var e in errors)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Players Info Are Valid");
            }
        }
    }
    public class Player
    {

        public string Name { get; set; }
        [Skill(nameof(Power), 50, 90)]// here we apply the attribute on power property
        public int Power { get; set; }
        [Skill(nameof(Speed), 60, 100)]
        public int Speed { get; set; }
        [Skill(nameof(Passing), 70, 95)]
        public int Passing { get; set; }
        [Skill(nameof(BallControl), 70, 100)]
        public int BallControl { get; set; }

        public Player(string name, int power, int speed, int passing, int ballControl)
        {
            Name = name;
            Power = power;
            Speed = speed;
            Passing = passing;
            BallControl = ballControl;
        }
        public Player()
        {
                
        }

    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]// here to make conditions on our attribute , AttributeTargets.Property mean that this attribute applicable on properties only
    public class SkillAttribute : Attribute// here we create Attribute and called it SkillAttribute
    {
        public SkillAttribute(string name, int minimum, int maximum)
        {
            Name = name;
            Minimum = minimum;
            Maximum = maximum;
        }

        public string Name { get; private set; }
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }
        public bool IsValid(Object obj)
        {
            var value = (int)obj;
            return value >= Minimum && value <= Maximum;
        }
    }
    public class Error // this class just to show if there are errors
    {
        private string field;
        private string details;

        public Error(string field, string details)
        {
            this.field = field;
            this.details = details;
        }
        public override string ToString()
        {
            return $"{{ \"{field}\": \"{details}\" }}";
        }
    }

}