using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class ExamResult
    {
        [DataMember(Order = 0)]
        public int Rownum { get; set; }
        [DataMember(Order = 1)]
        public int ExamId { get; set; }
        [DataMember(Order = 2)]
        public string ExamName { get; set; }
        [DataMember(Order = 3)]
        public string Num { get; set; }
        [DataMember(Order = 4)]
        public DateTime EffectiveTime { get; set; }
        [DataMember(Order = 5)]
        public int FactQuantity { get; set; }
        [DataMember(Order = 6)]
        public float AverageScore { get; set; }
        [DataMember(Order = 7)]
        public int ExamineeCount { get; set; }
        [DataMember(Order = 8)]
        public int QualifiedNum { get; set; }
        [DataMember(Order = 9)]
        public string PassRate { get; set; }
    }
}
