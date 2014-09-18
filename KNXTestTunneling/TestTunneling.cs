using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace KNXTest
{
    class TestTunneling
    {
        private static KNXLib.KNXConnection connection = null;

        static void Main(string[] args)
        {
            connection = new KNXLib.KNXConnectionTunneling("10.0.11.33", 3671, "0.0.0.0", 3671);
            connection.Debug = true;
            connection.Connect();
            connection.KNXConnectedDelegate += new KNXLib.KNXConnection.KNXConnected(Connected);
            connection.KNXDisconnectedDelegate += new KNXLib.KNXConnection.KNXDisconnected(Disconnected);
            connection.KNXEventDelegate += new KNXLib.KNXConnection.KNXEvent(Event);
            connection.KNXStatusDelegate += new KNXLib.KNXConnection.KNXStatus(Status);

            Console.WriteLine("Done. Press [ENTER] to finish");
            Console.Read();
            connection.KNXDisconnectedDelegate -= new KNXLib.KNXConnection.KNXDisconnected(Disconnected);
            connection.Disconnect();
            System.Environment.Exit(0);
        }

		static void Event(string address, byte[] state)
		{
			if (address.Equals ("1/2/1") || address.Equals ("1/2/2")) {
				Console.WriteLine ("New Event: device " + address + " has status (" + state + ") --> " + connection.fromDPT ("9.001", state));
			} else if (
				address.Equals ("1/2/3") ||
				address.Equals ("1/2/4") ||
				address.Equals ("1/2/5") ||
				address.Equals ("1/2/5") ||
				address.Equals ("1/2/6") ||
				address.Equals ("1/2/7") ||
				address.Equals ("1/2/8") ||
				address.Equals ("1/2/9") ||
				address.Equals ("1/2/10") ||
				address.Equals ("1/2/11") ||
				address.Equals ("1/2/12") ||
				address.Equals ("1/2/13") ||
				address.Equals ("1/2/14") ||
				address.Equals ("1/2/15") ||
				address.Equals ("1/2/16") ||
				address.Equals ("1/2/17") ||
				address.Equals ("1/2/18")) {
				string data = string.Empty;

				if (state.Length == 1) {
					data = ((byte)state [0]).ToString ();
				} else {
					byte[] bytes = new byte[state.Length];
					for (int i = 0; i < state.Length; i++) {
						bytes [i] = System.Convert.ToByte (state [i]);
					}
					for (int i = 0; i < state.Length; i++) {
						data += state [i].ToString ();
					}
				}

				Console.WriteLine ("New Event: device " + address + " has status (" + state + ") --> " + data);
			}
			else if ("4/1/1".Equals (address)) {
				Console.WriteLine("Received some bytes: {0}", state.Length);
				Console.WriteLine ("Time: {0}", connection.fromDPT ("10.001", state));
			}
			else if ("4/1/2".Equals (address)) {
				Console.WriteLine("Received some bytes: {0}", state.Length);
				Console.WriteLine ("Date: {0}", connection.fromDPT ("11.001", state));
			}
			else if ("4/1/16".Equals (address)) {
				Console.WriteLine("Received some bytes: {0}", state.Length);
				Console.WriteLine ("Angle: {0}", connection.fromDPT ("9.001", state));
			}
			else if ("4/1/15".Equals (address)) {
				Console.WriteLine("Received some bytes: {0}", state.Length);
				Console.WriteLine ("Angle: {0}", connection.fromDPT ("9.001", state));
			}

			Console.WriteLine ("event received: address:{0} event:{1}", address, state);
		}

		static void Status(string address, byte[] state)
        {
            Console.WriteLine("New Status: device " + address + " has status " + state);
        }

        static void Connected()
        {
            Console.WriteLine("Connected!");
        }

        static void Disconnected()
        {
            Console.WriteLine("Disconnected! Reconnecting");
            if (connection != null)
            {
                Thread.Sleep(1000);
                connection.Connect();
            }
        }
    }
}
