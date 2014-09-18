using System;

namespace KNXLib.DPT
{
	public class DPT_Scaling : IDpt
	{
		public DPT_Scaling ()
		{
		}

		#region IDpt implementation

		public object fromDPT (byte[] data)
		{
			return (byte)(data[0]/255);
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
				return "5.001";
			}
		}

		#endregion
	}
}

