using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Mail_Client
{
    class NotificationPopup : Form
    {
        Button dismissNotification = new Button();
        System.Windows.Forms.Timer hideNotificationTimer = new Timer();
        System.ComponentModel.IContainer components = new System.ComponentModel.Container();

        public NotificationPopup(int axis_x, int axis_y)
        {
            InitializeComponents(axis_x, axis_y);
        }

        void InitializeComponents(int loc_x, int loc_y)
        {
            dismissNotificationButton();
            hideNotificationTimerProperties();
            thisFormProperties(loc_x, loc_y);
        }

        void thisFormProperties(int x_axis, int y_axis)
        {
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Width = 300;
            this.Height = 60;
            this.TopMost = true;
            this.CancelButton = dismissNotification;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(x_axis, y_axis);
            this.Shown += NotificationPopup_Shown;
            this.FormClosing += NotificationPopup_FormClosing;
            this.Load += NotificationPopup_Load;
            this.MouseHover += NotificationPopup_MouseHover;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormClosingEventCancel_Closing);
        }

        private void FormClosingEventCancel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;
        }

        void NotificationPopup_MouseHover(object sender, EventArgs e)
        {
            
        }

        void NotificationPopup_Load(object sender, EventArgs e)
        {
            this.Width = 0;
            
            for (double opacity = 0.0; opacity <= 1.0; opacity += 0.02)
            {
                DateTime start = DateTime.Now;
                this.Opacity = opacity;

                while (DateTime.Now.Subtract(start).TotalMilliseconds <= 15.0)
                {
                    Application.DoEvents();
                }
                
                if(this.Width<300)
                    this.Width += 6;
            }
        }

        void NotificationPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            hideNotificationTimer.Stop();
            hideNotificationTimer.Enabled = false;

            for (double opacity = 1.0; opacity >= 0.2; opacity -= 0.02)
            {
                DateTime start = DateTime.Now;
                this.Opacity = opacity;

                while (DateTime.Now.Subtract(start).TotalMilliseconds <= 15.0)
                {
                    Application.DoEvents();
                }

                if (this.Width > 0)
                    this.Width -= 6;
            }
        }

        void NotificationPopup_Shown(object sender, EventArgs e)
        {
            hideNotificationTimer.Enabled = true;
            hideNotificationTimer.Start();
        }

        void dismissNotificationButton()
        {
            // Setting Text Properties
            dismissNotification.Text = "x";
            dismissNotification.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            dismissNotification.ForeColor = System.Drawing.Color.DarkSlateGray;

            // Setting Position of dismissButton
            dismissNotification.Location = new System.Drawing.Point(this.Width - 20, -4);

            // Setting dismissButton Flat Style Properties
            dismissNotification.FlatStyle = FlatStyle.Flat;
            dismissNotification.FlatAppearance.BorderSize = 0;

            // Setting dismissButton Size
            dismissNotification.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            //dismissNotification.Size = new System.Drawing.Size(10, 10);
            //dismissNotification.Font = new Font(dismissNotification.Font.Name, 8, dismissNotification.Font.Style, dismissNotification.Font.Unit, dismissNotification.Font.GdiCharSet, dismissNotification.Font.GdiVerticalFont);
            dismissNotification.AutoSize = true;

            // Padding and Margin
            //dismissNotification.Padding = new System.Windows.Forms.Padding(0);
            //dismissNotification.Margin = new System.Windows.Forms.Padding(0);

            // Changing Mouse Hover Default effect
            dismissNotification.FlatAppearance.MouseOverBackColor = dismissNotification.BackColor;

            // Setting Cursor
            dismissNotification.Cursor = Cursors.Hand;

            // Setting dismissButton Events
            dismissNotification.Click += dismissNotification_Click;
            dismissNotification.MouseHover += dismissNotification_MouseHover;
            dismissNotification.MouseLeave += dismissNotification_MouseLeave;

            // Adding dismissButton to instance of this form
            this.Controls.Add(dismissNotification);
        }

        void dismissNotification_MouseLeave(object sender, EventArgs e)
        {
            //dismissNotification.Font = new Font(dismissNotification.Font, FontStyle.Regular);
            dismissNotification.ForeColor = Color.Black;
        }

        void dismissNotification_MouseHover(object sender, EventArgs e)
        {
            //dismissNotification.Font = new Font(dismissNotification.Font, FontStyle.Bold);
            dismissNotification.ForeColor = Color.Red;
        }

        void dismissNotification_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void hideNotificationTimerProperties(){

            hideNotificationTimer.Interval = 5000;

            hideNotificationTimer.Tick +=hideNotificationTimer_Tick;

            this.components.Add(hideNotificationTimer);
            
        }
        
        void hideNotificationTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
