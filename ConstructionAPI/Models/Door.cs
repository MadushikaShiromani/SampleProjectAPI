using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Models
{
    public class Door
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string Project_Id { get; set; }
        public string Door_Name { get; set; }
        public string Room_Name { get; set; }
        public string Building_Name { get; set; }
        public string Foor_Name { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public Lock Lock { get; set; }
        public Cylinder Cylinder { get; set; }
        public Frame Frame { get; set; }
        public Boolean Done { get; set; }
        public string Project_Name { get; set; }

    }

}
