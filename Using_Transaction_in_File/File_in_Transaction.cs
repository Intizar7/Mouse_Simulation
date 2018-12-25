using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse_Simulation
{
    public class File_in
    {
        public TextReader Reader { get; set; }
        public string filename;
        public File_in(string filename)
        {
            this.filename = filename;
            Console.WriteLine(Reader);
        }
          
        public List<Transaction> Load()
        {
            List<Transaction> transactions = new List<Transaction>();

            using (var reader = new StreamReader(this.filename))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    transactions.Add(new Transaction((TransactionType)Enum.Parse(typeof(TransactionType), values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[1])));
                }
            }        
            return transactions;
        }
    }
}
