using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NumberThing
{
    class NTConstants {
        public static int BoxSize = 3;
        public static int FieldSize = 9; 
    }

    class Program
    {
        static void Main(string[] args)
        {
            string raw = "8,3";
            List<int> cells = raw.Split(',').Select(n => 
                int.Parse(n)).ToList();


            raw.Split(',').Select(n => 
                int.Parse(n)).ToArray();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\utils\testdata\test.txt");

            Field field = new Field(file);
            
            file.Close();

            // print
            int row = 0;
            Array.ForEach(field.Cells, cellRow =>
            {
                row++;
                int col = 0;
                Array.ForEach(cellRow, cell =>
                {
                    col++;
                    Console.Write(" {0} ", cell.ToString());
                    if (col % NTConstants.BoxSize == 0 && col < NTConstants.FieldSize )
                    {
                        Console.Write("|", cell.ToString());
                    }
                });
                Console.WriteLine("");
                if (row % NTConstants.BoxSize == 0 && row < NTConstants.FieldSize)
                {
                    Console.WriteLine("---------+---------+---------");
                }
            });
        }
    }
}
