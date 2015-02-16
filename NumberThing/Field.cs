using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NumberThing
{
    class Cell
    {
        private int _value;

        public int value
        {
            get { return _value; }
            set { _value = value; }
        }
        public Cell(string val)
        {
            _value = (!String.IsNullOrEmpty(val) ? int.Parse(val) : 0;
        }
    }
    class Field
    {
        public int[][] field;

        public Field(StreamReader file)
        {
            field = new int[NTConstants.Dim][];
            string line;
            int x = 0;
            while ((line = file.ReadLine()) != null)
            {
                int[] row = line.Split(',').Select(n =>
                    (!String.IsNullOrEmpty(n) ? int.Parse(n) : 0)).ToArray();
                if (row.Count() < NTConstants.Dim)
                {
                    int i = row.Count();
                    Array.Resize(ref row, NTConstants.Dim);
                    while (i < NTConstants.Dim)
                        row[i++] = 0;
                }
                field[x++] = row;
            }
            while (field.Count() < NTConstants.Dim)
            {
                field[x++] = new int[NTConstants.Dim];
            }
        }
    }
}
