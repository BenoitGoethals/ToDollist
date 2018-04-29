using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoList.PresentationWPF.Annotations;

namespace ToDoList.PresentationWPF.utils
{

    public class ViewModelEventArgs : EventArgs
    {
        public ViewModelEventArgs(object client)
        {
            Client = client;
        }

        public Object Client { get; set; }
    }
    public delegate void ViewEventHandler(object sender, ViewModelEventArgs e);
    public  class Mediator
    {
        public event ViewEventHandler SenderHandler;

        public virtual void Notify(ViewModelEventArgs e)
        {
            ViewEventHandler handler = SenderHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }
}
