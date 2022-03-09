using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SindaCMS.Models
{
    public class Section
    {
        [Key, StringLength(900)]
        public string Id { get; set; }
        public int Index { get; set; }
        public string Header { get; set; }

        public bool HasMainContent { get; set; }
        public List<Detail> Details { get; set; }

        [ForeignKey("Tab")]
        public string TabName { get; set; }
        public Tab Tab { get; set; }


        //[ForeignKey("Page")]
        //public string PageName { get; set; }
        //public Page Page { get; set; }
    }
}
