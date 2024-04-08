namespace Clarity_Crate.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();


        public List<Term> Terms { get; set; } = new List<Term>();


    }
}
