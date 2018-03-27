using System;

namespace ToDollist.Domain
{

    public class Person : Identity
    {
        public String Description { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public Person(int id, string description, DateTime dateTimeCreated)
        {
            Id = id;
            Description = description;
            DateTimeCreated = dateTimeCreated;
        }

        public Person()
        {
        }


        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Description)}: {Description}, {nameof(DateTimeCreated)}: {DateTimeCreated}";
        }
    }
}