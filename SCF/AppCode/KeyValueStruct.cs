using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop
{
    public struct KeyValueStruct
    {
        private int _key;
        private int _val;

        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }
        public int Value
        {
            get { return _val; }
            set { _val = value; }
        }

        public KeyValueStruct(int key, int value)
        {
            _key = key;
            _val = value;
        }
    }
}