using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public IActionResult TaskList()
        {
            using var c = new Context();
            var values = c.tasks.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult TaskAdd(Task task)
        {
            using var c = new Context();
            c.Add(task);
            c.SaveChanges(); ;
            return Ok(c);
        }
        [HttpDelete("{id}")]
        public IActionResult TaskDelete(int id) 
        {
            using var c = new Context();
            var task = c.tasks.Find(id);
            if (task == null) 
            {
                return NotFound();
            }
            else
            {
                c.Remove(task);
                c.SaveChanges() ;
                return Ok(c);
            }
        }
    }
}
