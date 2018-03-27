using System;

namespace ToDollist.Domain
{
   public class ToDo:Identity
    {
        public ToDo(string description, DateTime dateTime)
        {
            this.Description = description;
            this.DateTimeCreated = dateTime;
        }

        public String Description { get;  set; }
        public DateTime DateTimeCreated { get; set; }

       
        

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Description)}: {Description}, {nameof(DateTimeCreated)}: {DateTimeCreated}";
        }
    }
}
