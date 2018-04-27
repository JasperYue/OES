using Common;
using CustomException;
using Dao;
using Model;

namespace WcfService
{
    public class UserServiceImpl : IUserService
    {
        private IUserDao userDao = new UserDaoImpl();

        public UserServiceImpl()
        {

        }

        public UserServiceImpl(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        User IUserService.VerifyUserLogOn(string userName, string password)
        {
            User user = userDao.VerifyUserLogOn(userName);

            if (user == null)
            {
                throw new ServiceException(Constants.USER_NOT_EXIST);
            }
            else if (!password.Equals(user.Password))
            {
                throw new ServiceException(Constants.PASSWORD_NOT_CORRENT);
            }
            return user;
        }
    }
}
