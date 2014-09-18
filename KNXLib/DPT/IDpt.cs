using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNXLib.DPT
{
    public interface IDpt
    {
        string ID
        {
            get;
        }

        object fromDPT(byte[] data);
        byte[] toDPT(object val);
    }
}
