using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Pair Find(Option option)
        {
            var allPairsOfUsers = new List<Pair>();

            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    var pairOfUsers = new Pair();
                    
                    //TODO look at maybe extracting this out into its own method?
                    var tempList = new List<Person>(){_people[i], _people[j]};
                    var orderedList = tempList.OrderBy(x => x.BirthDate).ToList();
                    pairOfUsers.YoungerPerson = orderedList.First();
                    pairOfUsers.OlderPerson = orderedList.Last();
                    pairOfUsers.ExactAgeDifference = pairOfUsers.OlderPerson.BirthDate - pairOfUsers.YoungerPerson.BirthDate;
                    allPairsOfUsers.Add(pairOfUsers);
                }
            }
            
            return allPairsOfUsers.Count < 1 ? new Pair() : FindsCorrectPair(allPairsOfUsers, option);
        }

        public Pair FindsCorrectPair(List<Pair> allPairsOfUsers, Option option )
        {
           var orderedAllPairsOfUsers= allPairsOfUsers.OrderBy(x => x.ExactAgeDifference);
           return option == Option.ClosestTwo ? orderedAllPairsOfUsers.First() : orderedAllPairsOfUsers.Last();
        }
    }
}