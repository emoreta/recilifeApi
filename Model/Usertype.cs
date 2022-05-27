using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("user_type")]
    public class Usertype
    {
        [Column("description")]
        public string description { get; set; }
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
    }
}
