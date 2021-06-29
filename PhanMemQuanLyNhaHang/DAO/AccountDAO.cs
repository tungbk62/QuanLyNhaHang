using PhanMemQuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyNhaHang.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord});
            
            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[]{userName, displayName, pass, newPass});

            return result > 0;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select UserName,DisplayName,IDpassport,Born,Hometown,Resident,Phone,Type from Account");
        }

    public DataTable GetListAccountbyUserName(string UserName)
        {
            return DataProvider.Instance.ExecuteQuery("select UserName,DisplayName,IDpassport,Born,Hometown,Resident,Phone,Type from Account where userName = '" + UserName + "'");
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        

        public bool InsertAccount(string name, string IDpassport, DateTime? Born,string Hometown,string Resident, string Phone, string displayName, string displayName1, int type)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, IDpassport, Born, Hometown, Resident, Phone, DisplayName, Type, password )VALUES  ( N'{0}', N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}', {7}, N'{8}')", name, IDpassport, Born, Hometown, Resident, Phone, displayName, type, "1");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Type = {2} WHERE UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
