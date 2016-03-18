using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using SMSPIManager.Controller;
using System.Diagnostics;

namespace SMSPIManager
{
    public partial class Form1 : MetroForm
    {
        private Welcome_controller controller;
        public Form1()
        {
            controller = new Welcome_controller(this);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            controller.addMobile(textboxAddMobile.Text);
        }

        private void textboxMobileNumbers_Click(object sender, EventArgs e)
        {

        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            String numbers = textboxMobileNumbers.Text;
            String message = textboxMessage.Text;

            if(String.IsNullOrEmpty(numbers) || String.IsNullOrEmpty(message))
            {
                textboxStatus.Text += "Error: Number field & message can't be empty!\r\n";
                return;
            }

            controller.sendMessage(numbers, message);
        }

        private void buttonToggle_CheckedChanged(object sender, EventArgs e)
        {
            if(buttonToggle.Checked == true)
            {
                controller.start();
            }
            else
            {
                controller.stop();
            }
        }

        private void buttonLogs_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "D:\\sms-log.txt";
            p.Start();
        }
    }
}
