namespace Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arrays :
            // Single-dimensional array:
            string[] Friends = new string[] { "Mahmoud ", "Mohamed " };
            string[] Friends2 = { "Ahmed", "Ali" };
            string[] Friends3 = ["Hashem", "Hossam"];
            Array array = Array.CreateInstance(typeof(string), 4);
            array.SetValue("Omar", 0);
            array.SetValue("Amr", 1);
            array.SetValue("Ayman", 2);
            array.SetValue("Ashraf", 3);
            for (int i = 0; i < Friends.Length; i++ )
            {
                Console.Write(Friends[i]);
            }
            Console.WriteLine();
            //////////////////////////////////////////
            // Multi-dimensional array :A multidimensional array is like a table (matrix) with fixed rows and columns.
            string[,] Matrix = { { "Mahmoud ", "Mohamed " },
                             { "Kareem ", "Tamer " } };
            for(int i = 0;i < Matrix.GetLength(0);i++)
            {
                for(int j = 0;j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i,j]);
                }
            }
            ///////////////////////////////////////////
            // Jagged Array : A jagged array is an array of arrays (each row can have different lengths). (Array of Arrays)
            string[][] strings = new string[][]
            {
                new string[] {"Mohamed","Amr","Hesham"},
                Friends,
                Friends2,
                Friends3
            };
            int[][] jagged =
            {
                new int[] {1, 2, 3},
                new int[] {4, 5}
            };

            for (int i = 0; i < jagged.Length; i++) // rows
            {
                for (int j = 0; j < jagged[i].Length; j++) // columns (different per row!)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
        

    }
}
