using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Threading;
using DataAccessLayer.DataSets.EmailQueueTableAdapters;
using DataAccessLayer.DataSets;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;

namespace EmailSendingService
{
    class ShoppingCartEmailServer : ServiceBase
    {
        private static string SMTP_SERVER = "smtpauth.moose.co.uk";
        private static string USER_NAME = "andrewcowie";
        private static string PASSWORD = "access";        
        private Timer timer;
        public ShoppingCartEmailServer()
        {
            this.ServiceName = "ShoppingCartEmailService";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }
        protected override void OnStart(string[] args)
        {
            TimerCallback tick = new TimerCallback(SendEmails);
            timer = new System.Threading.Timer(tick, null, 0, 60000);//1min
        }
        protected override void OnStop()
        {
            timer.Dispose();
        }
        private void Log(string message,EventLogEntryType type)
        {
            if (!System.Diagnostics.EventLog.SourceExists("ShoppingCartEmailService"))
                System.Diagnostics.EventLog.CreateEventSource("ShoppingCartEmailService", "Application");

            EventLog MyEventLog = new EventLog();
            MyEventLog.Source = "ShoppingCartEmailService";
            MyEventLog.WriteEntry(message,type);
        }
        private void SendEmails(object state)
        {
            SmtpClient smtp = new SmtpClient(SMTP_SERVER);
            NetworkCredential userInfo = new NetworkCredential(USER_NAME, PASSWORD);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = userInfo;

            EmailQueueTableAdapter ta = new EmailQueueTableAdapter();
            EmailQueue.EmailQueueEntityDataTable emailQs = ta.GetEmailQueue();
            for (int i = 0; i < emailQs.Count; i++)
            {
                try
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(emailQs[i].from_address, emailQs[i].from_name);
                    string[] toNames = emailQs[i].to_names.Split(',');
                    string[] toAddresses = emailQs[i].to_addresses.Split(',');
                    for (int index = 0; index < toAddresses.Length; index++)
                    {
                        if (toAddresses[index].Length > 0)
                        {
                            message.To.Add(new MailAddress(toAddresses[index], toNames[index]));
                        }
                    }
                    message.Subject = emailQs[i].subject;
                    message.Body = emailQs[i].body;
                    smtp.Send(message);
                    emailQs[i].sent_time = DateTime.Now;
                    ta.Update(emailQs[i]);
                    Log("Queue Id:" + emailQs[i].queue_id + " processed.", EventLogEntryType.Information);
                }
                catch (Exception ex)
                {
                    Log("Queue Id:" + emailQs[i].queue_id + " errored.", EventLogEntryType.Error);
                    Log(ex.ToString(), EventLogEntryType.Error);
                }
            }
            ta.UpdateNumberOfTries();
        }
        public static void Main()
        {
            ServiceBase.Run(new ShoppingCartEmailServer());
        }
    }
}
