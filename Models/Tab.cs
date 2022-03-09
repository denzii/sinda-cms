using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SindaCMS.Models
{
    public class Tab
    {
        [Key]
        public string Name { get; set; }
        public SectionStatus Status { get; set; }

        public List<Section> Sections { get; set; }

        [ForeignKey("Page")]
        public string PageName { get; set; }
        public Page Page { get; set; }
    }
}
