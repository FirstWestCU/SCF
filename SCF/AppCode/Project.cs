using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.AppCode
{
    public class Project
    {
        private int id;

        public Project(int id)
        {
            this.id = id;
        }

        public int ID
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Website
        {
            get;
            set;
        }

        public CreditUnion ProposedBy
        {
            get;
            set;
        }
    }
}