using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("request_recyclable_material")]
    public class Requestrecyclablematerial
    {
        [Column("id")]
        public int id { get; set; }
        [Column("id_recyclable_material")]
        public int idrecyclablematerial { get; set; }
        [Column("id_request")]
        public decimal idrequest { get; set; }
    }
}
