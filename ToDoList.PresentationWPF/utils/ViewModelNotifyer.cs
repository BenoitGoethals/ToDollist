using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.PresentationWPF.viewModel;

namespace ToDoList.PresentationWPF.utils
{
   public interface IViewModelNotifyer
   {
       void Nofity(ViewModelEventArgs modelEventArgs);
       void Subscribe(ViewModel viewModel);
   }
}
