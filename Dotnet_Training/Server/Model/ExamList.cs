using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class ExamList
    {
        [DataMember(Order = 0)]
        public int Rownum { get; set; }
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public string Num { get; set; }
        [DataMember(Order = 4)]
        public DateTime EffectiveTime { get; set; }
        [DataMember(Order = 5)]
        public int Duration { get; set; }
        [DataMember(Order = 6)]
        public int PassCriteria { get; set; }
        [DataMember(Order = 7)]
        public string Score { get; set; }
        [DataMember(Order = 8)]
        public string Status { get; set; }
    }
}
