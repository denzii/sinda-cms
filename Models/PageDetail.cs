using System.ComponentModel.DataAnnotations;

namespace SindaCMS.Models
{
    public class PageDetail
    {
        [Key]
        public string Name { get; set; }

        
        public string SiteBrandName { get; set; }
        public Site Site { get; set; }
    }
}