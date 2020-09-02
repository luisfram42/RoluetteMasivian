using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteMasiv.Models.Dto;
using System.Data;
using System.Data.SqlClient;

namespace RouletteMasiv.Models.Dao
{
    class ClientBetDAO : DbContext
    {
        private Bet bet;
        private String messageOperation;
        public ClientBetDAO()
        {
            bet = new Bet();
            messageOperation = "";
        }
        public Boolean SearchClientRecord()
        {
            string sqlRead = "SELECT [IDCLIENT],[NAME],[LAST_NAME],[MONEY_CLIENT] FROM CLIENTE WHERE [IDCLIENT]=" + bet.GetClient().GetIdClient();
            SqlCommand comand = new SqlCommand(sqlRead, conectionDB) { CommandType = CommandType.Text };
            SqlDataReader readData;
            conectionDB.Open();
            try
            {
                readData = comand.ExecuteReader();
                if (readData.Read())
                {
                    bet.GetClient().SetName(readData[1].ToString());
                    bet.GetClient().SetLast_name(readData[2].ToString());
                    bet.GetClient().SetMoney_client(Convert.ToDouble(readData[3].ToString()));
                    messageOperation = "Cliente encontrado";
                    return true;
                }
                else messageOperation = "Ningun cliente encontrado con el Id ingresado !";
            }
            catch (Exception e)
            {
                messageOperation += "Error: " + e.ToString();
            }
            conectionDB.Close();
            return false;
        }
        public Boolean SearchRouletteRecord()
        {
            string sqlRead = "SELECT [IDROULET],[STATEROULET],[CREATED_AT] FROM ROULETTE WHERE [IDROULET]=" + bet.GetRoulette().GetIdRoulet();
            SqlCommand comand = new SqlCommand(sqlRead, conectionDB) { CommandType = CommandType.Text };
            SqlDataReader readData;
            conectionDB.Open();
            try
            {
                readData = comand.ExecuteReader();
                if (readData.Read())
                {
                    bet.GetRoulette().SetStateRoulet(readData[1].ToString());
                    bet.GetRoulette().SetCreated_at(readData[2].ToString());
                    messageOperation = "Ruleta encontrada !!";
                    return true;
                }
                else messageOperation = "Ninguna ruleta encontrada con el Id ingresado !";
            }
            catch (Exception e)
            {
                messageOperation += "Error: " + e.ToString();
            }
            conectionDB.Close();
            return false;
        }
        public void CreateClientBet(int option)
        {
            string sqlCreate;
            switch (option)
            {
                case 1:
                    sqlCreate = $"INSERT INTO BET ([CLIENT],[ROULET],[NUMBER_ROULET],[RESULT_BET],[MONEY_BET],[DATE_BET]) VALUES ({bet.GetClient().GetIdClient()}, " +
                        $"{bet.GetRoulette().GetIdRoulet()}, '{bet.GetNumber_roulet()}', '{bet.GetResult_bet()}', {bet.GetMoney_bet()}, CURRENT_TIMESTAMP)";
                    break;
                case 2:
                    sqlCreate = $"INSERT INTO BET ([CLIENT],[ROULET],[COLOUR_ROULET],[RESULT_BET],[MONEY_BET],[DATE_BET]) VALUES ({bet.GetClient().GetIdClient()}, " +
                        $"{bet.GetRoulette().GetIdRoulet()}, '{bet.GetColour_roulet()}', '{bet.GetResult_bet()}', {bet.GetMoney_bet()}, CURRENT_TIMESTAMP)";
                    break;
                default:
                    sqlCreate = "";
                    break;
            }
            SqlCommand comand = new SqlCommand(sqlCreate, conectionDB) { CommandType = CommandType.Text };
            conectionDB.Open();
            try
            {
                int i = comand.ExecuteNonQuery();
                if (i > 0)
                {
                    messageOperation = "Apuesta creada exitosamente !";
                }
                else messageOperation = "Error creando apuesta !";
            }
            catch (Exception e)
            {
                messageOperation += "Error: " + e.ToString();
            }
            conectionDB.Close();
        }
        public void UpdateMoneyClient()
        {
            string sqlUpdate = "UPDATE CLIENTE SET [MONEY_CLIENT]=" + bet.GetClient().GetMoney_client() + "WHERE [IDCLIENT]=" + bet.GetClient().GetIdClient();
            SqlCommand comand = new SqlCommand(sqlUpdate, conectionDB) { CommandType = CommandType.Text };
            conectionDB.Open();
            try
            {
                int i = comand.ExecuteNonQuery();
                if (i > 0)
                {
                    messageOperation = "Saldo actualizado correctamente !";
                }
                else messageOperation = "Error actualizando saldo !";
            }
            catch (Exception e)
            {
                messageOperation += "Error: " + e.ToString();
            }
            conectionDB.Close();
        }
        public Bet GetBet() { return this.bet; }
        public String GetMessageOperation() { return this.messageOperation; }
    }
}
