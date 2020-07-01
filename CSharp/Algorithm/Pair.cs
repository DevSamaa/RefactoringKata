using System;

namespace Algorithm
{
    public class Pair
    {
        public Person YoungerPerson { get; }
        public Person OlderPerson { get;  }
        public TimeSpan AgeDifference { get; }

        public Pair()
        {
        }

        public Pair(Person youngerPerson, Person olderPerson)
        {
            YoungerPerson = youngerPerson;
            OlderPerson = olderPerson;
            AgeDifference = olderPerson.BirthDate - youngerPerson.BirthDate;
        }
    }
}