using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectNoName.Entities;

namespace ProjectNoName.Business.Abstract
{
    public interface IRelationShipService : IBaseService<RelationShip>
    {
        Task<bool> Follow(RelationShip relation);
        Task<bool> UnFollow(RelationShip relation);
        Task<bool> Block(RelationShip relation);
    }
}
