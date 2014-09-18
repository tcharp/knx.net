using System;

namespace KNXLib.DPT
{
	public class DPT_Value_2_Ucount : IDpt
	{
		public DPT_Value_2_Ucount ()
		{
		}

		#region IDpt implementation

		public object fromDPT (byte[] data)
		{
			return (ushort) (data[1] << 8 + data[0]);
		}

		public object fromDPT (string data)
		{
			throw new NotImplementedException ();
		}

		public byte[] toDPT (object val)
		{
			throw new NotImplementedException ();
		}

		public byte[] toDPT (string value)
		{
			throw new NotImplementedException ();
		}

		public string ID {
			get {
				return "7.001";
			}
		}

		#endregion
	}
}

