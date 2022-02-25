namespace SBv2.Models
{
    public class PageProps
    {
        public PageProps(BaseProps props)
        {
            Base = props;
        }
        public BaseProps Base { get; set; }
        public string? Name { get; set; } 

        public List<string>? SectionNames { get; set; }
    }
}
