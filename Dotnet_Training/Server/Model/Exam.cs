using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Exam
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Num { get; set; }
        [DataMember]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataMember]
        public int SingleScore { get; set; }
        [DataMember]
        public int TotalScore { get; set; }
        [DataMember]
        public int PassCriteria { get; set; }
        public int NeedQuantity { get; set; }
        [DataMember]
        public int FactQuantity { get; set; }
        [DataMember]
        public DateTime EffectiveTime { get; set; }
        [DataMember]
        public int Duration { get; set; }
        public string Creator { get; set; }
        [DataMember]
        public string AnswerStr { get; set; }
        [DataMember]
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
