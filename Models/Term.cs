namespace Clarity_Crate.Models
{
    public class Term
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public Topic? Topic { get; set; }

        public int TopicId { get; set; }
    }
}
