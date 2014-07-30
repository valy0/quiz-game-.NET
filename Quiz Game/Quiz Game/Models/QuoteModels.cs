using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quiz_Game.Models
{
    public class QuoteContext : DbContext
    {
        public QuoteContext()
            : base("QuizGame")
        {
        }

        public DbSet<Quote> Quotes { get; set; }
    }

    [Table("tblQuote")]
    public class Quote
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int QuoteID { get; set; }
        public int GameMode { get; set; }
        public string QuoteText { get; set; }
    }

    public class QuizModel
    {
        [Required]
        public string QuoteText { get; set; }
        public int GameMode { get; set; }
        public List<Answer> Answers { get; set; }
    }
}