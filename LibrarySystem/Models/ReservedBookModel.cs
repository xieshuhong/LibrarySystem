using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class ReservedBookModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ImageSource Imagesource { get; set; }
        public DateTime Startdate { get; set; }

        public DateTime Endate { get; set; }

        public string Username  { get; set; }

        public string Description { get; set; }
    }
}
