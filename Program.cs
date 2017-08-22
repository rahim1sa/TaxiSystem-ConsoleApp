using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Clientarry = new List<string> ();
            List<Taxi> Taxiler = new List<Taxi>();
            List<Client> klentler = new List<Client>();

            List<double> mesafe = new List<double>();
            List<string> taxiname = new List<string>();


            string a = "Choose a Client:";

            for (int i = 0; i <5 ; i++)
            {
                Console.WriteLine((i+1)+"ci Taxinin Addresi: ");
                int Taxix = Convert.ToInt32(Console.ReadLine());
                int Taxiy = Convert.ToInt32(Console.ReadLine());
                string Taxiname = Convert.ToString(Console.ReadLine());
                Taxi taxi1 = new Taxi(Taxix, Taxiy,Taxiname);
                Taxiler.Add(taxi1);
                taxiname.Add(Taxiname);

            }
            for (int j = 0; j < 5; j++)
            {

                Console.WriteLine((j+1)+ "ci Clientin Addresi:");
                int Clientx = Convert.ToInt32(Console.ReadLine());
                int Clienty = Convert.ToInt32(Console.ReadLine());
                string ClientName = Convert.ToString(Console.ReadLine());
                Client client = new Client(Clientx, Clienty, ClientName);
                Clientarry.Add(ClientName);
                klentler.Add(client);
            }
            foreach (var item in Clientarry)
            {
                a += "  "+item;
            }
            Console.WriteLine(a);
           
            var SelectedClient = Convert.ToString(Console.ReadLine());
            foreach (var kilent in klentler)
            {
                if (SelectedClient.ToString()==kilent.ClientName)
                { 
                    for (int i = 0; i < Taxiler.Count; i++)
                    {
                        kilent.Call(Taxiler[i] , mesafe);
                    }
                }
            }
            double b = mesafe.Min();

            Console.WriteLine(taxiname[mesafe.IndexOf(b)]+" nomreli taxi  sizi en ucuz "+ b.ToString() +" AZN qiymete aparar ");

        }
    }
    class Taxi
    {
       
        public int TaxiX;
        public int TaxiY;
        public string TaxiName;
        public Taxi(int _x, int _y, string _taxiName)
        {
            this.TaxiX = _x;
            this.TaxiY = _y;
            this.TaxiName = _taxiName;
        }

    }
    class Client
    {

        public int ClientX;
        public int ClientY;
        public string ClientName;
        public double Distance;
        public double Mebleg;
        public string SelectedClient;
        public Client(int _x,int _y,string _name)
        {
            this.ClientX = _x;
            this.ClientY = _y;
            this.ClientName = _name;
        }
        public void Call(Taxi taxiler, List<double> mesafe)
        {
            this.Distance = Math.Round(Math.Sqrt(Math.Pow((taxiler.TaxiX - ClientX), 2) + Math.Pow((taxiler.TaxiY - ClientY), 2)));
            this.Mebleg = Distance * 0.01;
            mesafe.Add(Distance);
        }
    }
}
