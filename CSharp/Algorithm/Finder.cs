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
                    var twoPeople = new List<Person>(){_people[i], _people[j]};
                    var pairWithAgeDifference = FindsAgeDifference(twoPeople);
                    allPairsOfUsers.Add(pairWithAgeDifference);
                }
            }
            return allPairsOfUsers.Count < 1 ? new Pair() : FindsCorrectPair(allPairsOfUsers, option);
        }

        public Pair FindsAgeDifference(List<Person> twoPeople)
        {
            var twoPeopleOrdered = twoPeople.OrderBy(x => x.BirthDate).ToList();
            var pair = new Pair {YoungerPerson = twoPeopleOrdered.First(), OlderPerson = twoPeopleOrdered.Last()};
            pair.AgeDifference = pair.OlderPerson.BirthDate - pair.YoungerPerson.BirthDate;
            return pair;
        }
        public Pair FindsCorrectPair(List<Pair> allPairsOfUsers, Option option )
        {
           var orderedAllPairsOfUsers= allPairsOfUsers.OrderBy(x => x.AgeDifference);
           return option == Option.ClosestTwo ? orderedAllPairsOfUsers.First() : orderedAllPairsOfUsers.Last();
        }
    }
}