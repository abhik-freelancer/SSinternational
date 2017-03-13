using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSinternational.viewmodel;
using SSinternational.dataaccess.POCO;


namespace SSinternational.service
{
   public class loginSL

    {

       public int checkUserLogin(string username, string password) {
           users _userPoco = new users();
           int userid = _userPoco.checkuserlogin(username, password);
           return userid;
       
       }

       public UserVM getUserDataById(int userId) {
           users _userPoco = new users();
           return Mapper.Map<users, UserVM>(_userPoco.getUserDataById(userId)); 
       
       }

       public void getUpdateUserLoginTime(int userId) {
           users _userPoco = new users();
           _userPoco.getUpdateUserLoginTime(userId);
       
       
       }

       
    }
}
