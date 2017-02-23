using System.Collections.Generic;

namespace SocialPoll.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string TextQuestion { get; set; }

        public virtual List<Variable> Variables { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}
