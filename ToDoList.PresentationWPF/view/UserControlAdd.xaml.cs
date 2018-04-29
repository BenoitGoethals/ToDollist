using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.PresentationWPF.viewModel;

namespace ToDoList.PresentationWPF.view
{
    /// <summary>
    /// Interaction logic for UserControlAdd.xaml
    /// </summary>
    public partial class UserControlAdd : UserControl
    {
        public UserControlAdd()
        {
            InitializeComponent();
            DataContext = new AddViewModel();
        }
    }
}
