using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoList.Domain;
using ToDoList.PresentationWPF.utils;
using ToDoList.PresentationWPF.view;

namespace ToDoList.PresentationWPF.viewModel
{
  public  class MainViewModel
    {
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        private void show()
        {
            MessageBox.Show("add");

        }
        public MainViewModel()
        {
            _toDos.Add(new ToDo("test1", DateTime.Now, DateTime.Now.AddDays(2), Status.Created) { Id = 1 });
            _toDos.Add(new ToDo("test2", DateTime.Now, DateTime.Now.AddDays(2), Status.Finshed) { Id = 2 });
            _toDos.Add(new ToDo("test3", DateTime.Now, DateTime.Now.AddDays(2), Status.Created) { Id = 3 });


            AddCommand = new RelayCommand(s=>this.show(s));




            UpdateCommand = new RelayCommand(s => this.show(s));




            DeleteCommand = new RelayCommand(t =>
            {
                _toDos.Remove(t as ToDo);

            });
        }

        private void show(Object s)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
           // MessageBox.Show("add"+((ToDo) s).Description);
        }

        private ObservableCollection<ToDo> _toDos=new ObservableCollection<ToDo>();

        public ObservableCollection<ToDo> ToDos
        {
            get { return _toDos; }
            set { _toDos = value; }
        }

    }
}
