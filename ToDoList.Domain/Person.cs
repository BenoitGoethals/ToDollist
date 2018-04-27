using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Domain
{

    [Table("Person")]
    public class Person : Identity
    {
       private string _name;
       private string _forName;
       private string _street;
       private string _nr;
       private string _city;
       private string _zipCode;
       private Gender _gender;

        public Person()
        {
        }

        public Person(string name,  string forName,  string street,  string nr,  string city,  string zipCode, Gender gender)
        {
            _name = name;
            _forName = forName;
            _street = street;
            _nr = nr;
            _city = city;
            _zipCode = zipCode;
            _gender = gender;
        }


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

       
        public string ForName
        {
            get => _forName;
            set
            {
                _forName = value;
                OnPropertyChanged(nameof(ForName));
            }
        }

        
        public string Street
        {
            get => _street;
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        public string Nr
        {
            get => _nr;
            set
            {
                _nr = value;
                OnPropertyChanged(nameof(Nr));
            }
        }
        
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string ZipCode
        {
            get => _zipCode;
            set
            {
                _zipCode = value;
                OnPropertyChanged(nameof(ZipCode));
            }
        }

        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }


        public ICollection<ToDo> ToDo { get; set; }


        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(ForName)}: {ForName}, {nameof(Street)}: {Street}, {nameof(Nr)}: {Nr}, {nameof(City)}: {City}, {nameof(ZipCode)}: {ZipCode}, {nameof(Gender)}: {Gender}";
        }

       
    }
}