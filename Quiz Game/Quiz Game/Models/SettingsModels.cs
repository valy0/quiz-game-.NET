using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quiz_Game.Models
{
    public class SettingsContext : DbContext
    {
        public SettingsContext()
            : base("QuizGame")
        {
        }

        public DbSet<Settings> QuizSettings { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
    }

    [Table("tblSettings")]
    public class Settings
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SettingsID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

    [Table("tblGameModes")]
    public class GameMode   
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GameModeID { get; set; }
        public string Mode { get; set; }
    }

    public class SettingsModel
    {
        [Required]
        public int SettingsID { get; set; }

        [Required]
        public int Value { get; set; }
    }
}