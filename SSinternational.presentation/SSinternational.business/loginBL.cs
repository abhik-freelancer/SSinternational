using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.service;
using SSinternational.viewmodel;

namespace SSinternational.business
{
  public class loginBL
    {
      public int checkLogin(String username, string password) {
          loginSL _loginSL = new loginSL();
          int userid = 0;
          userid = _loginSL.checkUserLogin(username, password);
          return userid;
      
      }

      public UserVM getUserDataById(int userId) {
          loginSL _userSL = new loginSL();
          return _userSL.getUserDataById(userId);
      }

      public IEnumerable<CompanyVM> getCompanyList() {
          companySL _companySL = new companySL();
          return _companySL.getCompanyList();
      
      }

      public IEnumerable<financialVM> getFinancialList() {
          financialyearSL _financialSL = new financialyearSL();
          return _financialSL.getfinancialyearsList();
      }

      public void getUpdateUserLoginTime(int userId) {
          loginSL _loginSL = new loginSL();
          _loginSL.getUpdateUserLoginTime(userId);
          
      }

      public financialVM getFiscalYearById(int YearId)
      {
          financialyearSL _financialSL = new financialyearSL();
          return _financialSL.getFiscalYearById(YearId);
      }

    }
}
