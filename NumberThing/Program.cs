﻿using System;
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
            string dataFile = @"c:\utils\testdata\test.txt";
            if (args.Length >= 1)
            {
                dataFile = args[0];
            }
            System.IO.StreamReader file = new System.IO.StreamReader(dataFile);

            Field field = new Field(file);
            
            file.Close();

            // print
            Console.WriteLine("{0}", field.PrintToString());
        }
    }
}
