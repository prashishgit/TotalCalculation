using BusinessLayer;
using BusinessLayer.Entity;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TotalCalculation;

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
            BLLUser bluser = new BLLUser();
            UserDetails utd = new UserDetails()
            {
                Username = txtUserName.Text,
                Password = txtPassword.Text,
                UserTypeId = 1

            }; 
            
            var user = bluser.CheckUserLogin(utd);
            if (user != null)
            {
                Program.username = txtUserName.Text;
               
                this.Hide();
                Total total = new Total();
                total.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "Invalid User");
                txtUserName.Text = "";
                txtPassword.Text = "";
                cboUserType.SelectedIndex = 0;
                txtUserName.Focus();
            }
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            LoadUserType();
        }
    }
}
