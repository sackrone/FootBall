using System.Collections.Generic;

namespace FootBall.Web.Data.Entities
{
    public class ResultEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GameEntity> Games { get; set; }
    }
}
