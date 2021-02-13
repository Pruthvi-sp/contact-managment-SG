using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Models;
namespace ContactManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsApiController : ControllerBase
    {
        public ContactsApiController(IContactRepository contacts)
        {
            TodoItems = contacts;
        }
        public IContactRepository TodoItems { get; set; }
        public IEnumerable<ContactsModel> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetContacts")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);

        }
    }
}