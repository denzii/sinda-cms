namespace SindaCMS.Models
{
    public class PageTab
    {
        public string Name { get; set; }
        public SectionStatus Status { get; set; }

        public List<Section> Sections { get; set; }
    }
}
