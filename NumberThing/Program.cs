using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberThing
{
    class NTConstants {
        public static int Dim = 9; 
    }
    class Row 
    {
        public List<int> cells = new List<int>();
        public Row(string raw)
        {
            cells = raw.Split(',').Select(n => (!String.IsNullOrEmpty(n) ? int.Parse(n) : 0)).ToList();
            while( cells.Count < NTConstants.Dim) 
                cells.Add(0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string raw = "1,2";
            List<int> cells = raw.Split(',').Select(n => int.Parse(n)).ToList();



            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(@"c:\testdata\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                Row thisRow = new Row(line);
                
            }

            file.Close();
        }
    }
}
