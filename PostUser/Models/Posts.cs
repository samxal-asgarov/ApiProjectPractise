using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostUser.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Tittle { get; set; }

        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}
