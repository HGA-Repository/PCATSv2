using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class GlobalVar
    {
        /// Static value protected by access routine.
      
        static int _globalValue;

       
        /// Access routine for global variable.
      
        public static int GlobalValue
        {
            get
            {
                return _globalValue;
            }
            set
            {
                _globalValue = value;
            }
        }
              

    }
}
