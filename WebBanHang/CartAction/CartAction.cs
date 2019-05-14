using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang.CartAction
{
    interface CartAction
    {
        void CartAction(string type, params int[] payload);
    }
}
