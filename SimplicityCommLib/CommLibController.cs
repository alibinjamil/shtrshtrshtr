using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LINQSimplicityCommDAL;
using System.Data.Linq;
using System.Configuration;
using System.Reflection;
using System.Diagnostics;

namespace SimplicityCommLib
{
    public class CommLibController
    {
        string ConnectionStr;
        public CommLibController()
        {
           Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

           //ConnectionStr = config.GetSection("customsettings").ToString();
           //ConnectionStr = config.ConnectionStrings.ConnectionStrings["CommonDbConnectionString"].ConnectionString.ToString();
           //ConnectionStr = config.ConnectionStrings.ConnectionStrings[0].ConnectionString.ToString();
           //Debug.Write(ConnectionStr);

            ConnectionStr = @"Server=MOHSIN-LAPTOP\SQL2008; Database=shoptest; uid=sa; pwd=sa;";
        }

        // Users
        public IEnumerator<UserSelectByEmailResult> GetUserByEmail(string EmailAdd)
        {
            Shoptest db = new Shoptest(ConnectionStr);
            return db.UserSelectByEmail(EmailAdd).GetEnumerator();            
        }

        public IEnumerator<UserSelectResult> GetAllUsers()
        {
            Shoptest db = new Shoptest(ConnectionStr);
            return db.UserSelect().GetEnumerator();
        }

        public IEnumerator<UserInsertResult> InsertAndReturnUser(bool flg_receive_mails,bool flg_deleted,bool flg_entity_on_hold,
            int User_Approved_Status,int User_Pymt_Type,string Name_Long,string Name_Title,string Name_Initials,string Name_Forename,
            string Name_Surname,string Name_Job_Title,string Email,string Logon_Enable,	byte enable_reminder_question_id,string enable_reminder_custom_question,
            string enable_reminder_question_answer,string User_details,bool flg_verified,bool flg_enabled,int login_attempts,bool flg_locked,
            string locked_reason,int created_by,DateTime date_created,	int last_amended_by,DateTime date_last_amended,	string User_Type)
        {
            Shoptest db = new Shoptest(ConnectionStr);
            return db.UserInsert(flg_receive_mails,flg_deleted,flg_entity_on_hold,User_Approved_Status,User_Pymt_Type,Name_Long,
                Name_Title,Name_Initials,Name_Forename,Name_Surname,Name_Job_Title,Email,Logon_Enable,enable_reminder_question_id,enable_reminder_custom_question,
                enable_reminder_question_answer,User_details,flg_verified,flg_enabled,login_attempts,flg_locked,locked_reason,created_by,date_created,
                last_amended_by,date_last_amended,User_Type).GetEnumerator();        
        
        }

        public IEnumerator<UserUpdatePasswordResult> UdateUserPassword(string logon_enable, int original_entity_id, int entity_id)
        {
            Shoptest db = new Shoptest(ConnectionStr);
            return db.UserUpdatePassword(logon_enable, original_entity_id, entity_id).GetEnumerator();
        }



        //Session Handling
        public int InsertUserSession(string GUID, int UserId,DateTime start, DateTime End,string IP)
        {
            Shoptest db = new Shoptest(ConnectionStr);
            return db.SessionInsert(GUID,UserId,start,End,IP);
        }

        public IEnumerator<SessionSelectByUserIdResult> GetUserSessionById(int UserId)
        {
            Shoptest db = new Shoptest(ConnectionStr);
            return db.SessionSelectByUserId(UserId).GetEnumerator();
        }


        
    }
}
