﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace KNXLib
{
    internal class KNXSenderRouting : KNXSender
    {
        #region constructor
        internal KNXSenderRouting(KNXConnectionRouting connection, UdpClient udpClient, IPEndPoint remoteEndpoint)
            : base(connection)
        {
            this.RemoteEndpoint = remoteEndpoint;
            this.UdpClient = udpClient;
        }
        #endregion

        #region variables
        private IPEndPoint _remoteEndpoint;
        private IPEndPoint RemoteEndpoint
        {
            get
            {
                return this._remoteEndpoint;
            }
            set
            {
                this._remoteEndpoint = value;
            }
        }

        private UdpClient _udpClient;
        private UdpClient UdpClient
        {
            get
            {
                return this._udpClient;
            }
            set
            {
                this._udpClient = value;
            }
        }
        #endregion

        #region send
        internal override void SendData(byte[] dgram)
        {
            UdpClient.Send(dgram, dgram.Length, RemoteEndpoint);
        }
        #endregion

        #region datagram processing
        internal override byte[] CreateDatagram(string destination_address, byte[] data)
        {
            int data_length = KNXHelper.GetDataLength(data);
            // HEADER
            byte[] dgram = new byte[6];
            dgram[0] = 0x06;
            dgram[1] = 0x10;
            dgram[2] = 0x05;
            dgram[3] = 0x30;
            byte[] total_length = BitConverter.GetBytes(data_length + 16);
            dgram[4] = total_length[1];
            dgram[5] = total_length[0];

            return base.CreateDatagram(destination_address, data, dgram);
        }
        #endregion
    }
}
