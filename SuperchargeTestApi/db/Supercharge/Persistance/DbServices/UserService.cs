using DbConnection.CustomExceptions;
using DbConnection.db.Supercharge.Domain.DbRepositories;
using DbConnection.db.Supercharge.Model;
using DbConnection.Resources;
using DbConnection.Singleton;
using DbConnection.Tools;
using DbConnection.Tools.ResourceTools;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.db.Supercharge.Persistance.DbServices
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<List<UserResource>> GetAllUsersAsync()
        {
            try
            {
                List<User> userList = await userRepository.GetListAsync(u => u.IsActive,
                                                                        u => u.CreatedByNavigation,
                                                                        u => u.ModifiedByNavigation);

                List<UserResource> userResourceList = MapperStorage.Mapper.Map<List<UserResource>>(userList);
                return userResourceList;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<UserResource> GetUserResourceByIdAsync(string userId)
        {
            try
            {
                User user = await GetUserByIdAsync(userId);
                UserResource userResource = MapperStorage.Mapper.Map<UserResource>(user);
                return userResource;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<User> GetUserByIdAsync(string userId)
        {
            int userIdInt = IntTools.GetId(userId, errorMessage: "Invalid userid");
            User user = await userRepository.GetFirstOrDefaultAsync(u => u.UserId == userIdInt);
            return user;
        }

        public async Task<UserResource> AddUserAsync(UserResource createUserResource)
        {
            try
            {
                UserResourceTools.CleaningUserResource(createUserResource);
                bool _1 = await ValidateAddUserOperationAsync(createUserResource);
                User user = MapperStorage.Mapper.Map<User>(createUserResource);
                User _2 = await userRepository.InsertAsync(user);
                UserResource userResource = MapperStorage.Mapper.Map<UserResource>(user);
                return userResource;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<bool> ValidateAddUserOperationAsync(UserResource createUserResource)
        {
            bool exists = await userRepository
                        .ExistsAsync(u => u.Email.Trim().ToLower() == createUserResource.Email);
            if (exists)
            {
                throw new EntityAlreadyExistsException("User already exists.");
            }
            return true;
        }

        public async Task<UserResource> UpdateUserAsync(string userId, UserResource updateUserResource)
        {
            UserResourceTools.CleaningUserResource(updateUserResource);
            User user = await GetUserByIdAsync(userId)
                ?? throw new InvalidOperationException("User doesn't exists.");
            bool _ = await ValidateEditUserOperationAsync(updateUserResource, user);
            user = MapperStorage.Mapper.Map(updateUserResource, user);
            User updatedUser = await userRepository.UpdateAsync(user);
            UserResource userResource = MapperStorage.Mapper.Map<UserResource>(updatedUser);
            return userResource;
        }

        private async Task<bool> ValidateEditUserOperationAsync(UserResource updateUserResource, User user)
        {
            if (updateUserResource.Email.ToLowerTrim() == user.Email)
            {
                return true;
            }
            bool exist = await userRepository.ExistsAsync(u => u.Email.ToLower().Trim() == updateUserResource.Email
                                                          && u.UserId != user.UserId);
            if (exist)
            {
                throw new EntityAlreadyExistsException("Email already exists.");
            }
            return true;
        }
    }
}
