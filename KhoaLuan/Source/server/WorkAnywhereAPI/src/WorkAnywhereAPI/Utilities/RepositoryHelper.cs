using WorkAnywhereAPI.Repository;

namespace WorkAnywhereAPI.Utilities
{
    public static class RepositoryHelper
    {
        /// <summary>
        /// Get display name of user by user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>The display name</returns>
        public static string GetDisplayNameById(string userId)
        {
            var userRepository = new UserRepository();
            return userRepository.GetById(userId).DisplayName == null ? $"@{ userRepository.GetById(userId).UserName}" : userRepository.GetById(userId).DisplayName;
        }
    }
}
