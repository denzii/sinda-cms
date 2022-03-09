using System.ComponentModel.DataAnnotations.Schema;

namespace SindaCMS.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public ContentType Type { get; set; }

        public List<HTMLContent> Contents { get; set; }

        [ForeignKey("Section")]
        public string SectionKey { get; set; }
        public Section Section { get; set; }
    }
}