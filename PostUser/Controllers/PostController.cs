using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostUser.Context;
using PostUser.Models;
using PostUser.Models.DTOs;
using System.Threading.Tasks;

namespace PostUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await app.Posts.ToListAsync());
        }


        [HttpGet("{id}")] //biz heqiqeten idni gozluyuruk teleb edirik 
        public async Task<IActionResult> Details(int id)
        {
            Posts blog = await app.Posts.FirstOrDefaultAsync(b => b.Id == id);     //detallisina baxmaq idsine gore
            if (blog == null) return NotFound(StatusCodes.Status404NotFound);
            return Ok(blog);
        }


        [HttpPost]

        public async Task<IActionResult> Creat(PostDto dto)
        {
            if (ModelState.IsValid)
            {
                app.Posts.Add(mapper.Map< Posts >(dto));
                await app.SaveChangesAsync();
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Edit(int id,PostDto dto)
        {
            var data =await app.Posts.FirstOrDefaultAsync(b => b.Id == id);
            if (data == null) return NotFound();



            app.Posts.Update(mapper.Map(dto, data));
            await app.SaveChangesAsync();
            return Ok(data);



        }


        [HttpDelete("{id}")]


        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var data = await app.Posts.FirstOrDefaultAsync(b => b.Id == id);
            if (data == null) return NotFound();
            app.Posts.Remove(data);
            await app.SaveChangesAsync();


            return Ok();
        }










    }
}
