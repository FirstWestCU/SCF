using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop
{
    public class ProjectUpdate
    {
        public int ID
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public DateTime DatePosted
        {
            get;
            set;
        }

        public User PostedBy
        {
            get;
            set;
        }
    }
}