using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Attendance
    {
        [DataMember]
        public int Rownum { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int PassCriteria { get; set; }
        [DataMember]
        public string Score { get; set; }
        [DataMember]
        public string Result { get; set; }
    }
}
