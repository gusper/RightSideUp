using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace RightSideUp
{
	/// <summary>
	/// Summary description for Browser.
	/// </summary>
	public class RsuBrowser : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox tbxFolder;
        private System.Windows.Forms.ListView lvwImages;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem mnuRefresh;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnRotateAll;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuOptions;

        private string currentFolder;

		public RsuBrowser()
		{
			InitializeComponent();

            // Load settings from options.xml file
            Options.Load();

            lvwImages.Columns.Add("Image Name", 400, HorizontalAlignment.Left);
            lvwImages.Columns.Add("Orientation", 100, HorizontalAlignment.Left);

            currentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            refreshImages();
		}

		protected override void Dispose( bool disposing )
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RsuBrowser));
            this.tbxFolder = new System.Windows.Forms.TextBox();
            this.lvwImages = new System.Windows.Forms.ListView();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mnuRefresh = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnRotateAll = new System.Windows.Forms.Button();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // tbxFolder
            // 
            this.tbxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.tbxFolder.Location = new System.Drawing.Point(44, 4);
            this.tbxFolder.Name = "tbxFolder";
            this.tbxFolder.Size = new System.Drawing.Size(396, 21);
            this.tbxFolder.TabIndex = 0;
            this.tbxFolder.Text = "textBox1";
            this.tbxFolder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFolder_KeyPress);
            // 
            // lvwImages
            // 
            this.lvwImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwImages.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lvwImages.Location = new System.Drawing.Point(0, 32);
            this.lvwImages.MultiSelect = false;
            this.lvwImages.Name = "lvwImages";
            this.lvwImages.Size = new System.Drawing.Size(560, 403);
            this.lvwImages.TabIndex = 1;
            this.lvwImages.View = System.Windows.Forms.View.Details;
            this.lvwImages.DoubleClick += new System.EventHandler(this.lvwImages_DoubleClick);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(448, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folder";
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                    this.menuItem1,
                                                                                    this.menuItem5,
                                                                                    this.menuItem2,
                                                                                    this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.mnuExit});
            this.menuItem1.Text = "&File";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 0;
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.mnuRefresh});
            this.menuItem5.Text = "&View";
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Index = 0;
            this.mnuRefresh.Text = "&Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.mnuAbout});
            this.menuItem3.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            this.mnuAbout.Text = "&About RightSideUp";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnRotateAll
            // 
            this.btnRotateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotateAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRotateAll.Location = new System.Drawing.Point(480, 4);
            this.btnRotateAll.Name = "btnRotateAll";
            this.btnRotateAll.TabIndex = 5;
            this.btnRotateAll.Text = "&Rotate All";
            this.btnRotateAll.Click += new System.EventHandler(this.btnRotateAll_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.mnuOptions});
            this.menuItem2.Text = "&Tools";
            // 
            // mnuOptions
            // 
            this.mnuOptions.Index = 0;
            this.mnuOptions.Text = "&Options";
            this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // RsuBrowser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(560, 435);
            this.Controls.Add(this.btnRotateAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lvwImages);
            this.Controls.Add(this.tbxFolder);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.Menu = this.mnuMain;
            this.Name = "RsuBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RightSideUp";
            this.ResumeLayout(false);

        }
		#endregion

        [STAThread]
        static void Main(string[] args) 
        {
            if (args.Length == 1)
            {
                autoRotateShellExtension(args[0]);
                return;
            }

            Application.EnableVisualStyles();
            Application.Run(new RsuBrowser());
        }

        private static void autoRotateShellExtension(string arg)
        {
            // Determine if the argument is an image or a folder
            if (arg.Substring(arg.Length - ".jpg".Length, ".jpg".Length).ToLower() == ".jpg")
                new RsuBrowser().rotateImage(arg);
            else
                new RsuBrowser().rotateImagesInFolder(arg);
        }

		private bool validateFolder(string folderToValidate)
		{
			if (!Directory.Exists(folderToValidate))
			{
				MessageBox.Show("Specified folder does not exist!", "Folder not found! - RightSideUp", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}
		
		private void refreshImages()
        {
            Cursor.Current = Cursors.WaitCursor;

			if (!validateFolder(currentFolder))
			{
				lvwImages.Items.Clear();
				return;
			}

            tbxFolder.Text = currentFolder;

            try 
            {
                lvwImages.Items.Clear();
            
                foreach (string filename in Directory.GetFiles(currentFolder, "*.jpg")) 
                {
                    FileInfo fi = new FileInfo(filename);
                    ListViewItem lvi = new ListViewItem(fi.Name);
                    lvi.SubItems.Add(ExifImageInfo.GetOrientation(filename).ToString());
                    lvwImages.Items.Add(lvi);
                }
            }
            finally 
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private ImageCodecInfo retrieveCodec(String mimeType) 
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            for (int i = 0; i < encoders.GetLength(0); i++) 
            {
                if (encoders[i].MimeType == mimeType) 
                    return encoders[i];
            }

            return null;
        }
        
        private void rotateImagesInFolder(string folderName)
        {
            Cursor.Current = Cursors.WaitCursor;

			if (!validateFolder(folderName))
				return;

            try
            {
                foreach (string filename in Directory.GetFiles(folderName, "*.jpg")) 
                {
                    rotateImage(filename);
                }
            }
            finally 
            {
                refreshImages();
                Cursor.Current = Cursors.Default;
            }
        }

        private void rotateImage(string filename)
        {
            Image image;
            EncoderValue encoderValue; 
            ImageCodecInfo codec = retrieveCodec("image/jpeg");

            switch (ExifImageInfo.GetOrientation(filename))
            {
                case Orientation.Left:
                    encoderValue = EncoderValue.TransformRotate90;
                    break;
                case Orientation.Right:
                    encoderValue = EncoderValue.TransformRotate270;
                    break;
                default:
                    return;
            }

            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(Encoder.Transformation, (long)encoderValue);
            MemoryStream memoryStream = new MemoryStream();

            using (image = Image.FromFile(filename))
            {
                // Update the Exif orientation data in the image
                int index = Array.IndexOf(image.PropertyIdList, ExifTags.Orientation);
                PropertyItem propertyItem = image.PropertyItems[index];
                propertyItem.Value = BitConverter.GetBytes((int)Orientation.Straight);
                image.SetPropertyItem(propertyItem);

                // Save image out to a memory stream that we'll later write to disk
                image.Save(memoryStream, codec, parameters);
            }                    

            // Write the memory stream to disk
            Image newImage = new Bitmap(memoryStream);
            newImage.Save(filename);
        }

        private void lvwImages_DoubleClick(object sender, System.EventArgs e)
        {
            Point cp = lvwImages.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            ListViewItem item = lvwImages.GetItemAt(cp.X, cp.Y);
            Process.Start(currentFolder + "\\" + item.Text);
        }

        private void tbxFolder_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                currentFolder = tbxFolder.Text;
                refreshImages();
            }
        }

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                fd.SelectedPath = tbxFolder.Text;
                fd.Description = "Select a folder";

                if (fd.ShowDialog() == DialogResult.OK) 
                {
                    currentFolder = fd.SelectedPath;
                    refreshImages();
                }
            }
        }

        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuRefresh_Click(object sender, System.EventArgs e)
        {
            refreshImages();
        }

        private void btnRotateAll_Click(object sender, System.EventArgs e)
        {
            rotateImagesInFolder(tbxFolder.Text);
        }

        private void mnuAbout_Click(object sender, System.EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog();
        }

        private void mnuOptions_Click(object sender, System.EventArgs e)
        {
            OptionsForm dialog = new OptionsForm();
            dialog.ShowDialog();
        }
	}
}