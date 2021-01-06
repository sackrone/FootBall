using System.Collections.Generic;

namespace FootBall.Web.Data.Entities
{
    public class TypeSessionEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SessionEntity> Sessions { get; set; }
    }
}
