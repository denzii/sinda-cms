namespace SindaCMS.Models
{
    public class BaseProps
    {
        public BaseProps()
        {
            BrandName = "Sinda";
            PageNames = new List<string> { "Docs", "Blog", "Roadmap" };
            BrandDescription = "Sindagal MIT";   
        }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public List<string> PageNames { get; set; }
    }
}
