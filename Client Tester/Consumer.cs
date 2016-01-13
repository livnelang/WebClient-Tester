using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client_Tester
{
    class Consumer
    {
        string base64String;
        string filename;
        /*
         * Consumer Constructor 
         */
        public Consumer(string base_64, string fname)
        {
            base64String = base_64;
            filename = fname;
        }

        /*
         * Send File to the server
         */
        public void sendFile()
        {

            /* new WebClient  */
            WebClient client = new WebClient();
            /* Collection values */
            var values = new NameValueCollection();
            values["base64"] = base64String;
            values["filename"] = filename;
            try { 
                /* Handle the response */
                var response = client.UploadValues("https://boardcast-ws.herokuapp.com/decode64", values);
                var responseString = Encoding.Default.GetString(response);
                Console.WriteLine(responseString);
            }
            catch (WebException e)
            {
                //How do I capture this from the UI to show the error in a message box?
                Console.WriteLine(e.Message);
            }
        }


    }
}
