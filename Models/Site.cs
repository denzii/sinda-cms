using System.ComponentModel.DataAnnotations;

namespace SindaCMS.Models
{
    public class Site
    {
        public Site(){}

        [Key]
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public List<PageDetail> PageNames { get; set; }
    }
}
