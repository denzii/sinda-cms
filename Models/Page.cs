namespace SindaCMS.Models
{
    public class Page
    {
        public string Name { get; set; }
        public SectionStatus Status { get; set; }

        public List<Detail> Contents { get; set; }
    }
}
