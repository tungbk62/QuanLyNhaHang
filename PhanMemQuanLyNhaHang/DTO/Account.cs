using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyNhaHang.DTO
{
    public class Account
    {
        public Account(string userName, string IDPassport, DateTime? Born, string Hometown, string Resident, string Phone , string displayName, int type, string password = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.Password = password;
        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Type = (int)row["type"];
            this.Password = row["password"].ToString();
            this.Born = (DateTime)row["born"];
            this.IDpassport = row["idpassport"].ToString();
            this.Hometown = row["hometown"].ToString();
            this.Resident = row["resident"].ToString();
            this.Phone = row["phone"].ToString();
        }

        private string iDpassport;
        private DateTime? Born;
        private string Hometown;
        private string Resident;
        private string Phone;
        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string displayName;

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string IDpassport { get => iDpassport; set => iDpassport = value; }
        public DateTime? Born1 { get => Born; set => Born = value; }
        public string Hometown1 { get => Hometown; set => Hometown = value; }
        public string Resident1 { get => Resident; set => Resident = value; }
        public string Phone1 { get => Phone; set => Phone = value; }
    }
}
