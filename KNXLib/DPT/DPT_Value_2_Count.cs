using System;

namespace KNXLib.DPT
{
	public class DPT_Value_2_Count : IDpt
	{
		public DPT_Value_2_Count ()
		{
		}

		#region IDpt implementation

		public object fromDPT (byte[] data)
		{
			if ((data [1] & 0x80) != 0) {
				return -((data [1] & 0x7f) << 8 + data [0]);
			} else {
				return (short)(data [1] << 8 + data [0]);
			}
		}

		public byte[] toDPT (object val)
		{
			throw new NotImplementedException ();
		}

		public string ID {
			get {
				return "8.001";
			}
		}

		#endregion
	}
}

