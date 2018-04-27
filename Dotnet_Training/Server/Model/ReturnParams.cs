using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Model
{
    [DataContract]
    [KnownType(typeof(ExamList))]
    [KnownType(typeof(ExamResult))]
    [KnownType(typeof(Attendance))]
    public class ReturnParams<T>
    {
        [DataMember]
        public int TotalItem { get; set; }
        [DataMember]
        public List<T> Result { get; set; }
    }
}
