using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DataPublisher_Project.Model
{
    [Serializable]
    public class StudentModel
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Family
        {
            get;
            set;
        }

        public string Tell
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }
    }
}
