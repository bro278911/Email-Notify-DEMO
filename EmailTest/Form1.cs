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
                // �]�w�H��̩M����̪��l���T
                string fromEmail = "your Gmail@gmail.com";  // �д����A���H��� email
                string toEmail = textBox1.Text;  // ����� email
                string subject = textBox2.Text;  // �l��D�D
                string body = richTextBox1.Text;  // �l�󤺮e

                // �ϥ� SMTP �]�w�l����A���]�o�̨ϥ� Gmail ���ҡ^
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("<your Gmail@gmail.com>", "<Gmail���ε{���K�X>"),  // �ж�J�A���H��̶l��M�K�X
                    EnableSsl = true
                };

                // �إ߶l�󤺮e
                MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);

                // �H�e�l��
                smtpClient.Send(mailMessage);

                MessageBox.Show("�l��w���\�H�X!", "���\", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("�o�Ϳ��~: " + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
