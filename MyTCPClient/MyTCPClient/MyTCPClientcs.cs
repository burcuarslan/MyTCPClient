using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MyTCPClient
{
    public partial class MyTCPClientcs : Component
    {
     
        TcpClient client = new TcpClient();
        NetworkStream networkStream = default(NetworkStream);

        public string readData = null;
        public string IPtext;
        public string portText;
        public string sendText;
        public string incomingText;
        public bool clickConncet;
        public bool clickSend;
        public MyTCPClientcs()
        {
            InitializeComponent();
        }

        public MyTCPClientcs(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void Start(bool clickConncet, EventArgs e)
        {
            try
            {
                if (clickConncet == true)
                {
                    client.Connect(IPtext, Int32.Parse(portText));
                    Thread thread = new Thread(getMessage);
                    thread.Start();
                }
            }
            catch(Exception ex)
            {
                
            }
            
             
           
        }
        public void getMessage()
        {
            string returnData;
            while (true)
            {
                networkStream = client.GetStream();
                var buffsize = client.ReceiveBufferSize;
                byte[] inStream = new byte[buffsize];

                networkStream.Read(inStream, 0, buffsize);
                returnData = System.Text.Encoding.ASCII.GetString(inStream);
                readData = returnData;
                msg();
                
            }
        }
        public void msg() 
        {

        }
        public void Send(bool clickSend,string texts)
        {
            if (clickSend==true)
            {
                byte[] outstream = Encoding.ASCII.GetBytes(texts);
                
                networkStream.Write(outstream, 0, outstream.Length);
                networkStream.Flush();
            }
           
        }
    }
}
