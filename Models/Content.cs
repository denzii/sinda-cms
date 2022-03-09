using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SindaCMS.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public ContentType Type { get; set; }

        public List<HTMLContent> Contents { get; set; }

        public string SectionId { get; set; }
        public Section Section { get; set; }
    }
}