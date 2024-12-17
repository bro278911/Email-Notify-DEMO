using System.Net;
using System.Net.Mail;

namespace EmailTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 設定寄件者和收件者的郵件資訊
                string fromEmail = "your Gmail@gmail.com";  // 請換成你的寄件者 email
                string toEmail = textBox1.Text;  // 收件者 email
                string subject = textBox2.Text;  // 郵件主題
                string body = richTextBox1.Text;  // 郵件內容

                // 使用 SMTP 設定郵件伺服器（這裡使用 Gmail 為例）
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("<your Gmail@gmail.com>", "<Gmail應用程式密碼>"),  // 請填入你的寄件者郵件和密碼
                    EnableSsl = true
                };

                // 建立郵件內容
                MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);

                // 寄送郵件
                smtpClient.Send(mailMessage);

                MessageBox.Show("郵件已成功寄出!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
