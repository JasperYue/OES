using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Tel { get; set; }
        [DataMember]
        public string ImgSrc { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        public int DelMark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
