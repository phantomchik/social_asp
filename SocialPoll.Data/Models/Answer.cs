
namespace SocialPoll.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Gruppa { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual Variable Variable { get; set; }
    }
}
