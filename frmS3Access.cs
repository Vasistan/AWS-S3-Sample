using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S3AWS_Sample
{
    public partial class frmS3Access : Form
    {
        AmazonS3Client s3Client = new AmazonS3Client(System.Configuration.ConfigurationSettings.AppSettings["awsaccesskey"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["awssecretkey"].ToString(), Amazon.RegionEndpoint.APSoutheast1);
        readonly string mybucketName = System.Configuration.ConfigurationSettings.AppSettings["awsBucket"].ToString();

        public frmS3Access()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var opendialog = new OpenFileDialog())
            {
                if (opendialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lblSourceFileName.Text = opendialog.FileName;

                    if (chkImagePReview.Checked)
                        picPreview.Image = Image.FromFile(lblSourceFileName.Text);

                    if (MessageBox.Show("Are you want to upload this file?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        //Saving File to local disk folder.
                        string filePath = lblSourceFileName.Text;
                        string fileExtension = filePath.Substring(filePath.LastIndexOf(".") + 1);


                        string contentType = Code.Misc.GetContentType(fileExtension);
                        //Push the given object into S3 Bucket
                        PutObjectRequest objReq = new PutObjectRequest
                        {
                            //Key = string.Format("{0}/{1}","Folder name", System.IO.Path.GetFileName(filePath)),
                            Key = System.IO.Path.GetFileName(filePath),
                            FilePath = filePath,
                            ContentType = contentType,
                            BucketName = mybucketName,
                            CannedACL = S3CannedACL.Private,
                        };

                        PutObjectResponse response = s3Client.PutObject(objReq);
                        if (response.ETag != null)
                        {

                            string etag = response.ETag;
                            string versionID = response.VersionId;

                            MessageBox.Show("File uploaded to S3 Bucket Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex != -1)
            {
                using (var savedi = new SaveFileDialog())
                {
                    savedi.FileName = lstFiles.SelectedItem.ToString();
                    if (savedi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            string imageKey = lstFiles.SelectedItem.ToString();
                            string extension = imageKey.Substring(imageKey.LastIndexOf("."));
                            string imagePath = savedi.FileName;

                            Stream imageStream = new MemoryStream();


                            GetObjectRequest request = new GetObjectRequest
                            {
                                BucketName = mybucketName,
                                Key = imageKey,
                            };
                            using (GetObjectResponse response = s3Client.GetObject(request))
                            {
                                response.ResponseStream.CopyTo(imageStream);
                            }

                            imageStream.Position = 0;

                            Code.Misc.SaveStreamToFile(imagePath, imageStream);

                            if (chkImagePReview.Checked)
                                picPreview.Image = Image.FromFile(imagePath);

                            MessageBox.Show("File Downloaded from S3 Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnListFiles_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
            try
            {

                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = mybucketName;
                do
                {
                    ListObjectsResponse response = s3Client.ListObjects(request);

                    // Process response.
                    // ...
                    response.S3Objects.ForEach(x => { lstFiles.Items.Add(x.Key); });
                    // If response is truncated, set the marker to get the next 
                    // set of keys.
                    if (response.IsTruncated)
                    {
                        request.Marker = response.NextMarker;
                    }
                    else
                    {
                        request = null;
                    }
                } while (request != null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDownload.Enabled = lstFiles.Items.Count >= 1;
        }
    }
}
