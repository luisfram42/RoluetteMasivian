using RouletteMasiv.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RouletteMasiv.Controllers
{
    public class HomeController : Controller
    {
        private ClientBetDAO clientBet = new ClientBetDAO();
        private RouletteDAO roulette = new RouletteDAO();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RouletteControl()
        {
            return View();
        }
        public ActionResult ClientBet()
        {
            return View();
        }
        public ActionResult ConsultRoulette()
        {
            int idRulette = Int32.Parse(Request.Form["idRuleta"].ToString());
            roulette.GetRoulette().SetIdRoulet(idRulette);
            roulette.SearchRouletteRecord();
            ViewData["messageOperation"] = roulette.GetMessageOperation();
            ViewData["idRuleta"] = roulette.GetRoulette().GetIdRoulet();
            ViewData["estadoRuleta"] = roulette.GetRoulette().GetStateRoulet();
            ViewData["fechaCreacion"] = roulette.GetRoulette().GetCreated_at();
            return View();
        }
        public ActionResult CreateRoulette()
        {
            int idRuletteC = Int32.Parse(Request.Form["idCrear"].ToString());
            String stateRoulet = Request.Form["estado"].ToString();
            roulette.GetRoulette().SetIdRoulet(idRuletteC);
            roulette.GetRoulette().SetStateRoulet(stateRoulet);
            roulette.CreateNewRoulette();
            ViewData["messageOperation"] = roulette.GetMessageOperation();
            return View();
        }
        public ActionResult OpenRoulette()
        {
            int idRuletteO = Int32.Parse(Request.Form["ruletaOpen"].ToString());
            roulette.GetRoulette().SetIdRoulet(idRuletteO);
            roulette.GetRoulette().SetStateRoulet("ABIERTA");
            roulette.UpdateStateRoulette();
            ViewData["messageOperation"] = roulette.GetMessageOperation();
            return View();
        }
        public ActionResult CloseRoulette()
        {
            int idRuletteC = Int32.Parse(Request.Form["ruletaClose"].ToString());
            roulette.GetRoulette().SetIdRoulet(idRuletteC);
            roulette.GetRoulette().SetStateRoulet("CERRADA");
            roulette.UpdateStateRoulette();
            ViewData["messageOperation"] = roulette.GetMessageOperation();
            return View();
        }
        public ActionResult ClientBetRoulette()
        {
            int idClient = Int32.Parse(Request.Form["clientID"].ToString());
            int moneyClient = Int32.Parse(Request.Form["moneyBet"].ToString());
            String numberBet = Request.Form["numberBet"].ToString();
            String colourBet = Request.Form["colourBet"].ToString();
            int idRoulette = Int32.Parse(Request.Form["rouletteID"].ToString());
            clientBet.GetBet().GetClient().SetIdClient(idClient);
            clientBet.GetBet().GetRoulette().SetIdRoulet(idRoulette);
            if (clientBet.SearchClientRecord() == false)
            {
                ViewData["messageOperation"] = clientBet.GetMessageOperation();
            }
            else if (clientBet.SearchRouletteRecord() == false)
            {
                ViewData["messageOperation"] = clientBet.GetMessageOperation();
            }
            else if (clientBet.GetBet().GetRoulette().GetStateRoulet() != "ABIERTA")
            {
                ViewData["messageOperation"] = "ERROR. La ruleta no esta abierta";
            }
            else if (clientBet.GetBet().GetClient().GetMoney_client() < moneyClient)
            {
                ViewData["messageOperation"] = "ERROR. SALDO INSUFICIENTE PARA INVERTIR";
            }
            else {
                clientBet.GetBet().SetMoney_bet(moneyClient);
                clientBet.GetBet().SetColour_roulet(colourBet);
                clientBet.GetBet().SetNumber_roulet(numberBet);
                clientBet.GetBet().SetResult_bet("Exitoso");
                clientBet.CreateClientBet(1);
            }          
            return View();
        }
    }
}