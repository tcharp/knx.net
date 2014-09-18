using System;

namespace KNXLib.DPT
{
	public class DPT_Angle : IDpt
	{
		public DPT_Angle ()
		{
		}

		#region IDpt implementation

		public object fromDPT (byte[] data)
		{
			return (int)data[0]*1.4f;
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
				return "5.003";
			}
		}

		#endregion
	}
}

