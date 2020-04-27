using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using System.IO;
using AndicatorBLL;
using System.Diagnostics;
using WIA;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Andicator.scan;
using System.Collections;
namespace Andicator.controls
{
    public partial class AttachmentForm : Form
    {
        private byte[] _imageData;

        //private int _id = -1;
        private int _letterId;
        //private string _fileName;
        private AttachmentBL _attachmentBL;
        public AttachmentForm(int letterId)
        {
            _letterId = letterId;
            _attachmentBL = new AttachmentBL();

            InitializeComponent();

            loadForm();
        }

        private void loadForm()
        {
            /*if (_id > 0)
            {
                try
                {
                    AttachmentEntity entity = _attachmentBL.getById(_id);
                    txtFileName.Text = entity.get(AttachmentEntity.FIELD_FILE_NAME).ToString();
                    _fileName = txtFileName.Text;
                    _imageData = (byte[])entity.Tables[entity.FilledTableName].Rows[0][AttachmentEntity.FIELD_CONTENT];
                    
                    if (isImage(txtFullFileName.Text)) {
                        Image newImage;
                        //Read image data into a memory stream
                        using (MemoryStream ms = new MemoryStream(_imageData, 0, _imageData.Length))
                        {
                            ms.Write(_imageData, 0, _imageData.Length);

                            //Set image variable value using memory stream.
                            newImage = Image.FromStream(ms, true);

                        }
                        //pictureBox1.Height = newImage.Height;
                        //pictureBox1.Width = newImage.Width;
                        //pictureBox1.Image = newImage;
                        //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }else
                        displayNonImageFile();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }*/
        }

        private void AttachmentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "انتخاب عکس";
            openFileDialog1.Filter = "ALL Files|*.*";
            //openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            
            //string s = openFileDialog1.FileName;
            string[] selecteds = openFileDialog1.FileNames;
           /* if (s != null && s.Length > 0 && isImage(s))
            {
                txtFullFileName.Text = s;
                txtFileName.Text = s.Substring(s.LastIndexOf('\\') + 1, s.Length - s.LastIndexOf('\\') - 1);
                Image img = Image.FromFile(s);
                //pictureBox1.Image = img;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else*/
            if (selecteds == null || selecteds.Length <= 0)
                return;
            for (int i = 0; i < selecteds.Length; i++)
            {
                //txtFullFileName.Text = s;
                checkedListBox1.Items.Add(selecteds[i], true);
                //txtFileName.Text = s.Substring(s.LastIndexOf('\\') + 1, s.Length - s.LastIndexOf('\\') - 1);
            }

        }

        private bool isImage(string file)
        {
            string extension = Path.GetExtension(file);
            if (extension.ToLower() == ".jpg" || extension.ToLower()== "gif" || 
                extension.ToLower() == "png" || extension.ToLower() == "bmp" )
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count == 0)
                return;
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                string txtFullFileName = checkedListBox1.CheckedItems[i].ToString().Trim();
                try
                {
                    string s = txtFullFileName;
                    if (txtFullFileName.Length > 0)
                    {
                        s = s.Substring(s.LastIndexOf("\\")).Replace("\\", "") ;
                        AttachmentEntity entity = new AttachmentEntity();
                        DataRow dr = entity.Tables[entity.TableName].NewRow();

                        dr[AttachmentEntity.FIELD_LETTER_ID] = _letterId;
                        dr[AttachmentEntity.FIELD_FILE_NAME] = s;
                       // dr[AttachmentEntity.FIELD_ID] = _id;
                        dr[AttachmentEntity.FIELD_CONTENT] = ReadFile(txtFullFileName);
                        entity.Tables[entity.TableName].Rows.Add(dr);

                        /*if (_id > 0)
                        {
                            _attachmentBL.update(entity);
                            //lblMsg.Text = "به روز رسانی گردید";
                        }
                        else*/
                        {
                             _attachmentBL.add(entity);
                            //lblMsg.Text = "ذخیره شد  ";
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message != null && (ex.Message.IndexOf("cannot access the file ") >= 0 ||
                        ex.Message.IndexOf("") >= 0))
                    {
                        MessageBox.Show("فایل مورد نظر توسط برنامه ای دیگر در حال استفاده است!" +
                            "\n" + ex.Message);
                        return;
                    }
                }
            }
            this.Close();
            
        }

        private byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            btnDisplayInWindows_Click(null, null);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                WIA.CommonDialog dialog = new WIA.CommonDialog();
                
                ImageFile scannedImage = null;
                scannedImage = dialog.ShowAcquireImage(
                            WiaDeviceType.ScannerDeviceType,
                            WiaImageIntent.UnspecifiedIntent,
                            WiaImageBias.MaximizeQuality,
                            FormatID.wiaFormatPNG,
                            true, true, false);
                if (scannedImage != null)
                {
                    WIA.Vector vector = scannedImage.FileData;
                    byte[] b = (byte[])vector.get_BinaryData();
                    
                    System.Drawing.Image img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(b));
                    //pictureBox1.Image = img;
                    //pictureBox1.Height = img.Height;
                    //pictureBox1.Width = img.Width;
                    //pictureBox1.Image = img;
                }
            }catch (Exception ex)
            {
                Scanner scanner = new Scanner();
                ArrayList list = scanner.ADFScan();
                if (list.Count <= 0)
                    MessageBox.Show("خطا در دستیابی به اسکنر ، لطفا از وصل بودن کابلهای اسکنر اطمینان حاصل کنید" + "\n" + ex.Message);
                else
                {
                    WIA.Vector vector = ((ImageFile)list[0]).FileData;
                    byte[] b = (byte[])vector.get_BinaryData();

                    System.Drawing.Image img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(b));
                    //pictureBox1.Image = img;
                    //pictureBox1.Height = img.Height;
                    //pictureBox1.Width = img.Width;
                    //pictureBox1.Image = img;
                }
            }
        }

        private void btnDisplayInWindows_Click(object sender, EventArgs e)
        {
           /* if (isImage(_fileName))
            {
                string filePath = SaveImageToDisk();
                // image viewer
                Process p = new Process();
                p.StartInfo.FileName = "rundll32.exe";
                //Arguments
                p.StartInfo.Arguments = @"C:\WINDOWS\System32\shimgvw.dll,ImageView_Fullscreen " + filePath;
                p.Start();
            }
            else*/
            {
                if (checkedListBox1.SelectedItem == null)
                    return;
                string s = Application.ExecutablePath;
                string fp = s.Substring(0, s.LastIndexOf("\\")) + "\\tmp\\";
                fp = checkedListBox1.SelectedItem.ToString();
                //File.WriteAllBytes(fp, _imageData);

                Process.Start(fp);

            }
        }


        

       /* private string SaveImageToDisk()
        {
            string filePath = "";
            if (_imageData == null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

                _imageData = ms.ToArray();
            }
            Image result = null;
            ImageFormat format = ImageFormat.Jpeg;

            result = new Bitmap(new MemoryStream(_imageData));

            string s = Application.ExecutablePath;
            string fp = s.Substring(0, s.LastIndexOf("\\")) + "\\tmp\\tmp";

            using (Image imageToExport = result)
            {
                 filePath = string.Format(fp +".jpg");
                imageToExport.Save(filePath, format);
            }

            return filePath;
        }*/
    }
}
