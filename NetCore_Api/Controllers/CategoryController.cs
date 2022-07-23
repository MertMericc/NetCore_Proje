using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Api.DAL.ApiContext;
using NetCore_Api.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            using var c = new Context();
            var value = c.Find<Category>(p.CategoryID);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName = p.CategoryName;
                c.Update(value);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
