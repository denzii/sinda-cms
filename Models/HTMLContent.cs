using System.ComponentModel.DataAnnotations.Schema;

namespace SindaCMS.Models
{
    public class HTMLContent
    {
        public int Id { get; set; }
        public ContentType Type { get; set; }
        public string? Value { get; set; }

        [ForeignKey("Detail")]
        public int DetailId { get; set; }
        public Detail Detail { get; set; }
    }
}
