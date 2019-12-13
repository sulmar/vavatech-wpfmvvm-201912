using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vavatech.Shop.ConsoleClient
{
    public class Calculator
    {
        private int ThreadId => Thread.CurrentThread.ManagedThreadId;

        public Task<decimal> CalculateAsync(decimal amount)
        {
            return Task.Run(() => Calculate(amount));
        }

        public decimal Calculate(decimal amount)
        {
            Console.WriteLine($"#{ThreadId} Calculating...");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine($"#{ThreadId} Calculated.");

            return amount * 1.23m;
        }
 
    }

    class Program
    {
        static int ThreadId => Thread.CurrentThread.ManagedThreadId;

        static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine($"#{ThreadId} Started.");

            Calculator calculator = new Calculator();

            // sync
            // decimal result = calculator.Calculate(100);
            // Console.WriteLine($"#{ThreadId} result: {result}");

            // asynchroniczna
            //decimal result = Task.Run(() => calculator.Calculate(100)).Result;
            //Console.WriteLine($"#{ThreadId} result: {result}");


            //calculator.CalculateAsync(100)
            //   .ContinueWith(t => Console.WriteLine($"#{ThreadId} result: {t.Result}"));

            decimal result = await calculator.CalculateAsync(100).ConfigureAwait(false);

            Console.WriteLine($"#{ThreadId} result: {result}");



            // DelegatesTest();

            //sender.SendConsole("Hello World");
            //sender.SendEmail("Hello World");
            //sender.SendFacebook("Hello World");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void Print(string content, int? copies)
        {

        }

        static void Print(string content)
        {
            Print(content, 1);
        }



        private static void DelegatesTest()
        {
            Sender sender = new Sender();
            sender.Send = sender.SendConsole;
            sender.Send += sender.SendEmail;
            sender.Send += sender.SendFacebook;
            sender.Send += Console.WriteLine;
            sender.Send += Print;



            // Metoda anonimowa
            sender.Send += delegate (string message)
            {
                Console.WriteLine($"Inline {message}");
            };

            // Wyrażenie lambda
            sender.Send += message => Console.WriteLine(message);

            sender.Send?.Invoke("Hello World");
            sender.Sent += Sender_Sent;
            sender.Send -= sender.SendEmail;

            sender.Send?.Invoke("Hello Wpf!");
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
