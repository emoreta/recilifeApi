using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("user_location")]
    public class Userlocation
    {
        [Column("active")]
        public Boolean active { get; set; }
        [Column("id")]
        public decimal id { get; set; }
        [Column("id_location")]
        public decimal idlocation { get; set; }
        [Column("id_user")]
        public decimal iduser { get; set; }
    }
}
