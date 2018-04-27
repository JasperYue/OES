using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class PassPageParams
    {
        [DataMember]
        public int PageNo { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public string StrWhere { get; set; }
        [DataMember]
        public string Sort { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}
