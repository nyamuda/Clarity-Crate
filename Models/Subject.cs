namespace Clarity_Crate.Models
{
    public class Subject
    {
        public int Id { get; set; }


        public string? Name { get; set; }

        public List<Curriculum> Curriculums { get; } = new List<Curriculum>();
        public List<Topic> Topics { get; } = new List<Topic>();
    }
}
