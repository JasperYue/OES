using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace DI
{
    [MessageContract]
    public class FileUploadData
    {
        [MessageHeader]
        public int UserId { get; set; }
        [MessageHeader]
        public string FileName { get; set; }
        [MessageHeader]
        public int FileSize { get; set; }
        [MessageHeader]
        public string FileUniqueID { get; set; }
        [MessageBodyMember]
        public Stream FileData { get; set; }
    }
}
