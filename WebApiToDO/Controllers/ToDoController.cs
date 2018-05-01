using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain;
using ToDoList.Service.Service;

namespace WebApiToDO.Controllers
{
    [Produces("application/json")]
    [Route("api/ToDo")]
    public class ToDoController : Controller
    {

        private IService<ToDo> _service;

        public ToDoController(IService<ToDo> service)
        {
            _service = service;
        }


        // GET: api/ToDo
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return _service.All().Result;
        }

        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/ToDo
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
