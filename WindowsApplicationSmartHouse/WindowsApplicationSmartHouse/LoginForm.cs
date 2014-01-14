using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApplicationSmartHouse.BusinessWorkFlowService;

namespace WindowsApplicationSmartHouse
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private bool _isValid;
        private string _userName;
        private string _password;
        private string _userObjectID;
        private string _userRole;

        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string UserObjectId
        {
            get { return _userObjectID; }
            set { _userObjectID = value; }
        }

        public string UserRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            IsValid = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsValid = false;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BusinessWorkFlowService.BusinessWorkFlowsClient _bwfc=new BusinessWorkFlowsClient();

            string[] _loginResults= _bwfc.VerifyUserNameAndPassword(textBoxUserName.Text.Trim(), textBoxPassword.Text.Trim());

            if(_loginResults[0]!="0")
            {
                UserObjectId = _loginResults[0];
                UserRole = _loginResults[1];
                IsValid = true;
                this.Close();
            }

            else
            {
                IsValid = false;
                MessageBox.Show("UserName or password is wrong");
            }
        }
    }
}
