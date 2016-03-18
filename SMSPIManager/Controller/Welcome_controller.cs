using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using SMSPIManager.Controller.json;


namespace SMSPIManager.Controller
{
    delegate void textBoxStatusDelegate();
    delegate void listboxMobileListDelegate();
    class Welcome_controller
    {
        private Form1 _obj;
        private String port = "1688";
        private Mobile_Status _mobileStatus = new Mobile_Status();
        private Number_Checker _numberChecker = new Number_Checker();
        private Message_Sender _messageSender = new Message_Sender();
        private List<String> _mobileIPList = new List<String>();
        private Queue<String> _pendingMessageQueue = new Queue<String>();
        private TaskFactory _taskFactory = Task.Factory;
        private Web_Check _webCheck = new Web_Check();
        private bool flag = true;
        public Welcome_controller(Object obj)
        {
            _obj = ((Form1)obj);
        }

        public void addMobile(String mobileIP)
        {
            _obj.textboxStatus.Text += "\rChecking " + mobileIP + " status \r\n";
            Task status = Task.Factory.StartNew(() => { checkMobileStatus(mobileIP); });
            
        }

        private void checkMobileStatus(String mobileIP)
        {
            bool status = _numberChecker.check(mobileIP, port);
            mobileOnlineStatus(status, mobileIP);
        }
        private void mobileOnlineStatus(bool status, String mobileIP)
        {
            String s;
            if (status)
            {
                updateListBox(mobileIP);
                s = "Mobile is online\r\n";
            }
            else
                s = "Mobile is offline\r\n";

            if(_obj.textboxStatus.InvokeRequired)
            {
                textBoxStatusDelegate del = new textBoxStatusDelegate(() => { _obj.textboxStatus.Text += s; });
                _obj.textboxStatus.Invoke(del);
            }
        }

        private void updateListBox(String mobileIP)
        {
            _mobileIPList.Add(mobileIP);
            if(_obj.listboxMobileList.InvokeRequired)
            {
                listboxMobileListDelegate del = new listboxMobileListDelegate(() => { _obj.listboxMobileList.Items.Add(mobileIP); });
                _obj.listboxMobileList.Invoke(del);
                
            }
        }


        public void sendMessage(string numbers, string message)
        {
            numbers = numbers.Trim();
            StringBuilder builder = new StringBuilder();
            int i = 1;
            List<List<NumberMessagePackage>> allMobileList = _numberChecker.generateList(numbers, _mobileIPList);
            if(allMobileList == null)
            {
                _obj.textboxStatus.Text += "Check if mobile phone(s) are connected? \r\n";
                return;
            }
            foreach(var l in allMobileList)
            {
                builder.Append("=> " + i + "\r\n");
                    foreach(var ip in l)
                    {
                        builder.Append("\t " + ip.Number + "\r\n");
                    }
                i++;


            }

            var mobiles = _mobileIPList.ToArray();
            int a = 0;
            var numberList = allMobileList.ToArray();
           
           

            foreach(var l in numberList)
            {
                Task.Factory.StartNew(() => { sendMessageAsyc(l, message); });
            }

                _obj.textboxStatus.Text += builder.ToString() + "\r\n";
        }

        public void sendMessageAsyc(List<NumberMessagePackage> numbers, String message)
        {
            bool status;
            foreach(var number in numbers)
            {
                status = _messageSender.SendMessage(number.Number, message, number.IP, port);
                if (status)
                {
                    if (_obj.textboxStatus.InvokeRequired)
                    {
                        textBoxStatusDelegate del = new textBoxStatusDelegate(() => { _obj.textboxStatus.Text += "Sent => " + number.Number + " @ " + DateTime.Now.ToString() + " => " + number.IP + "\r\n"; });
                        _obj.textboxStatus.Invoke(del);
                    }
                }
                else
                {
                    if (_obj.textboxStatus.InvokeRequired)
                    {
                        textBoxStatusDelegate del = new textBoxStatusDelegate(() => { _obj.textboxStatus.Text += "Error => " + number.Number + " @ " + DateTime.Now.ToString() + " => " + number.IP + "\r\n"; });
                        _obj.textboxStatus.Invoke(del);
                    }
                 
                }
                Thread.Sleep(1000);
            }
            
        }

        public void start()
        {
            this.flag = true;
            _taskFactory.StartNew(() => { checkFromApi(); });
            _obj.textboxStatus.Text += "Checking online status \r\n";
        }

        private void checkFromApi()
        {
            while(flag)
            {
                var response = _webCheck.getMessages();
                if (response == null)
                {
                    if (_obj.textboxStatus.InvokeRequired)
                    {
                        textBoxStatusDelegate del = new textBoxStatusDelegate(() => { _obj.textboxStatus.Text += "There is some connection error or server side is not responding." + "\r\n"; });
                        _obj.textboxStatus.Invoke(del);
                    }
                    continue;
                }


                var collectiveList = _numberChecker.generateListForWebClient(response, _mobileIPList);
                if (collectiveList == null)
                {
                    if(_obj.textboxStatus.InvokeRequired)
                    {
                        textBoxStatusDelegate del = new textBoxStatusDelegate(() => { _obj.textboxStatus.Text += "Check if mobile phone(s) are connected? \r\n"; _obj.buttonToggle.Checked = false; });
                        _obj.textboxStatus.Invoke(del);
                    }
                    return;
                }


                foreach (var l in collectiveList)
                {
                    Task.Factory.StartNew(() => { sendMessageOnlineAsyc(l); });
                }

                Thread.Sleep(10000);
            }
        }

        public void sendMessageOnlineAsyc(List<NumberMessagePackageOnline> numbers)
        {
            bool status;
            foreach (var number in numbers)
            {
                status = _messageSender.SendMessage(number.Number, number.Message, number.IP, port);
                if (status)
                {
                    String message = "Sent => " + number.Number + " @ " + DateTime.Now.ToString() + " => " + number.IP + "\r\n";
                    _webCheck.updateMessageStatus(number.Id);
                    if (_obj.textboxStatus.InvokeRequired)
                    {
                        textBoxStatusDelegate del = new textBoxStatusDelegate(() => { _obj.textboxStatus.Text += message; });
                        _obj.textboxStatus.Invoke(del);

                        //using (StreamWriter writer = File.AppendText("D:\\sms-log.txt"))
                        //{
                        //    writer.WriteLine(message);
                        //    writer.Close();
                        //}
                    }

                    
                }
                else
                {

                    String message = "Error => " + number.Number + " @ " + DateTime.Now.ToString() + " => " + number.IP + "\r\n";
                    if (_obj.textboxStatus.InvokeRequired)
                    {
                        textBoxStatusDelegate del = new textBoxStatusDelegate(() => { _obj.textboxStatus.Text += message; });
                        _obj.textboxStatus.Invoke(del);

                        using (StreamWriter writer = File.AppendText("D:\\sms-log.txt"))
                        {
                            writer.WriteLine(message);
                            writer.Close();
                        }
                    }

                }
                Thread.Sleep(1000);
            }

        }
        public void stop()
        {
            this.flag = false;
        }

        public void testMethod(String id)
        {
            _webCheck.updateMessageStatus(id);
        }
    }
}
