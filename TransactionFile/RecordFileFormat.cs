using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mouse_Simulation.Transactions;

namespace Mouse_Simulation
{
    public class RecordFileFormat
    {
        public string Name;
        public uint Length;
        public List<Transaction> Transactions;
    }
}
