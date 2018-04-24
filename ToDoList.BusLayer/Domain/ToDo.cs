using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoList.BusLayer.Domain
{
   public class ToDo:Identity
    {
        private string _description;
        private DateTime _dateTimeCreated;
        private DateTime _expireDate;
        private Status _statusTask;


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

        public String Description
        {
            get { return _description; }
            set
            {
                _description = value; 
                OnPropertyChanged(nameof(Description));
            }
        }

        public DateTime DateTimeCreated
        {
            get { return _dateTimeCreated; }
            set
            {
                _dateTimeCreated = value;
                OnPropertyChanged(nameof(DateTimeCreated));
            }
        }

        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set
            {
                _expireDate = value;
                OnPropertyChanged(nameof(ExpireDate));
            }
        }

        public Status StatusTask
        {
            get { return _statusTask; }
            set { _statusTask = value;
                OnPropertyChanged(nameof(StatusTask)); }
        }

        public Person Person { get; set; }
       
        

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Description)}: {Description}, {nameof(DateTimeCreated)}: {DateTimeCreated}";
        }

    }

    public enum Status
    {
        Created,
        Started,
        Finshed
    }
}
