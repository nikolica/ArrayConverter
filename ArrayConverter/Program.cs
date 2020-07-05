namespace ArrayConverter
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.Write("Height: ");
                var height = int.Parse(Console.ReadLine());
                Console.Write("Width: ");
                var width = int.Parse(Console.ReadLine());
                #region Variation_1
                //var source = new int[height, width];
                //Read2dArrayValues(ref source);
                //var result = source.To1dArray();
                //foreach (var value in result)
                //{
                //    Console.Write($"{value}\t");
                //}
                //Console.WriteLine($"\nElement at a[1,2]={result.AccessAs2d(1, 2, width)}");
                #endregion
                #region Variation_2
                var array = new CustomArray(height, width);
                array.Read2dValues();
                array.Write2dValues();
                _ = array.ConvertTo1dArray();
                array.Write1dValues();
                if (array.TwoDimensionalArray[1, 1] == array.Access1dAs2d(1, 1))
                {
                    Console.WriteLine("\n\nGREAT SUCCESS!!1");
                }
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int[] To1dArray(this int[,] input)
        {
            var size = input.Length;
            var result = new int[size];

            var height = input.GetUpperBound(0);
            var width = input.GetUpperBound(1);

            var write = 0;
            for (var i = 0; i <= height; i++)
            {
                for (var z = 0; z <= width; z++)
                {
                    result[write++] = input[i, z];
                }
            }
            return result;
        }
        public static void Read2dArrayValues(ref int[,] sourceArray)
        {
            var height = sourceArray.GetUpperBound(0);
            var width = sourceArray.GetUpperBound(1);

            for (var i = 0; i <= height; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    Console.Write($"a[{i},{j}]=");
                    sourceArray[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public static int AccessAs2d(this int[] input, int x, int y, int width)
        {
            return input[(x * width) + y];
        }
    }

    public struct CustomArray
    {
        private readonly int Height;
        private readonly int Width;
        private readonly int Size;
        public int[] OneDimensionalArray;
        public int[,] TwoDimensionalArray;
        public CustomArray(int height, int width)
        {
            Height = height;
            Width = width;
            Size = height * width;
            OneDimensionalArray = new int[Size];
            TwoDimensionalArray = new int[height, width]; ;
        }
        public int[] ConvertTo1dArray()
        {
            var write = 0;
            for (var i = 0; i <= TwoDimensionalArray.GetUpperBound(0); i++)
            {
                for (var z = 0; z <= TwoDimensionalArray.GetUpperBound(1); z++)
                {
                    OneDimensionalArray[write++] = TwoDimensionalArray[i, z];
                }
            }
            return OneDimensionalArray;
        }
        public void Read2dValues()
        {
            for (var i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"a[{i},{j}]=");
                    TwoDimensionalArray[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public int Access1dAs2d(int x, int y)
        {
            return OneDimensionalArray[(x * Width) + y];
        }
        public void Write1dValues()
        {
            Console.WriteLine("\n1d Array:");
            foreach (var value in OneDimensionalArray)
            {
                Console.Write($"{value}\t");
            }
        }
        public  void Write2dValues()
        {
            Console.WriteLine("\n2d Array:");
            for (int i = 0; i < Height; i++)
            {
                for (int a = 0; a < Width; a++)
                {
                    Console.Write($"{TwoDimensionalArray[i, a]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
