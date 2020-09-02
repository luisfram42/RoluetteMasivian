using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteMasiv.Models.Dto
{
    class Bet
    {
        private Client client;
        private Roulette roulette;
        private string number_roulet;
        private string colour_roulet;
        private string result_bet;
        private string date_bet;
        private int money_bet;
        public Bet()
        {
            this.client = new Client();
            this.roulette = new Roulette();
            this.number_roulet = "";
            this.colour_roulet = "";
            this.result_bet = "";
            this.date_bet = "";
            this.money_bet = 0;
        }
        public Client GetClient() { return this.client; }
        public Roulette GetRoulette() { return this.roulette; }
        public string GetNumber_roulet() { return this.number_roulet; }
        public void SetNumber_roulet(string number_roulet) { this.number_roulet = number_roulet; }
        public string GetColour_roulet() { return this.colour_roulet; }
        public void SetColour_roulet(string colour_roulet) { this.colour_roulet = colour_roulet; }
        public string GetResult_bet() { return this.result_bet; }
        public void SetResult_bet(string result_bet) { this.number_roulet = result_bet; }
        public string GetDate_bet() { return this.date_bet; }
        public void SetDate_bet(string date_bet) { this.date_bet = date_bet; }
        public int GetMoney_bet() { return this.money_bet; }
        public void SetMoney_bet(int money_bet) { this.money_bet = money_bet; }
    }
}
