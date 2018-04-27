using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int ExamId { get; set; }
        [DataMember]
        public string AnswerStr { get; set; }
        [DataMember]
        public int Score { get; set; }
    }
}
