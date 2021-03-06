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
        internal KNXSenderRouting(KNXConnectionRouting connection, IList<UdpClient> udpClients, IPEndPoint localEndpoint, IPEndPoint remoteEndpoint)
            : base(connection)
        {
            this.LocalEndpoint = localEndpoint;
            this.RemoteEndpoint = remoteEndpoint;
            this.UdpClients = udpClients;
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

        private IPEndPoint _localEndpoint;
        private IPEndPoint LocalEndpoint
        {
            get
            {
                return this._localEndpoint;
            }
            set
            {
                this._localEndpoint = value;
            }
        }

        private IList<UdpClient> _udpClients;
        private IList<UdpClient> UdpClients
        {
            get
            {
                return this._udpClients;
            }
            set
            {
                this._udpClients = value;
            }
        }
        #endregion

        #region send
        internal override void SendData(byte[] dgram)
        {
            foreach (UdpClient client in this.UdpClients)
            {
                client.Send(dgram, dgram.Length, RemoteEndpoint);
            }
        }
        #endregion

        #region datagram processing
        internal override byte[] CreateActionDatagram(string destination_address, byte[] data)
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

            return base.CreateActionDatagramCommon(destination_address, data, dgram);
        }
        #endregion

        #region request status datagram processing
        internal override byte[] CreateRequestStatusDatagram(string destination_address)
        {
            // TODO: Test this

            // HEADER
            byte[] dgram = new byte[17];
            dgram[00] = 0x06;
            dgram[01] = 0x10;
            dgram[02] = 0x05;
            dgram[03] = 0x30;
            dgram[04] = 0x00;
            dgram[05] = 0x11;

            return base.CreateRequestStatusDatagramCommon(destination_address, dgram, 6);
        }
        #endregion
    }
}
