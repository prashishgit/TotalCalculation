using BusinessLayer;
using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Testing
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        BLLUser bluser = new BLLUser();

        private void LoadUserType()
        {
            List<UserTypeDetails> list = bluser.GetAllUserType();
            UserTypeDetails utd = new UserTypeDetails();
            utd.UserType = "Choose UserType";
            list.Insert(0, utd);
            cboUserType.DataSource = list;
            cboUserType.DisplayMember = "UserType";
            cboUserType.ValueMember = "UserType";
            cboUserType.SelectedIndex = 0;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            LoadUserType();
        }
    }
}
