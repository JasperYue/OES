using Model;

namespace Dao
{
    public interface IUserDao
    {
        /// <summary>
        /// Get User by userName
        /// </summary>
        /// <param name="userName">User input</param>
        /// <returns></returns>
        User VerifyUserLogOn(string userName);
        /// <summary>
        /// Get user image src from DB
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns>ImgSrc relative location string</returns>
        string GetUserImageSrc(int userId);
        /// <summary>
        /// Save user image file path
        /// </summary>
        /// <param name="filePath">File relative path string</param>
        /// <param name="userId">UserId</param>
        /// <returns>Successful or not</returns>
        bool SaveFilePath(string filePath, int userId);
    }
}
