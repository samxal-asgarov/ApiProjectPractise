using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostUser.Models;
using PostUser.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var a = await app.Users
                .Include(b => b.Posts)
                .ToListAsync();

            return Ok(await app.Users
                .Include(b=>b.Posts)
                .ToListAsync());
        }
        [HttpPost]

        public async Task<IActionResult> Create(UserDto dto)
        {
            if (ModelState.IsValid)
            {
                app.Users.Add(mapper.Map<Users>(dto));
                await app.SaveChangesAsync();
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var data = await app.Users.FirstOrDefaultAsync(b => b.Id == id);
            if (data == null) return NotFound();
            app.Users.Remove(data);
            await app.SaveChangesAsync();


            return Ok();
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Edit(int id, UserDto dto)
        {
            var data = await app.Users.FirstOrDefaultAsync(b => b.Id == id);
            if (data == null) return NotFound();



            app.Users.Update(mapper.Map(dto, data));
            await app.SaveChangesAsync();
            return Ok(data);



        }
        [HttpGet("{id}")] //biz heqiqeten idni gozluyuruk teleb edirik 
        public async Task<IActionResult> Details(int id)
        {
            Users blog = await app.Users.FirstOrDefaultAsync(b => b.Id == id);     //detallisina baxmaq idsine gore
            if (blog == null) return NotFound(StatusCodes.Status404NotFound);
            return Ok(blog);
        }
    }
}
