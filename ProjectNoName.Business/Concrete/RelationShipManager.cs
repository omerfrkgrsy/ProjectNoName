using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Concrete;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Repository.EntityFramework.Abstract;
using System.Threading.Tasks;
using System.Text;
using System;
using System.Linq;
using System.Globalization;
using ProjectNoName.Business.Dto;
using ProjectNoName.Entities;

namespace ProjectNoName.Business.Concrete
{
    public class RelationShipManager : AbstractDalService<RelationShip>,IRelationShipService
    {
        IRelationShipRepository _relationShipRepository;
        public RelationShipManager(IRelationShipRepository dal) :base(dal)
        {
            _relationShipRepository = dal;
        }

        public async Task<bool> Follow(RelationShip relation)
        {
            return base.Insert(relation)!=null;
        }

        public async Task<bool> UnFollow(RelationShip relation)
        {
            return true;
        }
        public async Task<bool> Block(RelationShip relation)
        {
            relation.isBlocked = true;

            return true;
        }

    }
}
