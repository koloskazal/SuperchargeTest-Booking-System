using DbConnection.Resources;

namespace SuperchargeTestApi.db.Supercharge.Domain.DbServices
{
    public interface IUserService
    {
        Task<UserResource> AddUserAsync(UserResource createUserResource);
        Task<List<UserResource>> GetAllUsersAsync();
        Task<UserResource> GetUserResourceByIdAsync(string userId);
        Task<UserResource> UpdateUserAsync(string userId, UserResource updateUserResource);
    }
}
