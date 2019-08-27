using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL
{
    public sealed class AuthSL
    {
        private readonly static AuthSL _instance = new AuthSL();

        private AuthSL()
        {
        }

        public static AuthSL Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}
