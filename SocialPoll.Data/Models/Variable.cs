
namespace SocialPoll.Data.Models
{
    public class Variable
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
