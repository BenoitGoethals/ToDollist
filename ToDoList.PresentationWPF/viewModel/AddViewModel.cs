using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ToDoList.Domain;
using ToDoList.PresentationWPF.Annotations;
using ToDoList.PresentationWPF.utils;
using ToDoList.PresentationWPF.view;
using ToDoList.Service.Service;

namespace ToDoList.PresentationWPF.viewModel
{
   public  class AddViewModel:ViewModel, IViewModelNotifyer
    {
        private ToDo _toDoAdd = new ToDo(){StatusTask = Status.Created,DateTimeCreated = DateTime.Now,ExpireDate = DateTime.Now.AddDays(1)};

        public ToDo ToDoAdd
        {
            get => _toDoAdd;
            set
            {
                if (Equals(value, _toDoAdd)) return;
                _toDoAdd = value;
                
            }
        }


        public RelayCommand AddCommand { get;  set; }

        public AddViewModel()
        {
            AddCommand = new RelayCommand( async (t) =>
            {
             //   await Task.Run(() =>
               //  {
                     await ServiceToDo.Instance().Add(ToDoAdd);
                 //});
             

              //  OnPropertyChanged(nameof(ToDoAdd));
               Nofity(new ViewModelEventArgs(ToDoAdd));
                ToDoAdd = new ToDo() { StatusTask = Status.Created, DateTimeCreated = DateTime.Now, ExpireDate = DateTime.Now.AddDays(1) };
            });
        }


        private void show()
        {
           
            MessageBox.Show("add"+ToDoAdd);
        }


        public void Nofity(ViewModelEventArgs modelEventArgs)
        {
            App.mediator.Notify(modelEventArgs);
        }

        public void Subscribe(ViewModel viewModel)
        {
            
        }
    }

    public class ViewModel: INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName] => throw new NotImplementedException();

        public string Error { get; }
    }
}
