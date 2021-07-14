using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTCPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(myTCPClientcs1.msg));
            }
            else
            {
                textBox4.Text=myTCPClientcs1.readData;
            }
         
            //myTCPClientcs1.msg(textBox4.Text);
            //textBox4.Text = myTCPClientcs1.incomingText;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //myTCPClientcs1.clickConncet = true;
            myTCPClientcs1.Start(true,e);
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            myTCPClientcs1.IPtext = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            myTCPClientcs1.portText = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //myTCPClientcs1.clickSend = true;
            myTCPClientcs1.Send(true,textBox3.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
           // myTCPClientcs1.sendText = textBox3.Text;
        }
    }
}
