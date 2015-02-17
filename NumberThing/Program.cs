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

    class Row 
    {
        public List<int> cells = new List<int>();
        public Row(string raw)
        {
            cells = raw.Split(',').Select(n => (!String.IsNullOrEmpty(n) ? int.Parse(n) : 0)).ToList();
            while( cells.Count < NTConstants.FieldSize) 
                cells.Add(0);
        }
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

            //string line;
            //while ((line = file.ReadLine()) != null)
            //{
            //    Row thisRow = new Row(line);

            //}
            Field field = new Field(file);
            
            file.Close();

            // print
            Console.WriteLine("{0}", field.PrintToString());
        }
    }
}
