using Mouse_Simulation.Transactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse_Simulation
{

    public class File_out_Transaction : IDisposable //shut down and clean up the resources of the system
    {
        public string FileName { get; set; }
        public TextWriter Writer { get; }

        public File_out_Transaction(string fileName)
        {
            FileName = fileName;
            //  path, creation mode, and read/write permission. (FileStreem)   A constant that determines how to open or create the file.
            Writer = File.CreateText(fileName);
        }
        public void Save(RecordFileFormat format)
        {
            string name = format.Name;
            uint length = format.Length;
            List<Transaction> transactions = format.Transactions;
            Writer.Write(name + ",");
            Writer.Write(length + "\n");
            foreach (var trans in transactions)
            {
                Writer.Write(trans.TransactionType.ToString() + ",");
                Writer.Write(trans.Point.X + ",");
                Writer.Write(trans.Point.Y + "\n");
            }
            //Clears the buffers for the stream and causes any buffered data to be written to the file.
            Writer.Flush();
            Writer.Close();
        }

        public void Dispose()
        {
            Writer.Dispose();
        }
    }
}
