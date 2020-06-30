using System;

namespace Algorithm
{
    public class Pair
    {
        public Person YoungerPerson { get; set; }
        
        public Person OlderPerson { get; set; }
        public TimeSpan AgeDifference { get; set; }
    }
}