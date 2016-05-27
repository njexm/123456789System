using sorteSystem.com.proem.sorte.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sorteSystem.com.proem.sorte.util
{
    class SocketUtil
    {
        public static int bufferSize = 1024;
        public static int count = 0;//表示对话序号
        /// <summary>
        /// 启动服务器的socket。
        /// 此处要想修改为多用户连接，对每个新用户都new一个RecMsg线程，并且Dictionary<T1,T2>存储每一对ipe和socket即可
        /// </summary>
        /// <param name="o">传入的socket对象</param>
        public static void Run(object o)
        {
            Socket socket = o as Socket;
            try
            {
                Socket connSocket = socket.Accept();
                ConstantUtil.socketList.Add(connSocket.RemoteEndPoint, connSocket);
                //客户和服务器连接成功。
                Console.WriteLine("{0}成功连接到本机。", connSocket.RemoteEndPoint);
                //接下来的事情交给会话线程
                //Thread recTh = new Thread(RecMsg);
                //recTh.Start(connSocket);
                //Thread sendTh = new Thread(SendMsg);
                //sendTh.Start(connSocket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //throw;
            }
        }
        public static void RecMsg(object o)
        {
            Socket connSocket = o as Socket;
            while (true)
            {
                byte[] buffer = new Byte[bufferSize];
                try
                {
                    int length = connSocket.Receive(buffer);
                    byte[] realBuffer = new Byte[length];
                    Array.Copy(buffer, 0, realBuffer, 0, length);
                    string str = System.Text.Encoding.Default.GetString(realBuffer);
                    string[] strArray= str.Split(new string[]{","},StringSplitOptions.None);
                    sorteGoodList goodlist = new sorteGoodList();
                    ConstantUtil.redStatus = 3;
                    Application.Run(goodlist);
                    //sorteGoodList sorteList = ConstantUtil.main;
                    //window.sorteGoodList.ActiveForm.DataBindings.a
                    //MessageBox.Show(str);
                    Console.Write("[{0}] ", count++);
                    Console.WriteLine("{0}说：{1}.", connSocket.RemoteEndPoint, str);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    //Console.ReadKey();
                    break;
                }
            }
        }
        public static void SendMsg(object o)
        {
            Socket connSocket = o as Socket;
            while (true)
            {
                string str = Console.ReadLine();
                if (str != string.Empty)
                {
                    byte[] buffer = Encoding.Default.GetBytes(str);
                    connSocket.Send(buffer, buffer.Length, SocketFlags.None);
                }
            }
        }
    }
}
