using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
           //Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

           //ConnectionStr = config.GetSection("customsettings").ToString();
           //ConnectionStr = config.ConnectionStrings.ConnectionStrings["CommonDbConnectionString"].ConnectionString.ToString();
           //ConnectionStr = config.ConnectionStrings.ConnectionStrings[0].ConnectionString.ToString();
           //Debug.Write(ConnectionStr);

            ConnectionStr = @"Server=MOHSIN-LAPTOP\SQL2008; Database=SimplicityCommDB; uid=sa; pwd=sa;";
        }

        // Users
        
        public IEnumerator<UserSelectByEmailResult> GetUserByEmail(string EmailAdd)
        {            
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.UserSelectByEmail(EmailAdd).GetEnumerator();            
        }

        public IEnumerator<UserSelectResult> GetAllUsers()
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.UserSelect().GetEnumerator();
        }

        public IEnumerator<UserInsertResult> InsertAndReturnUser(bool flg_receive_mails, bool flg_deleted, bool flg_entity_on_hold,
            int User_Approved_Status, int User_Pymt_Type, string Name_Long, string Name_Title, string Name_Initials, string Name_Forename,
            string Name_Surname, string Name_Job_Title, string Email, string Logon_Enable, byte enable_reminder_question_id, string enable_reminder_custom_question,
            string enable_reminder_question_answer, bool flg_verified, bool flg_enabled, int login_attempts, bool flg_locked,
            string locked_reason, int created_by, DateTime date_created, int last_amended_by, DateTime date_last_amended, string User_Type)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.UserInsert(flg_receive_mails, flg_deleted, flg_entity_on_hold, User_Approved_Status, User_Pymt_Type, Name_Long,
                Name_Title, Name_Initials, Name_Forename, Name_Surname, Name_Job_Title, Email, Logon_Enable, enable_reminder_question_id, enable_reminder_custom_question,
                enable_reminder_question_answer,flg_verified, flg_enabled, login_attempts, flg_locked, locked_reason, created_by, date_created,
                last_amended_by, date_last_amended, User_Type).GetEnumerator();

        }

        public IEnumerator<UserUpdatePasswordResult> UdateUserPassword(string logon_enable, int original_entity_id, int entity_id)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.UserUpdatePassword(logon_enable, original_entity_id, entity_id).GetEnumerator();
        }

        public IEnumerator<UserSelectByIdResult> GetUserById(int userid)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.UserSelectById(userid).GetEnumerator();
        }

        public IEnumerator<UserSelectByUIDResult> GetUserByUID(string UserUid)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.UserSelectByUID(UserUid).GetEnumerator();        
        }

        public int VerifyUser(int userid)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.VerifyUser(userid);
        }

        //Session Handling
        public int InsertUserSession(string GUID, int UserId,DateTime start, DateTime End,string IP)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.SessionInsert(GUID,UserId,start,End,IP);
        }

        public IEnumerator<SessionSelectByUserIdResult> GetUserSessionById(int UserId)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.SessionSelectByUserId(UserId).GetEnumerator();
        }

        public IEnumerator<Session> GetUserSessionByGUID(string gUID)
        {
        
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            var sess = from session in db.Sessions
                       where session.GUID == gUID
                       select session;
            
            return (IEnumerator<Session>) sess.GetEnumerator();
                   
        }

        public int UpdateSession(string GUID,DateTime Start,DateTime End)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.UpdateSession(Start, End, GUID);
        
        }   
         

        //Address
        public int InsertAddress(bool Flg_Deleted,int CatagoryId,int TableId,bool FlgSameAsCustomer,bool FlgSameAsBilling,string MultiAddType,
            string AddressName,string AddressNo,string AddressLine1,string AddressLine2,string AddressLine3,string AddressLine4,
            string AddressLine5,string AddressPostCode,string AddressFull,string Telephone1,string Telephone2,string Fax,
            string CellNumber,int CreatedBy,DateTime DateCreated,int LastAmendedBy,DateTime DateLastAmended,string Town,string County,string Country)
        {

            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.AddressInsert(Flg_Deleted,CatagoryId,TableId,FlgSameAsCustomer,FlgSameAsBilling,MultiAddType,AddressName,AddressNo,AddressLine1,
                AddressLine2,AddressLine3,AddressLine4,AddressLine5,AddressPostCode,AddressFull,Telephone1,Telephone2,Fax,CellNumber,CreatedBy,
                DateCreated,LastAmendedBy,DateLastAmended,Town,County,Country);
        
        }

        public IEnumerator<AddressUpdateResult> UpdateAddress(bool Flg_Deleted,int CatagoryId,int TableId,bool FlgSameAsCustomer,bool FlgSameAsBilling,string MultiAddType,
            string AddressName,string AddressNo,string AddressLine1,string AddressLine2,string AddressLine3,string AddressLine4,
            string AddressLine5,string AddressPostCode,string AddressFull,string Telephone1,string Telephone2,string Fax,
            string CellNumber,int CreatedBy,DateTime DateCreated,int LastAmendedBy,DateTime DateLastAmended,string Town,string County,string Country,int Original_Id)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            return db.AddressUpdate(Flg_Deleted, CatagoryId, TableId, FlgSameAsCustomer, FlgSameAsBilling, MultiAddType, AddressName, AddressNo, AddressLine1,
                AddressLine2, AddressLine3, AddressLine4, AddressLine5, AddressPostCode, AddressFull, Telephone1, Telephone2, Fax, CellNumber, CreatedBy,
                DateCreated, LastAmendedBy, DateLastAmended, Town, County, Country, Original_Id).GetEnumerator();
        
        }

        public IEnumerator<Address> GetAddressByTableId(int CatagoryId, int Id)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            var Add = from address in db.Addresses
                      where ((address.TableId == Id) && (address.CatagoryId == CatagoryId))
                          select address;
            return (IEnumerator<Address>) Add.GetEnumerator();
        
        
        }

        //Products
        public IEnumerator<Product> GetProductById(int ProductId)
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            var product = from prod in db.Products
                          where prod.ProductId == ProductId
                          orderby prod.ProductId
                          select prod;
            return (IEnumerator<Product>) product.GetEnumerator();
        
        }

        public List<Product> GetAllProducts()
        {
            SimplicityCommDB db = new SimplicityCommDB(ConnectionStr);
            var product = from prod in db.Products
                          orderby prod.ProductId
                          select prod;
            return product.ToList();

        }

        
    }
}
