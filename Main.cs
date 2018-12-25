/*
 * helper resource
 * https://docs.microsoft.com/tr-tr/
 * https://regexr.com/ to test a valid regular expression
 */
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;
using Mouse_Simulation.Transactions;

namespace Mouse_Simulation
{
    public partial class MainForm : Form
    {
        private List<Transaction> transactions = new List<Transaction>();
        private MouseHookListener mouselistener;
        private KeyboardHookListener keybrdlistener;
        private Stopwatch mousehoversw;
        private Stopwatch clicksw;
        private Stopwatch keysw;
        private Stopwatch recordingsw;
        private Stopwatch sw;
        private bool recording = false;
        private bool stopReplay = false;
        public string filename;
        public bool nonNumberEntered=false;


        // Regular expression rule make ( @ ) sembol
        Regex rgxp_altgr = new Regex(@"[A-Z]{1}\, Control, Alt");
      

        public MainForm()
        {
            InitializeComponent();
            InitializeKeyboardHook();
            InitializeMouseHook();
            mousehoversw = new Stopwatch();
            recordingsw = new Stopwatch();
            clicksw = new Stopwatch();
            keysw = new Stopwatch();
            sw = new Stopwatch();
            //ImAlive function called
            Thread th1 = new Thread(ImAlive);
            th1.Start();
        }
        protected void InitializeMouseHook()
        {
            try
            {
                mouselistener = new MouseHookListener(new GlobalHooker());
                mouselistener.Enabled = true;
                mouselistener.MouseMove += Listener_MouseMove;
                mouselistener.MouseDown += Listener_MouseDown;
                mouselistener.MouseUp += Listener_MouseUp;
                mouselistener.MouseMove += MousePosition;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Couldn't initialize mouse hook: {0}", e.Message));
                Application.Exit();
            }
        }
        protected void InitializeKeyboardHook()
        {
            try
            {
                keybrdlistener = new KeyboardHookListener(new GlobalHooker());
                keybrdlistener.Enabled = true;
                keybrdlistener.KeyDown += new KeyEventHandler(Keybrdlistener_KeyDown);
                keybrdlistener.KeyUp += new KeyEventHandler(Keybrdlistener_KeyUp);
            }
            catch (Exception e)
            {
                Trace.WriteLine(string.Format("Couldn't initialize keyboard hook: {0}", e.Message));
                Application.Exit();
            }
        }
        private void Keybrdlistener_KeyUp(object sender, KeyEventArgs e)
        {
            // Skip if LEft Control or Altgr is pressed (happend when Altgr + Q pressed)
          
            sw.Start();
            keysw.Stop();
            if (recording)
            {
                transactions.Add(new Transaction(TransactionType.Sleep, (int)sw.ElapsedMilliseconds));
            }
            keysw.Reset();

            if (recording)
            {
                Console.WriteLine("Up: " + e.KeyData + " - " + e.KeyCode + " - " + e.KeyValue);

                // check if Altgr + any key combination is pressed
                if (rgxp_altgr.IsMatch(e.KeyData.ToString()))
                {
                    transactions.Add(new Transaction(TransactionType.KeyUp, e.KeyCode));
                    transactions.Add(new Transaction(TransactionType.KeyUp, Keys.LControlKey));
                    transactions.Add(new Transaction(TransactionType.KeyUp, Keys.RMenu));
                   if(recording && (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RMenu))
                    return;
                }
                else
                {
                    transactions.Add(new Transaction(TransactionType.KeyUp, e.KeyCode));
                }
            }
        }
        private void Keybrdlistener_KeyDown(object sender, KeyEventArgs e)
        {
            sw.Stop();
            if (recording)
            {
                transactions.Add(new Transaction(TransactionType.Sleep, (int)sw.ElapsedMilliseconds));
            }
            sw.Reset();

            if (recording)
            {
                Console.WriteLine("Down: " + e.KeyData + " - " + e.KeyCode + " - " + e.KeyValue);
             //   transactions.Add(new Transaction(TransactionType.KeyDown, e.KeyData));

                // check if Altgr + any key combination is pressed
                if (rgxp_altgr.IsMatch(e.KeyData.ToString()))
                {
                    transactions.Add(new Transaction(TransactionType.KeyDown, Keys.LControlKey));
                    transactions.Add(new Transaction(TransactionType.KeyDown, Keys.RMenu));
                    transactions.Add(new Transaction(TransactionType.KeyDown, e.KeyCode));         
                }
                else
                {
                    transactions.Add(new Transaction(TransactionType.KeyDown, e.KeyCode));
                }

                if (Control.ModifierKeys == Keys.Shift)
                {
                    nonNumberEntered = true;
                }
            }
            keysw.Start();
        }
        private void Listener_MouseUp(object sender, MouseEventArgs e)
        {
            sw.Start();
            clicksw.Stop();
            if (recording)
            {
                transactions.Add(new Transaction(TransactionType.Sleep, (int)clicksw.ElapsedMilliseconds));
            }
            clicksw.Reset();
            if (recording && e.Button == MouseButtons.Left)
            {
                transactions.Add(new Transaction(TransactionType.MouseLeftUp));
            }
            else if (recording && e.Button == MouseButtons.Right)
            {
                transactions.Add(new Transaction(TransactionType.MouseRightUp));
            }
            else if (recording && e.Button == MouseButtons.Middle)
            {
                transactions.Add(new Transaction(TransactionType.MouseMiddleUp));
            }
        }
        private void Listener_MouseDown(object sender, MouseEventArgs e)
        {
            sw.Stop();
            if (recording)
            {
                transactions.Add(new Transaction(TransactionType.Sleep, (int)sw.ElapsedMilliseconds));
            }
            sw.Reset();
            if (recording && e.Button == MouseButtons.Left)
            {
                transactions.Add(new Transaction(TransactionType.MouseLeftDown));
            }
            else if (recording && e.Button == MouseButtons.Right)
            {
                transactions.Add(new Transaction(TransactionType.MouseRightDown));
            }
            else if (recording && e.Button == MouseButtons.Middle)
            {
                transactions.Add(new Transaction(TransactionType.MouseMiddleDown));
            }
            clicksw.Start();
        }
        private void Listener_MouseMove(object sender, MouseEventArgs e)
        {
            mousehoversw.Stop();
            if (recording)
            {
                transactions.Add(new Transaction(TransactionType.Sleep, (int)mousehoversw.ElapsedMilliseconds));
            }
            mousehoversw.Reset();
            if (recording)
            {
                transactions.Add(new Transaction(TransactionType.MouseMove, e.X, e.Y));
            }
            mousehoversw.Start();
        }
        private new void MousePosition(object sender, MouseEventArgs e)
        {
            lbl_cursor.Text = e.X + "-" + e.Y;
        }
        private void btn_start_stop_Click(object sender, EventArgs e)
        {
            //test
            if (!recording)
            {
                transactions.Clear();
                btn_start_stop.Text = "Finish";
                recording = true;
                recordingsw.Reset();
                recordingsw.Start();
                mousehoversw.Start();
            }
            else
            {
                recordingsw.Stop();
                recording = false;
                btn_start_stop.Text = "Record";
                Save_Transaction_File();
            }
        }
        private void btn_play_Click(object sender, EventArgs e)
        {
            keybrdlistener.KeyDown += escapeReplay;
            if (recording == false)
            {
                NativeMethods.FreezeInputDevices();
                for (int i = 0; i < transactions.Count - 1; i++)
                {
                    if (stopReplay)
                        break;
                    if (transactions[i].TransactionType == TransactionType.Sleep)
                    {
                        Thread.Sleep(transactions[i].Sleep * 1);
                    }
                    else if (transactions[i].TransactionType == TransactionType.MouseLeftDown)
                    {
                        NativeMethods.SimulateMouseLeftDown();
                    }
                    else if (transactions[i].TransactionType == TransactionType.MouseRightDown)
                    {
                        NativeMethods.SimulateMouseRightDown();
                    }
                    else if (transactions[i].TransactionType == TransactionType.MouseLeftUp)
                    {
                        NativeMethods.SimulateMouseLeftUp();
                    }
                    else if (transactions[i].TransactionType == TransactionType.MouseRightUp)
                    {
                        NativeMethods.SimulateMouseRightUp();
                    }
                    else if (transactions[i].TransactionType == TransactionType.KeyDown)
                    {
                        NativeMethods.SimulateKeyDown(transactions[i].keys);
                    }
                    else if (transactions[i].TransactionType == TransactionType.KeyUp)
                    {
                        NativeMethods.SimulateKeyUp(transactions[i].keys);
                    }
                    else if (transactions[i].TransactionType == TransactionType.MouseMiddleDown)
                    {
                        NativeMethods.SimulateMouseMiddleDown();
                    }
                    else if (transactions[i].TransactionType == TransactionType.MouseMiddleUp)
                    {
                        NativeMethods.SimulateMouseMiddleUp();
                    }
                    else
                    {
                        Cursor.Position = transactions[i].Point;
                    }
                    Application.DoEvents();
                }
                NativeMethods.ThawInputDevices();
            }
        }
        private void escapeReplay(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                stopReplay = true;
        }
        public void Save_Transaction_File()
        {
            string dt = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss");
            filename = dt + ".csv";
            File_out_Transaction file_out_transaction = new File_out_Transaction(filename);
            RecordFileFormat rff= new RecordFileFormat();
            rff.Name = "csv";
            rff.Length = (uint)transactions.Count - 1;
            rff.Transactions = transactions;
            file_out_transaction.Save(rff);
        } 
        public void Open_Transaction_File(string filename)
        {
            File_in_Transaction file_in = new File_in_Transaction(filename);
            transactions = file_in.Load();
        } 
        MailMessage mailMessage = new MailMessage();
      
