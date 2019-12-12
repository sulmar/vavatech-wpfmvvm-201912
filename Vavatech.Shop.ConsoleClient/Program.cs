using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.Shop.ConsoleClient
{
    class Program
    {
        static void Print(string content, int? copies)
        {
            
        }

        static void Print(string content)
        {
            Print(content, 1);
        }

        static void Main(string[] args)
        {
            Sender sender = new Sender();
            sender.Send = sender.SendConsole;
            sender.Send += sender.SendEmail;
            sender.Send += sender.SendFacebook;
            sender.Send += Console.WriteLine;
            sender.Send += Print;

         

            // Metoda anonimowa
            sender.Send += delegate(string message)
            {
                Console.WriteLine($"Inline {message}");
            };

            // Wyrażenie lambda
            sender.Send += message => Console.WriteLine(message);

            sender.Send?.Invoke("Hello World");
            sender.Sent += Sender_Sent;
            sender.Send -= sender.SendEmail;

            sender.Send?.Invoke("Hello Wpf!");

           
            


            //sender.SendConsole("Hello World");
            //sender.SendEmail("Hello World");
            //sender.SendFacebook("Hello World");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void Sender_Sent()
        {
            Console.WriteLine("Wysłano");
        }
    }

    public class SendErrorEventArgs : EventArgs
    {
        public string Error { get; set; }
        public SendErrorEventArgs(string error)
        {
            Error = error;
        }

    }


    public class Sender
    {
        public delegate void SendDelegate(string message);

        public delegate void SentDelegate();

        public event SentDelegate Sent;

        // public delegate void SendingDelegate(object sender, EventArgs e);
        // public event SendingDelegate Sending; 

        public event EventHandler Sending;

        public event EventHandler<SendErrorEventArgs> SendError;

        public SendDelegate Send;

        public void SendConsole(string message)
        {
            Console.WriteLine($"Sending console {message}");

            Sent?.Invoke();

            SendError?.Invoke(this, new SendErrorEventArgs("brak polaczenia"));
        }

        public void SendEmail(string message)
        {
            Console.WriteLine($"Sending email {message}");
        }

        public void SendFacebook(string post)
        {
            Console.WriteLine($"Sending post {post}");
        }
    }
}
