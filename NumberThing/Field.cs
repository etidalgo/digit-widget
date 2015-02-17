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

        override public string ToString()
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

    class Grouping
    {
        public enum GroupType { Row = 0, Cell, Box };
        public Cell[] Cells;

        public Grouping(Field field, Grouping.GroupType groupType, int typeIdx)
        {
             Cells = new Cell[NTConstants.FieldSize];
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
                        cellRow[i++] = new Cell();
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
                
                Cell[] cellRow = new Cell[NTConstants.FieldSize];
                // Array.ForEach(cellRow, cell => cell = new Cell());
                for (int i = 0; i < NTConstants.FieldSize; i++)
                {
                    cellRow[i] = new Cell();
                }
                Cells[x++] = cellRow;
            }
        }

        public string PrintToString()
        {
            StringBuilder sb = new StringBuilder();
            int row = 0;
            Array.ForEach(Cells, cellRow =>
            {
                row++;
                int col = 0;
                Array.ForEach(cellRow, cell =>
                {
                    col++;
                    sb.AppendFormat(" {0} ", cell.ToString());
                    if (col % NTConstants.BoxSize == 0 && col < NTConstants.FieldSize)
                    {
                        sb.AppendFormat(":", cell.ToString());
                    }
                });
                sb.Append(Environment.NewLine);
                if (row % NTConstants.BoxSize == 0 && row < NTConstants.FieldSize)
                {
                    sb.AppendFormat(" -  -  - : -  -  - : -  -  - " + Environment.NewLine);
                }
            });
            return sb.ToString();
        }
    }
}
