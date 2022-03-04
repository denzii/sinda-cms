namespace SindaCMS.Models
{
    public class Section
    {
        public string Id { get; set; }
        public string Header { get; set; }
        public List<Detail> Details { get; set; } 
    }
}
