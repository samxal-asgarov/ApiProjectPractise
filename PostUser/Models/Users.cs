using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostUser.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
