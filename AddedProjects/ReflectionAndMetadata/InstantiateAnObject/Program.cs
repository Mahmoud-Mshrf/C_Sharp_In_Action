namespace InstantiateAnObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var i = new Int32();
            //i = 10;
            ////var i2 = Activator.CreateInstance<Int32>();
            //var i2 =(int) Activator.CreateInstance(typeof(Int32));
            //i2 = 5;
            //DateTime dt =(DateTime) Activator.CreateInstance(typeof(DateTime),2002,01,01);
            //Console.WriteLine(dt);
            Console.WriteLine("Enemy : ");
            do
            {
                var input ="InstantiateAnObject."+Console.ReadLine();
                object obj = null;
                try
                {
                    var assembly = typeof(Program).Assembly.GetName().Name;
                    var enemy = Activator.CreateInstance(assembly,input);
                    obj = enemy.Unwrap();
                }
                catch
                {
                }
                switch (obj)
                {
                    case Goon g:
                        Console.WriteLine(g);
                        break;
                    case Pixa p:
                        Console.WriteLine(p);
                        break;
                    case Agar a:
                        Console.WriteLine(a);
                        break;
                    default: 
                        Console.WriteLine("Unknown type");
                        break;
                }
            } while (true);

        }
    }
    public class Goon
    {
        override public string ToString()
        {
            return "I am a goon";
        }
    }
    public class Pixa
    {
        override public string ToString()
        {
            return "I am a pixa";
        }
    }
    public class Agar
    {
        override public string ToString()
        {
            return "I am an agar";
        }
    }
}
