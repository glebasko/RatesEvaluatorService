using System.Collections.Generic;

namespace RateEvaluator.SharedModels
{
    public class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer() { }

        public Customer(long id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;       
        }
    }
}