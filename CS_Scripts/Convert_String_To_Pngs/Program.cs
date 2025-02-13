using System;
using Microsoft.VisualBasic.FileIO;
using System.IO;

//using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
namespace readlines
{

    
    class Read_lines
    {

        [STAThread]
        public static void Main(string[] args)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "CSV (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedFileName = openFileDialog1.FileName;

            DirectoryInfo di = Directory.CreateDirectory("line");

            using (TextFieldParser parser = new TextFieldParser(selectedFileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //Debug.WriteLine(field);
                        // Our text to paint
                        String str = field;

                        // Create our new bitmap object
                        Bitmap bmp = new Bitmap(128, 128);
                        Image img = Image.FromHbitmap(bmp.GetHbitmap());

                        // Get our graphics object
                        Graphics g = Graphics.FromImage(img);
                        g.Clear(Color.White);

                        // Define our image padding
                        var imgPadding = new Rectangle(2, 2, 2, 2);

                        // Determine the size of our text, using our specified font.
                        Font ourFont = new Font(FontFamily.GenericSansSerif, 12.0f, FontStyle.Regular, GraphicsUnit.Point);
                        SizeF strSize = g.MeasureString(str, ourFont, (bmp.Width - imgPadding.Left - imgPadding.Right), StringFormat.GenericDefault);

                        // Create our brushes
                        SolidBrush textBrush = new SolidBrush(Color.DodgerBlue);

                        // Draw our string to the bitmap using our graphics object
                        g.DrawString(str, ourFont, textBrush, imgPadding.Left, imgPadding.Top);

                        // Flush
                        g.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);

                        // Save our image.
                        

                        img.Save(di + "/" + field + ".png");

                        // Clean up
                        textBrush.Dispose();
                        g.Dispose();
                        bmp.Dispose();
                    }
                }
            }
        }
    }
}
