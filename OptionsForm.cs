using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RightSideUp
{
	public class OptionsForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbShellExtFolders;
        private System.Windows.Forms.CheckBox chbShellExtJpegs;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;

		public OptionsForm()
		{
			InitializeComponent();

            // Start in correct state
            chbShellExtFolders.Checked = Options.EnableShellExtFolders;
            chbShellExtJpegs.Checked = Options.EnableShellExtJpegs;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbShellExtFolders = new System.Windows.Forms.CheckBox();
            this.chbShellExtJpegs = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbShellExtJpegs);
            this.groupBox1.Controls.Add(this.chbShellExtFolders);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shell Extension";
            // 
            // chbShellExtFolders
            // 
            this.chbShellExtFolders.Location = new System.Drawing.Point(16, 20);
            this.chbShellExtFolders.Name = "chbShellExtFolders";
            this.chbShellExtFolders.Size = new System.Drawing.Size(188, 24);
            this.chbShellExtFolders.TabIndex = 0;
            this.chbShellExtFolders.Text = "Enable on &folders";
            // 
            // chbShellExtJpegs
            // 
            this.chbShellExtJpegs.Location = new System.Drawing.Point(16, 48);
            this.chbShellExtJpegs.Name = "chbShellExtJpegs";
            this.chbShellExtJpegs.Size = new System.Drawing.Size(188, 24);
            this.chbShellExtJpegs.TabIndex = 1;
            this.chbShellExtJpegs.Text = "Enable on &JPEG files";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(128, 96);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(208, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 128);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (Options.EnableShellExtFolders != chbShellExtFolders.Checked)
            {
                if (chbShellExtFolders.Checked)
                {
                    setShellExtension("folder", true);
                }
                else
                {
                    setShellExtension("folder", false);
                }

                Options.EnableShellExtFolders = chbShellExtFolders.Checked;
            }

            if (Options.EnableShellExtJpegs != chbShellExtJpegs.Checked)
            {
                if (chbShellExtJpegs.Checked)
                {
                    setShellExtension("jpegfile", true);
                }
                else
                {
                    setShellExtension("jpegfile", false);
                }

                Options.EnableShellExtJpegs = chbShellExtJpegs.Checked;
            }

            Options.Save();
        }

        private void setShellExtension(string extensionKey, bool registering)
        {
            string keyName = extensionKey + @"\shell\Auto-Rotate with RightSideUp";

            if (registering)
            {
                string exeName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true);
                key = Registry.ClassesRoot.CreateSubKey(keyName + @"\command");
                key.SetValue(null, exeName + " %1");
                key.Close();
            }
            else
            {
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName);
                if (key != null)
                    Registry.ClassesRoot.DeleteSubKeyTree(keyName);
                key.Close();
            }
        }
	}
}
