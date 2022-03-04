namespace SindaCMS.Models
{
    public class PageProps
    {
        public PageProps(BaseProps props)
        {
            Base = props;
        }
        public BaseProps Base { get; set; }
        public string? Name { get; set; } 

        public List<Page>? Sections  { get; set; }
    }
}
