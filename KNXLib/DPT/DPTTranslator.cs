using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNXLib.DPT
{
    public class DPTTranslator
    {
        #region Singleton
        private static readonly DPTTranslator instance = new DPTTranslator();

        private DPTTranslator()
        {
            this.Initialize();
        }

        public static DPTTranslator Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        private IDictionary<string, IDpt> dpts = new Dictionary<string, IDpt>();

        private void Initialize()
        {
            IDpt dpt;

            dpt = new DPTTemperature();
            dpts.Add(dpt.ID, dpt);

            dpt = new DPT_TimeOfDay();
            dpts.Add(dpt.ID, dpt);

            dpt = new DPT_Date();
            dpts.Add(dpt.ID, dpt);

            dpts.Add("1.001", new DPT_Switch());
        }

        public object fromDPT(string type, byte[] data)
        {
            try
            {
                if (dpts.ContainsKey(type))
                {
                    IDpt dpt = dpts[type];
                    return dpt.fromDPT(data);
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public object fromDPT(string type, String data)
        {
            try
            {
                if (dpts.ContainsKey(type))
                {
                    IDpt dpt = dpts[type];
                    return dpt.fromDPT(data);
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public byte[] toDPT(string type, object value)
        {
            try
            {
                if (dpts.ContainsKey(type))
                {
                    IDpt dpt = dpts[type];
                    return dpt.toDPT(value);
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public byte[] toDPT(string type, String value)
        {
            try
            {
                if (dpts.ContainsKey(type))
                {
                    IDpt dpt = dpts[type];
                    return dpt.toDPT(value);
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
