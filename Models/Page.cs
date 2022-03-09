using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SindaCMS.Models
{
    public class Page
    {
        public Page()
        {
        }

        public List<Tab>? Tabs  { get; set; }

        [Key]
        [ForeignKey("PageDetail")]
        public string PageDetailName { get; set; }
        public PageDetail PageDetail { get; set; }

    }
}
