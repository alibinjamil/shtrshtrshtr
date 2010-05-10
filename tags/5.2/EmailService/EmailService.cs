using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using DataAccessLayer.DataSets.EmailQueueTableAdapters;
using DataAccessLayer.DataSets;
using System.Net.Mail;
using System.Net;

namespace EmailService
{
    class EmailService : ServiceBase
    {
        /// <summary>

        /// Public Constructor for WindowsService.

        /// - Put all of your Initialization code here.

        /// </summary>
        private static string SMTP_SERVER = "smtpauth.moose.co.uk";
        private static string USER_NAME = "andrewcowie";
        private static string PASSWORD = "access";
        private Timer timer;

        public EmailService()
        {
            this.ServiceName = "Email Service";
            this.EventLog.Log = "Application";

            // These Flags set whether or not to handle that specific

            //  type of event. Set to true if you need it, false otherwise.

            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;
        }

        private void Log(string message, EventLogEntryType type)
        {
            this.EventLog.WriteEntry(message, type);
        }        
        /// <summary>

        /// The Main Thread: This is where your Service is Run.

        /// </summary>

        static void Main()
        {
            ServiceBase.Run(new EmailService());
        }

        /// <summary>

        /// Dispose of objects that need it here.

        /// </summary>

        /// <param name="disposing">Whether

        ///    or not disposing is going on.</param>

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        /// <summary>

        /// OnStart(): Put startup code here

        ///  - Start threads, get inital data, etc.

        /// </summary>

        /// <param name="args"></param>

        protected override void OnStart(string[] args)
        {
            TimerCallback tick = new TimerCallback(SendEmails);
            timer = new System.Threading.Timer(tick, null, 0, 60000);//1min
        }

        /// <summary>

        /// OnStop(): Put your stop code here

        /// - Stop threads, set final data, etc.

        /// </summary>

        protected override void OnStop()
        {
            timer.Dispose();
        }

        private void SendEmails(object state)
        {
            try
            {
                SmtpClient smtp = new SmtpClient(SMTP_SERVER);
                NetworkCredential userInfo = new NetworkCredential(USER_NAME, PASSWORD);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = userInfo;

                EmailQueueTableAdapter ta = new EmailQueueTableAdapter();
                Log("Connection String:" + System.Configuration.ConfigurationSettings.AppSettings["DataAccessLayer.database.ConnectionString"],EventLogEntryType.Information);
                ta.Connection = new System.Data.SqlClient.SqlConnection(@"Data Source=270882-WEB2\SQLEXPRESS;Initial Catalog=shop;Integrated Security=False;User Id=sa;password=3400663");
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
                        message.IsBodyHtml = true;
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
            catch (Exception ex)
            {
                //Log("Connection String:);
                Log(ex.ToString(), EventLogEntryType.Error);
            }
        }

        /// <summary>

        /// OnPause: Put your pause code here

        /// - Pause working threads, etc.

        /// </summary>

        protected override void OnPause()
        {
            base.OnPause();
        }

        /// <summary>

        /// OnContinue(): Put your continue code here

        /// - Un-pause working threads, etc.

        /// </summary>

        protected override void OnContinue()
        {
            base.OnContinue();
        }

        /// <summary>

        /// OnShutdown(): Called when the System is shutting down

        /// - Put code here when you need special handling

        ///   of code that deals with a system shutdown, such

        ///   as saving special data before shutdown.

        /// </summary>

        protected override void OnShutdown()
        {
            base.OnShutdown();
        }

        /// <summary>

        /// OnCustomCommand(): If you need to send a command to your

        ///   service without the need for Remoting or Sockets, use

        ///   this method to do custom methods.

        /// </summary>

        /// <param name="command">Arbitrary Integer between 128 & 256</param>

        protected override void OnCustomCommand(int command)
        {
            //  A custom command can be sent to a service by using this method:

            //#  int command = 128; //Some Arbitrary number between 128 & 256

            //#  ServiceController sc = new ServiceController("NameOfService");

            //#  sc.ExecuteCommand(command);


            base.OnCustomCommand(command);
        }

        /// <summary>

        /// OnPowerEvent(): Useful for detecting power status changes,

        ///   such as going into Suspend mode or Low Battery for laptops.

        /// </summary>

        /// <param name="powerStatus">The Power Broadcast Status

        /// (BatteryLow, Suspend, etc.)</param>

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            return base.OnPowerEvent(powerStatus);
        }

        /// <summary>

        /// OnSessionChange(): To handle a change event

        ///   from a Terminal Server session.

        ///   Useful if you need to determine

        ///   when a user logs in remotely or logs off,

        ///   or when someone logs into the console.

        /// </summary>

        /// <param name="changeDescription">The Session Change

        /// Event that occured.</param>

        protected override void OnSessionChange(
                  SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
        }
    }
}