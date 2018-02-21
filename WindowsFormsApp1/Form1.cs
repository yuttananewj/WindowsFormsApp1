using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using Firebase.Database;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BackgroundWorker bgWorker = new BackgroundWorker();
        UdpClient server ;
        IPEndPoint endPoint;
        public Form1()
        {
            InitializeComponent();
            //th2 = new Thread(new ThreadStart(time_update));
            // UdpClient udpServer = new UdpClient(int.Parse(textBox2.Text));
        }


        int[] receive_S = new int[300];
        int[] receive_B = new int[10];
        int[] receive_G = new int[100];
        /// <Calulation>
        /// ////////////////////////////////////////
        int Que = 0;
        Double ax = 0;
        Double x1 = 0;
        Double x2 = 0;
        Double x3 = 0;
        Double x4 = 0;
        Double ay = 0;
        Double y1 = 0;
        Double y2 = 0;
        Double y3 = 0;
        Double y4 = 0;
        Double s1 = 0;
        Double s2 = 0;
        Double s3 = 0;
        Double s4 = 0;
        Double s5 = 0;
        Double s6 = 0;
        Double s7 = 0;
        Double s8 = 0;
        Double s9 = 0;
        Double s10 = 0;
        Double s11 = 0;
        Double s12 = 0;
        Double s13 = 0;
        Double s14 = 0;
        Double s15 = 0;
        Double s16 = 0;
        Double totals = 0;
        Double sum_W = 0.00000001;
        String STATE;
        int Firebase_ST = 0;

        ////////////////////////////////////////////
        /// </summary>

        //UdpClient udpServer = new UdpClient(int.Parse(Form1.textBox2.Text));
        Thread th1;

        //Thread th2;
        //th2 = new Thread(new ThreadStart(time_update));

        public void time_update()
        {

            if (true) {
                Update_timer();
                //label4.Text = DateTime.Now.ToString();
                Thread.Sleep(100);
            }

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //  UdpClient udpServer = new UdpClient(int.Parse(textBox2.Text));
            //th2 = new Thread(new ThreadStart(time_update));
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
           // th1 = new Thread(send_firebase);
            //Thread th1;
            //Thread th2;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Thread th1;
        //Thread th2;
        

        private void button1_Click(object sender, EventArgs e)
        {


            //bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            //bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            //bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            //th2 = new Thread(new ThreadStart(time_update));
            //server.Client.Shutdown();
            //if (server == null)
            //{
                endPoint = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
                server = new UdpClient(int.Parse(textBox2.Text));
            //server.Client.ReceiveTimeout = 5000;
            //}
            comboBox1.SelectedIndex.ToString();
            button2.Enabled = true;
            button1.Enabled = false;
            textBox3.Text = "Server started";
            //Thread th1 = new Thread(new ThreadStart (receive_data));
            //th1.Start();
            //th2 = new Thread(new ThreadStart(time_update));
            //th2.Start();

            bgWorker.RunWorkerAsync();
            //button1.Enabled = false;
            //th1.Start();
            // UdpClient udpServer = new UdpClient(int.Parse(textBox2.Text));
            /* while (receive_check == 1) {
                 var serverEp = new IPEndPoint(long.Parse(textBox1.Text), int.Parse(textBox2.Text));
                 var data = udpServer.Receive(ref serverEp);
                 textBox3.Text += serverEp.ToString();
                 udpServer.Close();

              }*/

            // System.Net.IPAddress ip = new System.Net.IPAddress(long.Parse(textBox1.Text));


        }

        Byte[] data;
        String[] msg;
        String[]pass_msg;

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {

            BackgroundWorker worker = sender as BackgroundWorker;
            //while (true) { receive_check++; }
            while (true) {


                if (worker.CancellationPending == true) {
                    //textBox5.Text = "stop1";
                    e.Cancel = true;
                    //Thread.Sleep(500);
                    
                    //server.Close();
                    server.Close();
                    //server.Client.Disconnect(true);
                    //e.Cancel = true;
                    // server.Client.Dispose();
                    //server.Close();
                    //server.Client.Dispose();
                    //Thread.Sleep(1);
                    //server.EndReceive();
                    //textBox5.Text = "stop2";
                    break;
                }
                else {

                    if (server.Available > 0)
                    {
                        byte[] data = new byte[10];
                        //var datas = await server.ReceiveAsync
                        data = server.Receive(ref endPoint);
                        msg = Encoding.ASCII.GetString(data).Split('.');
                        //pass_msg = msg[2].ToString();
                        bgWorker.ReportProgress(1);
                    }
                    Thread.Sleep(1);


                }
            }

        }


               /* while (true)
            {
                 Byte []data = server.Receive(ref endPoint);
                 String []msg = Encoding.Unicode.GetString(data).Split('.');
                 bgWorker.ReportProgress(1);

                //Writelog(msg[2]);

            }*/
        

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e){
            //textBox3.Text = receive_check.ToString();

            if (msg[0].ToString().Length > 0)
            {
                chart1.BackColor = System.Drawing.Color.Blue;
                string resultString = Regex.Match(msg[0], @"\d+").Value;
                int a = int.Parse(resultString);
                string con = msg[0].ToString();

                if(con[0].ToString() == "S"){ textBox4.Text = con.ToString();
                    receive_S[receive_S.Length - 1] = a;
                    Array.Copy(receive_S, 1, receive_S, 0, receive_S.Length - 1);
                    chart1.Series["RAW"].Points.Clear();

                    for (int g=0; g < receive_S.Length - 1; g++) {

                        chart1.Series["RAW"].Points.AddY(receive_S[g]);
                    }

                }
                if (con[0].ToString() == "B")
                {
                    textBox5.Text = con.ToString();

                    receive_B[receive_B.Length - 1] = a;
                    Array.Copy(receive_B, 1, receive_B, 0, receive_B.Length - 1);
                    chart2.Series["BPM"].Points.Clear();

                    for (int g = 0; g < receive_B.Length - 1; g++)
                    {

                        chart2.Series["BPM"].Points.AddY(receive_B[g]);
                    }

                    label6.Text = a.ToString();
                    Doingprocess();

                    if (comboBox1.SelectedIndex.ToString() == "2")
                    {
                        if (Firebase_ST == 0)
                        {
                            label15.Text = DateTime.Now.ToString();
                            th1 = new Thread(send_firebase);
                            //th1 = new Thread(send_firebase);
                            th1.Start();
                            //send_firebase();
                        }
                    }
                }



                if (con[0].ToString() == "G")
                {
                    textBox6.Text = con.ToString();


                    double K = 0;
                    int G = 0;
                    K = 1024 * (a / 4096.01);
                    G = Convert.ToInt32(K);
                    receive_G[receive_G.Length - 1] = G ;
                    Array.Copy(receive_G, 1, receive_G, 0, receive_G.Length - 1);
                    chart3.Series["GSR"].Points.Clear();

                    for (int g = 0; g < receive_G.Length - 1; g++)
                    {

                        chart3.Series["GSR"].Points.AddY(receive_G[g]);
                    }

                    textBox6.Text = K.ToString("0.00");





                }
                //textBox5.Text = con[0].ToString();

                //int a = int.Parse(resultString);
                // textBox4.Text = a.ToString();
                textBox3.Text = msg[0].ToString();
            }
            Update_timer();
                 //Writelog(msg);
                 // Update_timer();

        }

       
       
        public void button2_Click(object sender, EventArgs e)
        {
            
            bgWorker.CancelAsync();
            //th2 = new Thread(stop_receive);
            button1.Enabled = true;
            button2.Enabled = false;

            //th1.Abort();
            // server.Close();
            //th2.Start();
            //receive_check = 1;

            //th1.Abort();
            //server.Client.Shutdown(SocketShutdown.Receive);
            //server.Close();
            textBox3.Text = "stop receive";
            server.Close();
            //server.Client = null;
            //udpServer.Close();

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {

            //server.Close();
            // server.Client.Dispose();
            //Close();
            textBox3.Text = "stop receive";
            button2.Enabled = false;
        }

        private void Writelog(String msg) {

            MethodInvoker invoker = new MethodInvoker(delegate { textBox3.AppendText(msg); });
            this.BeginInvoke(invoker);

        }

        private void Update_timer() {
            MethodInvoker invoker_time = new MethodInvoker(delegate { label4.Text = DateTime.Now.ToString(); });
            this.BeginInvoke(invoker_time);
        }


        public void Doingprocess()
        {

            ////////////////////////////
            if (ax <= 65)
            {
                x1 = 1; x2 = 0; x3 = 0; x4 = 0;
            }
            else if (ax > 65 && ax < 70)
            {
                //x1 = (-ax / 5) + (70f / 5);//x1 = (-ax *0.2) + 14;
                // x2 = (ax / 15) - (65f / 5);//x2 = (ax*0.006 - (65f / 5);
                x1 = (-ax * 0.2) + 14;
                x2 = (ax * 0.2) - 13;
                x3 = 0;
                x4 = 0;
            }
            else if (ax >= 70 && ax <= 80)
            {
                x1 = 0;
                x2 = 1;
                x3 = 0;
                x4 = 0;
            }
            else if (ax > 80 && ax < 85)
            {
                x1 = 0;
                //x2 = (-ax / 5) + (85f / 5);
                x2 = (-ax * 0.2) + 17;
                //x3 = (ax / 5) - (80f / 5);
                x3 = (ax * 0.2) - 16;
                x4 = 0;
            }
            else if (ax >= 85 && ax <= 90)
            {
                x1 = 0;
                x2 = 0;
                x3 = 1;
                x4 = 0;

            }
            else if (ax > 90 && ax < 95)
            {
                x1 = 0;
                x2 = 0;
                //x3 = (-ax / 5) + (95f / 5);
                x3 = (-ax * 0.2) + 19;
                //x4 = (ax / 5) - (90f / 5);
                x4 = (ax * 0.2) - 18;

            }
            else if (ax >= 95)
            {
                x1 = 0;
                x2 = 0;
                x3 = 0;
                x4 = 1;
            }
            //////////////////

            if (ay < 260)
            {
                y4 = 0;
                y3 = 0;
                y2 = 0;
                y1 = 1;
            }
            else if (ay > +260 && ay < 300)
            {
                y4 = 0;
                y3 = 0;
                //y2 = (ay / 40) - (260f / 40);
                //y1 = (-ay / 40) + (300f / 40);
                y2 = (ay * 0.025) - (6.5);
                y1 = (-ay * 0.025) + (7.5);
            }
            else if (ay >= 300 && ay <= 350)
            {
                y4 = 0;
                y3 = 0;
                y2 = 1;
                y1 = 0;
            }
            else if (ay > 350 && ay < 450)
            {
                y4 = 0;
                // y3 = (ay / 100) - (350f / 100);
                //  y2 = (-ay / 100) + (450f / 100);
                y3 = (ay * 0.01) - (3.5);
                y2 = (-ay * 0.01) + (4.5);
                y1 = 0;
            }
            else if (ay >= 450 && ay < 500)
            {
                y1 = 0;
                y2 = 1;
                y3 = 0;
                y4 = 0;
            }
            else if (ay >= 500 && ay < 540)
            {
                // y1 = (ay / 40) - (500f / 40);
                // y2 = (-ay / 40) + (540f / 40);
                y1 = (ay * 0.025) - (12.5);
                y2 = (-ay - 0.025) + (13.5);
                y3 = 0;
                y4 = 0;
            }
            else if (ay > 540)
            {
                y1 = 1;
                y2 = 0;
                y3 = 0;
                y4 = 0;
            }

            ////////////////////////////////////
            s1 = Math.Min(x4, y1);
            s2 = Math.Min(x4, y2);
            s3 = Math.Min(x4, y3);
            s4 = Math.Min(x4, y4);

            s5 = Math.Min(x3, y1);
            s6 = Math.Min(x3, y2);
            s7 = Math.Min(x3, y3);
            s8 = Math.Min(x3, y4);

            s9 = Math.Min(x2, y1);
            s10 = Math.Min(x2, y2);
            s11 = Math.Min(x2, y3);
            s12 = Math.Min(x2, y4);

            s13 = Math.Min(x1, y1);
            s14 = Math.Min(x1, y2);
            s15 = Math.Min(x1, y3);
            s16 = Math.Min(x1, y4);
            totals = ((1f / 16) * s1) + ((2f / 16) * s2) + ((3f / 16) * s3) + ((4f / 16) * s4) + ((5f / 16) * s5) + ((6f / 16) * s6) + ((7f / 16) * s7) + ((8f / 16) * s8);
            totals = totals + ((9f / 16) * s9) + ((10f / 16) * s10) + ((11f / 16) * s11) + ((12f / 16) * s12) + ((13f / 16) * s13) + ((14f / 16) * s14) + ((15f / 16) * s15) + ((16f / 16) * s16);
            sum_W = (s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10 + s11 + s12 + s13 + s14 + s15 + s16);
            totals = totals / sum_W;
            textBox7.Text = totals.ToString("0.0000");

            //    textBox8.Text += totals.ToString();
            if (totals >= 0 && totals <= 0.0625)
            {
                if (Que != 1)
                {
                    textBox8.Text = "Depress";
                    // ComPort.WriteLine("A");
                    STATE = "A";
                    Que = 1;
                }

            }
            else if (totals >= 0.0626 && totals <= 0.1250)
            {
                if (Que != 2)
                {
                    STATE = "B";
                    textBox8.Text = "Depress or Quite Disgust";
                    //ComPort.WriteLine("B");
                    Que = 2;
                }
            }
            else if (totals >= 0.1251 && totals <= 0.1875)
            {
                if (Que != 3)
                {
                    STATE = "C";
                    textBox8.Text = "Distress";
                    //ComPort.WriteLine("C");
                    Que = 3;
                }
            }
            else if (totals >= 0.1876 && totals <= 0.2500)
            {
                if (Que != 4)
                {
                    STATE = "D";
                    textBox8.Text = "Anxiety";
                    //ComPort.WriteLine("D");
                    Que = 4;
                }
            }
            else if (totals >= 0.2501 && totals <= 0.3125)
            {
                if (Que != 5)
                {
                    STATE = "E";
                    textBox8.Text = "Quite Depress or Disgust";
                    //ComPort.WriteLine("E");
                    Que = 5;
                }
            }
            else if (totals >= 0.3126 && totals <= 0.3750)
            {
                if (Que != 6)
                {
                    STATE = "F";
                    textBox8.Text = "Disgust";
                    //ComPort.WriteLine("F");
                    Que = 6;
                }
            }
            else if (totals >= 0.3751 && totals <= 0.4375)
            {
                if (Que != 7)
                {
                    STATE = "G";
                    textBox8.Text = "Stress";
                    //ComPort.WriteLine("G");
                    Que = 7;
                }
            }

            else if (totals >= 0.4376 && totals <= 0.5000)
            {
                if (Que != 8)
                {
                    STATE = "H";
                    textBox8.Text = "Agitation";
                    // ComPort.WriteLine("H");
                    Que = 8;
                }
            }
            else if (totals >= 0.5001 && totals <= 0.5625)
            {
                if (Que != 9)
                {
                    STATE = "i";
                    textBox8.Text = "Quite Blissful or Relax";
                    //ComPort.WriteLine("i");
                    Que = 9;
                }
            }
            else if (totals >= 0.5626 && totals <= 0.6250)
            {
                if (Que != 10)
                {
                    STATE = "J";
                    textBox8.Text = "Deeply Relax";
                    //ComPort.WriteLine("j");
                    Que = 10;
                }
            }
            else if (totals >= 0.6251 && totals <= 0.6875)
            {
                if (Que != 11)
                {
                    STATE = "K";
                    textBox8.Text = "Calm or  Surprise?";
                    //ComPort.WriteLine("K");
                    Que = 11;
                }
            }
            else if (totals >= 0.6876 && totals <= 0.7500)
            {
                if (Que != 12)
                {
                    textBox8.Text = "Nearly Surprise? Or little Excited";
                    //ComPort.WriteLine("L");
                    STATE = "L";
                    Que = 12;
                }
            }
            else if (totals >= 0.7501 && totals <= 0.8125)
            {
                if (Que != 13)
                {
                    STATE = "M";
                    textBox8.Text = "Blissful";
                    //ComPort.WriteLine("K");
                    Que = 13;
                }
            }
            else if (totals >= 0.8126 && totals <= 0.8750)
            {
                if (Que != 14)
                {
                    STATE = "N";
                    textBox8.Text = "Quite Relax or Blissful";
                    //ComPort.WriteLine("K");
                    Que = 14;
                }
            }
            else if (totals >= 0.8751 && totals <= 0.9375)
            {
                if (Que != 15)
                {
                    STATE = "O";
                    textBox8.Text = "Joy";
                    //ComPort.WriteLine("K");
                    Que = 15;
                }
            }
            else if (totals >= 0.9376 && totals <= 1.000)
            {
                if (Que != 16)
                {
                    STATE = "P";
                    textBox8.Text = "Excited Anticipant";
                    //ComPort.WriteLine("K");
                    Que = 16;
                }
            } else { Que = 0; }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public void send_firebase() {


            //if (comboBox1.SelectedIndex.ToString() == "2") 
            {
                Firebase_ST = 1;

                String date = DateTime.Now.ToString();
                //label14.Text = date.ToString();
                //DateTime date = DateTime.Now;
                 //label14.Text = DateTime.Now.ToString();
                 var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                 {

                     Time = DateTime.Now.ToString(),
                     BPM = receive_B[receive_B.Length - 1],
                     GSR = receive_G[receive_G.Length - 1],
                     Emo = textBox8.Text,
                 });

                 var request = WebRequest.CreateHttp("https://emotional-monitoring.firebaseio.com/HEART/.json");
                 request.Method = "POST";
                 request.ContentType = "application/json";
                 var buffer = Encoding.UTF8.GetBytes(json);
                 request.ContentLength = buffer.Length;
                 request.GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                //Thread.Sleep(1000);
                //Firebase_ST = 0;
                Thread.Sleep(5000);
                Firebase_ST = 0;
            }
            return;
            //return;


        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }


}
