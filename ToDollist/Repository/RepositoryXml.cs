using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToDollist.Domain;

namespace ToDollist.Repository
{
   public  class RepositoryXml<T> : IReposotory<T> where T : Identity
    {

       private readonly String _xmlFile = $"c://temp//{nameof(T)}.xml";

      

        public void Delete(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public void Add(T toDo)
        {
            XElement elements = this.ReadXml();

            /**
            elements.Add(new XElement("ToDo",
                new XElement("Id", toDo.Id),
                new XElement("Description", toDo.Description),
                new XElement("DateTimeCreated", toDo.DateTimeCreated)
            ));
            */
            elements.Save(_xmlFile);
        }

        public void Delete(T toDo)
        {
            throw new NotImplementedException();
        }

        public void Update(T toDo)
        {
            throw new NotImplementedException();
        }

        List<Identity> IReposotory<T>.All()
        {
            /**
            XElement elements = this.ReadXml();


            List<ToDo> ret =
                elements.Elements("ToDo")
                    .Select(q => new ToDo()
                    {
                        Id = (int)q.Element("Id"),
                        Description = (string)q.Element("Description"),
                        DateTimeCreated = (DateTime)q.Element("DateTimeCreated"),

                    }).ToList();
            return ret;
            */
            return null;
        }

        T IReposotory<T>.Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idDelete)
        {
            throw new NotImplementedException();
        }

       
       public ToDo Get(int id)
       {
           throw new NotImplementedException();
       }

       public void Delete<T>(int idDelete)
       {
           throw new NotImplementedException();
       }

      



       private XElement ReadXml()
       {
           XElement xelement =new XElement("ToDo");
           if (File.Exists(_xmlFile))
           {
                xelement = XElement.Load(_xmlFile);
            }
           
           return xelement;

       }

       private void SaveXml()
       {
           
       }
    }
}
