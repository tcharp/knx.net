using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNXLib.DPT
{
    public class DPT_Switch : IDpt
    {
        public string ID
        {
            get
            {
                return "1.001";
            }
        }

        public object fromDPT(string data)
        {
            byte[] dataConverted = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dataConverted[i] = (byte)data[i];
            }
            return fromDPT(dataConverted);
        }

        public object fromDPT(byte[] data)
        {
            int b = data[0] & Convert.ToInt32("00000001", 2);

            return (b == 1);
        }

        public byte[] toDPT(object val)
        {
            return null;
        }

        public byte[] toDPT(String value)
        {
            return toDPT(float.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}