        public void Send_Email(string filepath)
        {
            Attachment data = new Attachment(filepath);      
            //From Email  
            mailMessage.From = new MailAddress("luckyvirtual2018@gmail.com");
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "I am a Robot";
            //Recipient Email 
            mailMessage.To.Add(new MailAddress("gulintizar7@gmail.com"));
            //CC Email
            mailMessage.CC.Add("najimaddinova@gmail.com");
            mailMessage.Body = "This message sent by Robot";
            mailMessage.Attachments.Add(data);
            SMTPClient();
            Save_Transaction_File();
        }
        public void SMTPClient()
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("luckyvirtual2018@gmail.com", "01102018lucky*");
                smtpClient.Send(mailMessage);
            }
        }
        //I'm Alive func 
        public void ImAlive()
        {
            //Sleep 30 Seconds
            Thread.Sleep(30000);
            // Create Folder 
            DateTime now = DateTime.Now;
            string dt = now.ToString("yyyy_MM_dd-HH_mm_ss");
            filename = "Robot/" + dt + ".txt";
            //Write Text and Datetime in Fİle
            using (var tw = new StreamWriter(filename, false))
            {
                tw.WriteLine(now.ToString("yyyy.MM.dd HH:mm:ss"));
                tw.WriteLine("I am Alive!");
            }
            // Send Message
            Send_Email(filename);
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Open_Transaction_File(ofd.FileName);
            }
        }
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".csv";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.ShowDialog();
            string name = saveFileDialog.FileName;
            File.WriteAllText(name, "test");
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.ShowDialog();
        }
    }
}