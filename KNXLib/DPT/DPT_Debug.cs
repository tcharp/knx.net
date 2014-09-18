using System;

namespace KNXLib.DPT
{
	public class DPT_Debug : IDpt
	{
		public DPT_Debug ()
		{
		}

		#region IDpt implementation

		public object fromDPT (byte[] data)
		{
			string result = string.Empty;

			foreach (byte b in data) {
				result += string.Format ("{0:X2}", b);
			}

			return result;
		}

		public byte[] toDPT (object val)
		{
			throw new NotImplementedException ();
		}

		public string ID {
			get {
				return "0.000";
			}
		}

		#endregion
	}
}

