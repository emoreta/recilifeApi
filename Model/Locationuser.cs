using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("location_user")]
    public class Locationuser
    {
        [Column("active")]
        public Boolean active { get; set; }
        [Column("created")]
        public DateTime created { get; set; }
        [Column("description")]
        public string description { get; set; }
        [Column("id")]
        public decimal id { get; set; }
        [Column("latitude")]
        public string latitude { get; set; }
        [Column("longitude")]
        public string longitude { get; set; }
        [Column("reference")]
        public string reference { get; set; }
    }
}
