using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteMasiv.Models.Dto
{
    class Client
    {
        private int idClient;
        private string name;
        private string last_name;
        private double money_client;
        public Client()
        {
            this.idClient = 0;
            this.name = "";
            this.last_name = "";
            this.money_client = 0.0;
        }
        public int GetIdClient() { return this.idClient; }
        public void SetIdClient(int idClient) { this.idClient = idClient; }
        public string GetName() { return this.name; }
        public void SetName(string name) { this.name = name; }
        public string GetLast_name() { return this.last_name; }
        public void SetLast_name(string last_name) { this.last_name = last_name; }
        public double GetMoney_client() { return this.money_client; }
        public void SetMoney_client(double money_client) { this.money_client = money_client; }
    }
}
