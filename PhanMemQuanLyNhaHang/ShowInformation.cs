using PhanMemQuanLyNhaHang.DAO;
using PhanMemQuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyNhaHang
{
    public partial class ShowInformation : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public ShowInformation(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
            txbHometown.Text = LoginAccount.Hometown1;
            txbPhone.Text = LoginAccount.Phone1;
            txbResident.Text = LoginAccount.Resident1;
            //txbType. = LoginAccount.Type;
            //txbBorn. = LoginAccount.Born1;
            txbIDpassport.Text = LoginAccount.IDpassport;

        }


    }
}