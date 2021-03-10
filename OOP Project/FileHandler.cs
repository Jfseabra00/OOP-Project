using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Voting_System
{
    class FileHandler
    {
        public string FilePath { get; private set; }
        public string TitleOfElection { get; private set; }
        public int NumOfSeatAllocation { get; private set; }

        // Takes input of the name of the data file and outputs the required data
        public List<Party> SortPartiesData()
        {
            // Reads from the data file the user inputs
            List<string> file = File.ReadAllLines(Path.GetFullPath(Path.Combine(@"..\..\..\..\" + FilePath))).ToList();
            List<Party> parties = new List<Party>();

            NumOfSeatAllocation = Convert.ToInt32(file[1]);
            TitleOfElection = file[0];

            // Store required values from data file for each party in a list of Party class
            foreach (string line in file.Skip(3))
            {
                string[] items = line.Split(',');
                Party p = new Party(items[0], Convert.ToInt32(items[1]), items.Skip(2).ToArray());
                parties.Add(p);
            }
            return parties;
        }

        public string getFilePath()
        {
            Console.WriteLine("Type the name of the text file your data is held : ");
            string fileName = Console.ReadLine() + ".txt";
            FilePath = fileName;
            return FilePath;
        }
    }
}