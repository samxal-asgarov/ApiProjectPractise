using Microsoft.EntityFrameworkCore;
using PostUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostUser.Context
{
    public class UserPostDbContext:DbContext
    {
        public UserPostDbContext(DbContextOptions<UserPostDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
    }
}
