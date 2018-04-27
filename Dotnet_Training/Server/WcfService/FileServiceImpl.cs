using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dao;
using System.Drawing;
using System.IO;
using CustomException;
using Common;
using System.Threading;
using System.ServiceModel;
using DI;

namespace WcfService
{
    // support all clients upload file
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class FileServiceImpl : IFileService
    {
        private IUserDao userDao = new UserDaoImpl();

        private const int bufferLen = 4096;
        private static Dictionary<string, int> progressRecord = new Dictionary<string, int>(); // Save file upload progress
        private static object lockObj = new object(); // Use as a lock to protected resource can be accessed safety

        public FileServiceImpl()
        {

        }

        void IFileService.UploadFile(FileUploadData data)
        {
            if (data != null)
            {
                string fileName = data.FileName;
                Stream sourceStream = data.FileData;

                // Pass 1: whether stream is valid or not
                if (!sourceStream.CanRead)
                {
                    throw new Exception("Invalid File!");
                }
                // Pass 2: file size must be less than 5M
                if (data.FileSize > 1024 * 1024 * 5) // 5M
                {
                    throw new ServiceException("FileSize exceed, at most 5 M");
                }
                // Pass 3: whether save picture directory is exist or not
                if (!Directory.Exists(ApplicationUtil.IMAGE_DIR))
                {
                    Directory.CreateDirectory(ApplicationUtil.IMAGE_DIR);
                }
                // Pass 4: Start to upload file
                string filePath = Path.Combine(ApplicationUtil.IMAGE_DIR, fileName);
                using (FileStream targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //read from the input stream in 4K chunks
                    //and save to output stream  const int bufferLen = 4096;
                    byte[] buffer = new byte[bufferLen];
                    int count = 0;
                    SetFileUploadInfo(data.FileUniqueID, 0);
                    while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                    {
                        targetStream.Write(buffer, 0, count);
                        if (data.FileSize - (int)targetStream.Length > 100000)
                        {
                            SetFileUploadInfo(data.FileUniqueID, (int)targetStream.Length);
                        }
                    }
                    SetFileUploadInfo(data.FileUniqueID, data.FileSize);
                    sourceStream.Close();
                }  

                bool flag = userDao.SaveFilePath(data.FileName, data.UserId);

                if (!flag)
                {
                    throw new ServiceException("Upload File Failed");
                }
            }
        }

        void SetFileUploadInfo(string id, int savedFileCount)
        {
            lock (lockObj)
            {
                if (progressRecord.ContainsKey(id))
                {
                    progressRecord[id] = savedFileCount;
                }
                else
                {
                    progressRecord.Add(id, savedFileCount);
                }
            }
        }

        int IFileService.GetUploadFileInfo(string id)
        {
            if (progressRecord.ContainsKey(id))
            {
                return progressRecord[id];
            }
            else
            {
                return 0;
            }
        }

        Bitmap IFileService.GetUserIcon(int userId)
        {
            string filePath = userDao.GetUserImageSrc(userId);

            if (string.IsNullOrEmpty(filePath) || !File.Exists(Path.Combine(ApplicationUtil.IMAGE_DIR, @"\" + filePath)))
            {
                throw new ServiceException("User do not have custom image");
            }

            return new Bitmap(Path.Combine(ApplicationUtil.IMAGE_DIR, @"\" + filePath));
        }
    }
}
