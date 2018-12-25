using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mouse_Simulation
{
    public class Transaction
    {

        public TransactionType TransactionType { get; set; }
        public Point Point { get; set; }
        public int Sleep { get; set; }
        public Keys keys { get; set; }

        public Transaction(TransactionType type)
        {
            TransactionType = type;
        }

        public Transaction(TransactionType type, int x = 0, int y = 0, int st = 0)
        {
            TransactionType = type;

            Point = new Point(x, y);
        }

        public Transaction(TransactionType type, int st = 0)
        {
            TransactionType = type;
            Sleep = st;
        }

        public Transaction(TransactionType type, Keys keys)
        {
            TransactionType = type;

            this.keys = keys;
        }
    }
}
