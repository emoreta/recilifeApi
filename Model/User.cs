using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace recilife_api.Model
{
    [Table("user")]
    public class User
    {
        [Column("active")]
        public Boolean active { get; set; }
        [Column("bussines_name")]
        public string bussinesname { get; set; }
        [Column("calification")]
        public int calification { get; set; }
        [Column("created")]
        public DateTime created { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("field1")]
        public string field1 { get; set; }
        [Column("field2")]
        public string field2 { get; set; }
        [Column("id")]
        public decimal id { get; set; }
        [Column("id_session_type")]
        public int idsessiontype { get; set; }
        [Column("id_user_type")]
        public int idusertype { get; set; }
        [Column("identification_ruc")]
        public string identificationruc { get; set; }
        [Column("image")]
        public string image { get; set; }
        [Column("last_name")]
        public string lastname { get; set; }
        [Column("mobile_number")]
        public string mobilenumber { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("password")]
        public string password { get; set; }
        [Column("telephone")]
        public string telephone { get; set; }
        [Column("token")]
        public string token { get; set; }
        [Column("updated")]
        public DateTime updated { get; set; }
        [Column("user_id")]
        public string userid { get; set; }
    }
}
