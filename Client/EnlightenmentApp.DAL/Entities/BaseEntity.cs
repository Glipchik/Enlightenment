using EnlightenmentApp.DAL.Interfaces.Entities;

namespace EnlightenmentApp.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public virtual int Id {  get; set; }
    }
}
