using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SSinternational.dataaccess.POCO
{
   public class users
    {
       public int userid { get; set; }
       public string login { get; set; }
       public string password { get; set; }
       public string firstname { get; set; }
       public string lastname { get; set; }
       public bool isActive { get; set; }
       public DateTime logintime { get; set; }


       public int checkuserlogin(string username, string password) {
           userDAL _userDAL = new userDAL();
           int userId = _userDAL.checkLogin(username, password);
           return userId; 
       
       }

       public users getUserDataById(int userId) {
           userDAL _userDAL = new userDAL();
           DataTable dt=_userDAL.getUserDataById(userId);
           users _userPoco = new users();
           if (dt.Rows.Count > 0) {

               DataRow row = dt.Rows[0];
               //row = dt.Rows[0];

               _userPoco.userid = Convert.ToInt32(row["userid"].ToString());
               _userPoco.firstname = row["firstname"].ToString();
               _userPoco.lastname = row["lastname"].ToString();
               _userPoco.login = row["login"].ToString();

               _userPoco.logintime = Convert.ToDateTime(row["logintime"].ToString());

           }

           return _userPoco;
     
       
       }
       public void getUpdateUserLoginTime(int userId) {
           userDAL _userDAL = new userDAL();
           _userDAL.getUpdateUserLoginTime(userId);
       }
    }
}
