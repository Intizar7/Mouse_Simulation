using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse_Simulation
{
    public struct RecordFileFormat
    {
        public string Name;
        public uint Length;
        public List<Transaction> Transactions;
    }
}
