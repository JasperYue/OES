using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Num { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ItemA { get; set; }
        [DataMember]
        public string ItemB { get; set; }
        [DataMember]
        public string ItemC { get; set; }
        [DataMember]
        public string ItemD { get; set; }
        public int ReferMark { get; set; }
        [DataMember]
        public int Answer { get; set; }
        public int DelMark { get; set; }
    }
}
