using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeeCommApp
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private string _title;
        
        public string Title
        {
            get { return _title; }
            set { _title = value; label1.Text = value; }
        }

        private Image _icon;

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; roundPictureBox2.Image = value; AddHeightText(); }
        }

        void AddHeightText()
        {
            UserControl3 user = new UserControl3();
            user.BringToFront();
            label1.Height = Uilist.GetTextHeight(label1) + 10;
            user.Height = label1.Top + label1.Height;
            this.Height = user.Bottom + 10;
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            AddHeightText();
        }
    }
}
