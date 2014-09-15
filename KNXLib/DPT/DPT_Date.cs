using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNXLib.DPT
{
    public class DPT_Date : IDpt
    {
        public string ID
        {
            get
            {
                return "11.001";
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
            int year = data[2] & Convert.ToInt32("01111111", 2);
            int month = data[1] & Convert.ToInt32("00001111", 2);
            int day = data[0] & Convert.ToInt32("00011111", 2);

            if (year > 90)
            {
                year += 1900;
            }
            else
            {
                year += 2000;
            }

            return new DateTime(year, month, day);
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
