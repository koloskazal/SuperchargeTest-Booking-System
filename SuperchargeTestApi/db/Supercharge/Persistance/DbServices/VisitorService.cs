using DbConnection.CustomExceptions;
using DbConnection.db.Supercharge.Domain.DbRepositories;
using DbConnection.db.Supercharge.Model;
using DbConnection.db.Supercharge.Persistance.DbRepositories;
using DbConnection.Resources;
using DbConnection.Singleton;
using DbConnection.Tools;
using DbConnection.Tools.ResourceTools;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.db.Supercharge.Persistance.DbServices
{
    public  class VisitorService(IVisitorRepository visitorRepository) : IVisitorService
    {
        public async Task<VisitorResource> AddVisitorAsync(VisitorResource createVisitorResource)
        {
            try
            {
                VisitorResourceTools.CleaningVisitorResource(createVisitorResource);
                bool _1 = await ValidateAddVisitorOperationAsync(createVisitorResource);
                Visitor visitor = MapperStorage.Mapper.Map<Visitor>(createVisitorResource);
                Visitor _2 = await visitorRepository.InsertAsync(visitor);
                VisitorResource visitorResource = MapperStorage.Mapper.Map<VisitorResource>(visitor);
                return visitorResource;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<bool> ValidateAddVisitorOperationAsync(VisitorResource createVisitorResource)
        {
            bool exists = await visitorRepository
                        .ExistsAsync(u => u.Email.Trim().ToLower() == createVisitorResource.Email);
            if (exists)
            {
                throw new EntityAlreadyExistsException("Visitor already exists.");
            }
            return true;
        }

        public async Task<List<VisitorResource>> GetAllVisitorsAsync()
        {
            try
            {
                List<Visitor> visitorList = await visitorRepository.GetListAsync(u => u.IsActive);

                List<VisitorResource> visitorResourceList = MapperStorage.Mapper.Map<List<VisitorResource>>(visitorList);
                return visitorResourceList;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<VisitorResource> GetVisitorResourceByIdAsync(string visitorId)
        {
            try
            {
                Visitor visitor = await GetVisitorByIdAsync(visitorId);
                VisitorResource visitorResource = MapperStorage.Mapper.Map<VisitorResource>(visitor);
                return visitorResource;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<Visitor> GetVisitorByIdAsync(string visitorId)
        {
            int visitorIdInt = IntTools.GetId(visitorId, errorMessage: "Invalid visitorId");
            Visitor visitor = await visitorRepository.GetFirstOrDefaultAsync(u => u.VisitorId == visitorIdInt,
                                                                             u=>u.Bookings);
            return visitor;
        }

        public async Task<VisitorResource> UpdateUserAsync(string visitorId, VisitorResource updateVisitorResource)
        {
            VisitorResourceTools.CleaningVisitorResource(updateVisitorResource);
            Visitor visitor = await GetVisitorByIdAsync(visitorId)
                ?? throw new InvalidOperationException("User doesn't exists.");
            bool _ = await ValidateEditVisitorOperationAsync(updateVisitorResource, visitor);
            visitor = MapperStorage.Mapper.Map(updateVisitorResource, visitor);
            Visitor updatedVisitor = await visitorRepository.UpdateAsync(visitor);
            VisitorResource visitorResource = MapperStorage.Mapper.Map<VisitorResource>(updatedVisitor);
            return visitorResource;
        }

        private async Task<bool> ValidateEditVisitorOperationAsync(VisitorResource visitorResource, Visitor visitor)
        {
            if (visitorResource.Email.ToLowerTrim() == visitor.Email)
            {
                return true;
            }
            bool exist = await visitorRepository.ExistsAsync(u => u.Email.ToLower().Trim() == visitorResource.Email
                                                          && u.VisitorId != visitor.VisitorId);
            if (exist)
            {
                throw new EntityAlreadyExistsException("Email already exists.");
            }
            return true;
        }
    }
}
