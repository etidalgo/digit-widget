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
        private bool[] candidates;

        private int _value;

        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        public bool IsSet { get { return (_value != 0);  } }

        public Cell(string val)
        {
            candidates = new bool[NTConstants.Dim];
            _value = !String.IsNullOrEmpty(val) ? int.Parse(val) : 0;
            Array.ForEach(candidates, n => { n = IsSet; });
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
