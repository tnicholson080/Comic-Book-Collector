using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ComicCollection
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool isPublic { get; set; }
        public int userId { get; set; }
        public int favorites { get; set; }
        public bool isFavorited { get; set; }
        public Comic[] comics { get; set; }
        public string description { get; set; }
        public string cover { get; set; }
        public string theme { get; set; }

    }
}
