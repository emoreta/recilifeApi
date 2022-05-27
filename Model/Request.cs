using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("request")]
    public class Request
    {
        [Column("amount")]
        public decimal amount { get; set; }
        [Column("calification")]
        public int calification { get; set; }
        [Column("commentary")]
        public string commentary { get; set; }
        [Column("created")]
        public DateTime created { get; set; }
        [Column("distance")]
        public string distance { get; set; }
        [Column("id")]
        public decimal id { get; set; }
        [Column("id_state")]
        public int idstate { get; set; }
        [Column("id_state_recycler")]
        public int idstaterecycler { get; set; }
        [Column("id_user_recycler")]
        public decimal iduserrecycler { get; set; }
        [Column("id_user_request")]
        public decimal iduserrequest { get; set; }
        [Column("updated")]
        public DateTime updated { get; set; }
    }
}
