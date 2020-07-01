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
                    var pairWithAgeDifference = FindsAgeDifference(_people[i], _people[j]);
                    allPairsOfUsers.Add(pairWithAgeDifference);
                }
            }
            return allPairsOfUsers.Count < 1 ? new Pair() : FindsCorrectPair(allPairsOfUsers, option);
        }

        private Pair FindsAgeDifference(Person person1, Person person2)
        {
            return person1.BirthDate > person2.BirthDate
                ? new Pair(person2, person1)
                : new Pair(person1, person2);		
        }
        
        private Pair FindsCorrectPair(List<Pair> allPairsOfUsers, Option option )
        {
           var orderedAllPairsOfUsers= allPairsOfUsers.OrderBy(x => x.AgeDifference);
           return option == Option.ClosestTwo ? orderedAllPairsOfUsers.First() : orderedAllPairsOfUsers.Last();
        }
    }
}