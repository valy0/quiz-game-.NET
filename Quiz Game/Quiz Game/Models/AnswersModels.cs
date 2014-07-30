using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quiz_Game.Models
{
    public class AnswersContext : DbContext
    {
        public AnswersContext()
            : base("QuizGame")
        {
        }

        public DbSet<Answer> Answers { get; set; }
    }

    [Table("tblAnswers")]
    public class Answer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        public int QuoteID { get; set; }
        public string AnswerText { get; set; }
        public bool Correct { get; set; }
    }
}