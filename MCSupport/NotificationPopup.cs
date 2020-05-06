using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCSupport
{
    class NotificationPopup : Form
    {
        private System.ComponentModel.IContainer components;
    
        public NotificationPopup()
        {
            InitializeComponents();
        }

        void InitializeComponents()
        {
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void InitializeComponent()
        {
            //this.SuspendLayout();
            // 
            // NotificationPopup
            // 
            //this.ClientSize = new System.Drawing.Size(284, 262);
            //this.Name = "NotificationPopup";
            //this.ResumeLayout(false);

        }
    }
}
