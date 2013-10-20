using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoWorkers.Models
{
    public class CoWorkersMdel
    {
        public User User { get; set; }
        public User Profile { get; set; }
        public Group Group { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }

        public List<Group> Groups { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<User> Users { get; set; }
    }
}