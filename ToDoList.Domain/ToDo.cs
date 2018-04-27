using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Domain
{
    [Table("ToDo")]
    public class ToDo:Identity
    {

        private string _description;
        private DateTime _dateTimeCreated;
        private DateTime _expireDate;
        private Status _statusTask;
        private Person _person;

        public ToDo()
        {
        }

        public ToDo(string description, DateTime dateTime, DateTime expireDate, Status status)
        {
            this.Description = description;
            this.DateTimeCreated = dateTime;
            this.ExpireDate = expireDate;
            this.StatusTask = status;
        }

        [Column("Description")]
        [Required]
        public String Description
        {
            get { return _description; }
            set
            {
                _description = value; 
                OnPropertyChanged(nameof(Description));
            }
        }
        [Column("DateTimeCreated")]
        [Required]
        public DateTime DateTimeCreated
        {
            get { return _dateTimeCreated; }
            set
            {
                _dateTimeCreated = value;
                OnPropertyChanged(nameof(DateTimeCreated));
            }
        }
        [Column("ExpireDate")]
        [Required]
        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set
            {
                _expireDate = value;
                OnPropertyChanged(nameof(ExpireDate));
            }
        }
        [Column("StatusTask")]
        [Required]
        public Status StatusTask
        {
            get { return _statusTask; }
            set { _statusTask = value;
                OnPropertyChanged(nameof(StatusTask)); }
        }

        [ForeignKey("Person")]
        public int? PersonId { get; set; }
        [Column("Person")]
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
            }
        }
       

        public override string ToString()
        {
            return $"{nameof(Description)}: {Description}, {nameof(DateTimeCreated)}: {DateTimeCreated}, {nameof(ExpireDate)}: {ExpireDate}, {nameof(StatusTask)}: {StatusTask}, {nameof(Person)}: {Person}";
        }
    }
}
