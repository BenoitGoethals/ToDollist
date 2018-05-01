using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ToDoList.Domain;
using ToDoList.Service.Service;

namespace WebApiNetToDo.Controllers
{
    public class ToDoController : ApiController
    {


        private IService<ToDo> _service;

        public ToDoController(IService<ToDo> service)
        {
            _service = service;
        }

        // GET: api/ToDo
        public async System.Threading.Tasks.Task<IEnumerable<ToDo>> GetAsync()
        {
            return await _service.All();
        }

        // GET: api/ToDo/5
        public async Task<ToDo> Get(int id)
        {
            return await _service.Get(id);
        }

        // POST: api/ToDo
        public async Task Post([FromBody]ToDo value)
        {
           await _service.Add(value);
        }

        // PUT: api/ToDo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ToDo/5
        public  void Delete(int id)
        {
             _service.Delete(id);
        }
    }
}
