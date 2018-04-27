using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;
using Model;
using System;

namespace Dao
{
    public class UserDaoImpl : IUserDao
    {
        User IUserDao.VerifyUserLogOn(string userName)
        {
            DataSet ds = SqlHelper.ExecuteDataSetProcedure("procVerifyUserLogin", new SqlParameter("@Username", userName));
            List<User> userList = SqlHelper.PutAllVal(new User(), ds);
            User user = null;
            if (userList.Count != 0)
            {
                user = userList[0];
            }
            return user;
        }

        string IUserDao.GetUserImageSrc(int userId)
        {
            string imgSrc = string.Empty;
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter(Constants.DB_TAB, "[user]");
            param[1] = new SqlParameter(Constants.DB_FIELD, "[img_src]");
            param[2] = new SqlParameter(Constants.DB_WHERE, "id = " + userId);
            object obj = SqlHelper.ExecuteScalarprocedure("procGetSingleObject", param);

            if (obj != null && obj != DBNull.Value)
            {
                imgSrc = obj.ToString();
            }
            return imgSrc;
        }

        bool IUserDao.SaveFilePath(string filePath, int userId)
        {
            int size = SqlHelper.ExecteNonQueryProcedure("procUploadFilePath", new SqlParameter("@FilePath", filePath), new SqlParameter("@UserId", userId));
            return size == -1;
        }
    }
}