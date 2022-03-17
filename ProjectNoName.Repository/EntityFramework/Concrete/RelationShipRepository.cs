using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Data.Concrete;
using ProjectNoName.Repository.EntityFramework.Context;
using ProjectNoName.Repository.EntityFramework.Abstract;
using ProjectNoName.Entities;

namespace ProjectNoName.Repository.EntityFramework.Concrete
{
    public class RelationShipRepository : EfBaseRepository<RelationShip>,IRelationShipRepository
    {
        public RelationShipRepository(DataContext context) : base(context)
        {
        }
        
    }
}
