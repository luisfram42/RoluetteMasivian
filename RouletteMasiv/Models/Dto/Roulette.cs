using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteMasiv.Models.Dto
{
    class Roulette
    {
        private int idRoulet;
        private string stateRoulet;
        private string created_at;
        public Roulette()
        {
            this.idRoulet = 0;
            this.stateRoulet = "";
            this.created_at = "";
        }
        public int GetIdRoulet() { return this.idRoulet; }
        public void SetIdRoulet(int idRoulet) { this.idRoulet = idRoulet; }
        public string GetStateRoulet() { return this.stateRoulet; }
        public void SetStateRoulet(string stateRoulet) { this.stateRoulet = stateRoulet; }
        public string GetCreated_at() { return this.created_at; }
        public void SetCreated_at(string created_at) { this.created_at = created_at; }
    }
}
