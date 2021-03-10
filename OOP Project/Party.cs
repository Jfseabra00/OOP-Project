using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_System
{
    class Party
    {
        // Fields
        public string Name { get; private set; }
        public int Votes { get; private set; }
        public int NewVotes { get; private set; }
        public string[] SeatsCodeValues { get; private set; }

        private int _seatsAmount;

        // Properties 
        public int SeatsAmount
        {
            get { return _seatsAmount; }
            set
            {
                if (value > 0)
                {
                    _seatsAmount = value;
                }
            }
        }

        // Constructor for party class,which takes inputs and assigns them to properties
        public Party(string name, int votes, string[] seatsCodeValues)
        {
            Name = name;
            Votes = votes;
            NewVotes = votes;
            SeatsCodeValues = seatsCodeValues;
        }

        // Returns percentage of votes for your party
        public double PercentOfVotes(double totalVotes) => (Votes / totalVotes) * 100;

        // When ever you print the object of this class return this
        public override string ToString()
        {
            return $"Name: {Name}, Votes: {Votes} - {string.Join(",", SeatsCodeValues.Take(SeatsAmount))};";
        }

        // Applies Dhond't method of division 
        public void DivideParty() => NewVotes = Votes / (1 + SeatsAmount);

        public bool HasSeats() => SeatsAmount > 0 ? true : false;
    }
}