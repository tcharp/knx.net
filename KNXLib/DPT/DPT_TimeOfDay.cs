using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNXLib.DPT
{
    public class DPT_TimeOfDay : IDpt
    {
        public string ID
        {
            get
            {
                return "10.001";
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
            int seconds = data[2] & Convert.ToInt32("00111111", 2);
            int minutes = data[1] & Convert.ToInt32("00111111", 2);
            int hours = data[0] & Convert.ToInt32("00011111", 2);

            DateTime t = DateTime.Now;
            return new DateTime(t.Year, t.Month, t.Day, hours, minutes, seconds);
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
