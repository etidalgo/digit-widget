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

        public string ToString()
        {
            return IsSet ? _value.ToString() : " ";
        }

        public bool IsSet { get { return (_value != 0);  } }

        public Cell(string val = "")
        {
            candidates = new bool[NTConstants.FieldSize];
            _value = !String.IsNullOrEmpty(val) ? int.Parse(val) : 0;
            Array.ForEach(candidates, n => { n = IsSet; });
        }
    }

    class Field
    {
        public int[][] field;
        public Cell[][] Cells;

        public Field(StreamReader file)
        {
            Cells = new Cell[NTConstants.FieldSize][];
            field = new int[NTConstants.FieldSize][];
            string line;
            int x = 0; 
            while ((line = file.ReadLine()) != null)
            {
                int[] row = line.Split(',').Select(n =>
                    (!String.IsNullOrEmpty(n) ? int.Parse(n) : 0)).ToArray();
                Cell[] cellRow = line.Split(',').Select(n =>
                    new Cell(n)).ToArray();
                if (row.Count() < NTConstants.FieldSize)
                {
                    int i = row.Count();
                    Array.Resize(ref row, NTConstants.FieldSize);
                    while (i < NTConstants.FieldSize)
                        row[i++] = 0;

                    i = cellRow.Count();
                    Array.Resize(ref cellRow, NTConstants.FieldSize);
                    while (i < NTConstants.FieldSize)
                        cellRow[i++] = new Cell("");
                }
                field[x] = row;
                Cells[x] = cellRow;
                x++;

            }

            int origCount = x;
            x = origCount;
            while (x < NTConstants.FieldSize)
            {
                field[x++] = new int[NTConstants.FieldSize];
            }

            x = origCount;
            while (x < NTConstants.FieldSize)
            {
                Cells[x++] = new Cell[NTConstants.FieldSize];
            }
        }
    }
}
