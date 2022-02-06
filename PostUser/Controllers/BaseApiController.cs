using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PostUser.Context;

namespace PostUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private UserPostDbContext Db;
        protected UserPostDbContext app => Db ??= HttpContext.RequestServices.GetService<UserPostDbContext>();

        private IMapper Mapper;
        protected IMapper mapper => Mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
