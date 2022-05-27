using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("calification")]
    public class Calification
    {
        
        [Column("active")]
        public Boolean active { get; set; }
    
        [Column("created")]
        public DateTime created { get; set; }
        [Key]
        [Column("id")]
        public Int32 id { get; set; }

        [Column("punctuation")]
        public Int32 punctuation { get; set; }

        [Column("name")]
        public string name { get; set; }
    }
}
