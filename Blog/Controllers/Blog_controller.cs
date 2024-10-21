using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Blog.Models;
using static Blog.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [Route("Blogger")]
    [ApiController]
    public class Blog_controller : Controller
    {
        [HttpGet]
        public ActionResult<Blogger> Get()
        {
            using (var context = new BlogDBContext()) {
                return Ok(context.Bloggers.ToList());
            }


        }
        [HttpGet("{Id}")]
        public ActionResult<Blogger> GetbyId(int Id) {
            using (var context = new BlogDBContext())
            { return Ok(context.Bloggers.ToList().Where(x=> x.Id==Id)) ; }
        }

        [HttpPost]
        public ActionResult<Blogger> Post(CreateBloggerDto bloggerDto)
        {
                return Ok();
        }

        [HttpPut("{Id}")]
        public ActionResult<Blogger> Put(int Id, updateBloggerDto bloggerDto)
        {
            using (var context = new BlogDBContext())
            {
                var existingBlogger = context.Bloggers.FirstOrDefault(x => x.Id==Id);
                if (existingBlogger != null)
                {
                    existingBlogger.Name = bloggerDto.Name;
                    existingBlogger.Sex = bloggerDto.Sex;
                    context.Bloggers.Update(existingBlogger);
                    context.SaveChanges();
                    return StatusCode(200, existingBlogger);
                }
                return NotFound();
            }
        }
        [HttpDelete("{Id}")]
        public ActionResult<Blogger> Delete(int Id) {
            using (var context = new BlogDBContext()) {
                context.Bloggers.Remove(context.Bloggers.FirstOrDefault(x => x.Id ==Id));
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
