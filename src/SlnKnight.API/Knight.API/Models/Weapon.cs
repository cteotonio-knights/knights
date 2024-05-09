using MongoDB.Bson.Serialization.Attributes;

namespace Knight.API.Models
{
    public class Weapon
    {
        [BsonElement("name")]
        public string name { get; set; }
        
        [BsonElement("mod")]
        public int Mod { get; set; }

        [BsonElement("attr")]
        public string attr { get; set; }
        
        [BsonElement("equipped")]
        public bool equipped { get; set; }
    }
}
