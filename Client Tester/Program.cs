using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "C:\\Users\\Livne\\Desktop\\images_check\\google.png";
            string s2 = "C:\\Users\\Livne\\Desktop\\images_check\\ynet.png";

            Program p1  = new Program(); // new instance
            byte[] base_1 = p1.FileToByteArray(s1);
            byte[] base_2 = p1.FileToByteArray(s2);
            byte[] base_3 = base_1;

            string base64String = System.Convert.ToBase64String(base_1);

            /* Create the Consumers */
            Consumer c1 = new Consumer(base64String, "g1.png");
            Consumer c2 = new Consumer(base64String, "g2.png");
            Consumer c3 = new Consumer(base64String, "g3.png");


            Thread consumer1 = new Thread(new ThreadStart(c1.sendFile));
            Thread consumer2 = new Thread(new ThreadStart(c2.sendFile));
            Thread consumer3 = new Thread(new ThreadStart(c3.sendFile));
            try {
                consumer1.Start();
                consumer2.Start();
                consumer3.Start();
            }
            catch (ThreadStateException e) {
                Console.WriteLine(e);  // Display text of exception
            }

        }
        /*
         * Convert file name into byte array
         */
        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
    }
}