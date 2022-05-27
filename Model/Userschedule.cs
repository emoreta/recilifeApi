using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("user_schedule")]
    public class Userschedule
    {
        [Column("id")]
        public int id { get; set; }
        [Column("id_schedule")]
        public int idschedule { get; set; }
        [Column("id_user")]
        public decimal iduser { get; set; }
    }
}
