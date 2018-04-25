using System;
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
        public Person Person { get; set; }

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
        public Status StatusTask
        {
            get { return _statusTask; }
            set { _statusTask = value;
                OnPropertyChanged(nameof(StatusTask)); }
        }

       
       
        


    }

    public enum Status
    {
        Created,
        Started,
        Finshed
    }
}
