using System;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public int Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
