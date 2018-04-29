using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
  public  class MainViewModel:ViewModel, IViewModelNotifyer
    {

        private object _stocksLock = new object();
        public ToDo SelectetToDo
        {
            get => _selectetToDo;
            set
            {
                if (Equals(value, _selectetToDo)) return;
                _selectetToDo = value;
                //OnPropertyChanged();
            }
        }


        //    public RelayCommand AddCommand { get; private set; }
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
       
        public MainViewModel()
        {
            App.mediator.SenderHandler += Mediator_SenderHandler;
            var slowTask = Task<Task<List<ToDo>>>.Factory.StartNew(() => ServiceToDo.Instance().All());

            ToDos = new AsyncObservableCollection<ToDo>(slowTask.Result.Result);
            
            UpdateCommand = new RelayCommand(s => this.show(s));

            DeleteCommand = new RelayCommand(t =>
            {
                Task.Factory.StartNew(() => ServiceToDo.Instance().Delete(_selectetToDo));
                lock (_stocksLock)
                {
                    ToDos.Remove(t as ToDo);
                 //   OnPropertyChanged("ToDos");
                }

                
            });
            
        }
        public NotifyTaskCompletion<List<ToDo>> UrlByteCount { get; private set; }
        private void Mediator_SenderHandler(object sender, ViewModelEventArgs e)
        {
            lock (_stocksLock)
            {
                ToDos.Add((ToDo) e.Client);
        //        OnPropertyChanged("ToDos");
            }
            //    OnPropertyChanged("ToDos");

        }

        private void show(Object s)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
           // MessageBox.Show("add"+((ToDo) s).Description);
        }

        private AsyncObservableCollection<ToDo> _toDos=new AsyncObservableCollection<ToDo>();
        private ToDo _selectetToDo;

        public AsyncObservableCollection<ToDo> ToDos
        {
            get { return _toDos; }
            set
            {
                _toDos = value;
               // OnPropertyChanged("ToDos");
            }
        }


        public void Nofity(ViewModelEventArgs modelEventArgs)
        {
            
        }

        public void Subscribe(ViewModel viewModel)
        {
           
        }
    }
}
