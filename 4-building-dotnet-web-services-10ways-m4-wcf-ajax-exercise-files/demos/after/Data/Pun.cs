using System;
using System.Runtime.Serialization;

namespace Data
{
    [Serializable]
    [DataContract]
    public class Pun
    {
        [DataMember(IsRequired=true)]
        public int PunID { get; set; }
        [DataMember(IsRequired = true)]
        public string Title { get; set; }
        [DataMember(IsRequired = true)]
        public string Joke { get; set; }
    }
}