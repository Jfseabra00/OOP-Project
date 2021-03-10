using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Voting_System
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            // Make new object of file handler to get all required data and get the file path
            FileHandler partiesData = new FileHandler();
            string filePath = partiesData.getFilePath();

            // Make list of party classes to hold all parties from the sorted data
            List<Party> parties = partiesData.SortPartiesData();

            // Calculations for Dhond't method, takes list of parties and file path
            CalculateDhondt(parties, partiesData.TitleOfElection, partiesData.NumOfSeatAllocation);

            // Safely exit out the console once finished
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        // Main method which calculaties which party to award seats too,and display those parties
        private static void CalculateDhondt(List<Party> parties, string electionTitle, int numOfSeatAllocations)
        {
            // Find total votes for all parties and number of seats to be allocated

            // Keep looping through partys and applying dhond't method until all seats are taken
            int totalSeatsCount = 0;
            while (totalSeatsCount != numOfSeatAllocations)
            {
                // If we havent reached desired seats count reset the total seats variable
                totalSeatsCount = 0;

                Party biggestVotes = parties.Aggregate((v1, v2) => v1.NewVotes > v2.NewVotes ? v1 : v2);
                biggestVotes.SeatsAmount += 1;
                biggestVotes.DivideParty();

                // Check total seats for all parties
                foreach (Party party in parties)
                {
                    totalSeatsCount += party.SeatsAmount;
                }
            }

            Console.WriteLine($"\n{numOfSeatAllocations} seats successfully allocated :\n{electionTitle}");

            // Display parties who are awarded a seat
            foreach (Party p in parties)
            {
                if (p.HasSeats())
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}
