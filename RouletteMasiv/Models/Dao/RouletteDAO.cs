using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RouletteMasiv.Models.Dto;

namespace RouletteMasiv.Models.Dao
{
    class RouletteDAO : DbContext
    {
        private Roulette roulette;
        private String messageOperation;
        public RouletteDAO()
        {
            messageOperation = "";
            roulette = new Roulette(); ;
        }
        public void CreateNewRoulette()
        {
            string sqlCreate = "INSERT INTO ROULETTE ([IDROULET],[STATEROULET],[CREATED_AT]) VALUES (" + roulette.GetIdRoulet() + ", '" + roulette.GetStateRoulet() + "', CURRENT_TIMESTAMP)";
            SqlCommand comand = new SqlCommand(sqlCreate, conectionDB) { CommandType = CommandType.Text };
            conectionDB.Open();
            try
            {
                int i = comand.ExecuteNonQuery();
                if (i > 0)
                {
                    messageOperation = "Ruleta creada exitosamente !";
                }
                else messageOperation = "Error creando ruleta !";
            }
            catch (Exception e)
            {
                messageOperation += "Error: " + e.ToString();
            }
            conectionDB.Close();
        }
        public Roulette SearchRouletteRecord()
        {
            string sqlRead = "SELECT [IDROULET],[STATEROULET],[CREATED_AT] FROM ROULETTE WHERE IDROULET=" + roulette.GetIdRoulet();
            SqlCommand comand = new SqlCommand(sqlRead, conectionDB) { CommandType = CommandType.Text };
            SqlDataReader readData;
            conectionDB.Open();
            try
            {
                readData = comand.ExecuteReader();
                if (readData.Read())
                {
                    roulette.SetStateRoulet(readData[1].ToString());
                    roulette.SetCreated_at(readData[2].ToString());
                    messageOperation = "Ruleta encontrada !!";
                }
                else messageOperation = "Ninguna ruleta encontrada con el Id ingresado !";
            }
            catch (Exception e)
            {
                messageOperation += "Error: " + e.ToString();
            }
            conectionDB.Close();
            return roulette;
        }
        public void UpdateStateRoulette()
        {
            string sqlUpdate = "UPDATE ROULETTE SET [STATEROULET]=" + roulette.GetStateRoulet() + "WHERE [IDROULET]=" + roulette.GetIdRoulet();
            SqlCommand comand = new SqlCommand(sqlUpdate, conectionDB) { CommandType = CommandType.Text };
            conectionDB.Open();
            try
            {
                int i = comand.ExecuteNonQuery();
                if (i > 0)
                {
                    messageOperation = "Estado actualizado correctamente !";
                }
                else messageOperation = "Error actualizando estado !";
            }
            catch (Exception e)
            {
                messageOperation += "Error: " + e.ToString();
            }
            conectionDB.Close();
        }
        public Roulette GetRoulette() { return this.roulette; }
        public String GetMessageOperation() { return this.messageOperation; }
    }
}
