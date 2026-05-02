using System.Reflection;
using static _01_Attributes.Program;

namespace _01_Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>() { new Player{Name = "Mohamed Salah",BallControl=85,Passing=80,Shooting=90,Speed=92},
                                               new Player{Name = "Neymar JR",BallControl=90,Passing=85,Shooting=90,Speed=40},
                                               new Player{Name = "Lionel Messi",BallControl=85,Passing=80,Shooting=90,Speed=92}
            };
            var errors = new List<Error>();

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
                            errors.Add(new Error(property.Name, $"Invalid Value at {p.Name}"));// add new error have the name of property that have invalid value to errors list 
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
        public class Player
        {
            public Player(string name, int passing, int shooting, int speed, int ballControl)
            {
                Name = name;
                Passing = passing;
                Shooting = shooting;
                Speed = speed;
                BallControl = ballControl;
            }
            public Player()
            {

            }

            public string Name { get; set; }
            [Skill(nameof(Passing), 95, 50)]
            public int Passing { get; set; }
            [Skill(nameof(Shooting), 95, 50)]
            public int Shooting { get; set; }
            [Skill(nameof(Speed), 95, 50)]
            public int Speed { get; set; }
            [Skill(nameof(BallControl), 95, 50)]
            public int BallControl { get; set; }
        }
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class SkillAttribute : Attribute
        {
            public SkillAttribute(string name, int maximum, int minimum)
            {
                Maximum = maximum;
                Minimum = minimum;
                Name = name;
            }

            public int Maximum { get; set; }
            public int Minimum { get; set; }
            public string Name { get; set; }

            public bool IsValid(object obj)
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
}