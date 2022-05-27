using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("schedule")]
    public class Schedule
    {
        [Column("active")]
        public Boolean active { get; set; }
        [Column("description")]
        public string description { get; set; }
        [Column("id")]
        public int id { get; set; }
        [Column("id_day")]
        public int idday { get; set; }
        [Column("id_user")]
        public decimal iduser { get; set; }
    }
}
