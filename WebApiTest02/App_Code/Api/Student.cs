using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Student 的摘要描述
/// </summary>
/// 
namespace Api
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}