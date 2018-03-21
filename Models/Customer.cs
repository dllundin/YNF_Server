using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YNF_Server.Models
{
    [Serializable]
    public class Customer
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public int ID { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Stateid_ID { get; set; }
        public string Stateid_Type { get; set; }
        public int? Image_ID { get; set; }
        public string Notes { get; set; }
        public DateTime Created_On { get; set; } = DateTime.Now;
        public DateTime Updated_On { get; set; } = DateTime.Now;
    }
}
