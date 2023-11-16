using CurrentAccountAPI.Domain.Entity;
using CurrentAccountAPI.Domain.Entity;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CurrentAccountAPI.Domain.Entity
{
    public class ActivityLog
    {
        [BsonElement("_id")]
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        public object? Original { get; private set; }
        public object? Modified { get; set; }
        public DateTime DateTime { get; set; }
        public ActivityLogStatus Status { get; private set; }
        public Guid UserId { get; private set; }        

        [JsonConstructor]
        public ActivityLog(object? original, object? modified)
        {
            Original = original;
            Modified = modified;
        }

        public static ActivityLog Create(object modified, Guid userId) => 
            new(null, modified) { Id = Guid.NewGuid(), DateTime = DateTime.UtcNow, UserId = userId, Status = ActivityLogStatus.Created };

        public static ActivityLog Update(object original, object modified, Guid userId) =>
            new(original, modified) { Id = Guid.NewGuid(), DateTime = DateTime.UtcNow, UserId = userId, Status = ActivityLogStatus.Modified };

        public static ActivityLog Remove(object original, Guid userId) =>
            new(original, null) { Id = Guid.NewGuid(), DateTime = DateTime.UtcNow, UserId = userId, Status = ActivityLogStatus.Removed };
    }
}
