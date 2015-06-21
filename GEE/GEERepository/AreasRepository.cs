using ConectaDAO;
using GEEData;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEERepository
{
    public class AreasRepository
    {
        public bool Create(Areas pArea)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO areas (nome)");
            sql.Append("VALUES(@nome)");

            cmd.Parameters.AddWithValue("@nome", pArea.nome);

            cmd.CommandText = sql.ToString();
            if (Connecta.CommandPersist(cmd))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Update(Areas pArea)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE areas SET nome=@nome, ");
            sql.Append("WHERE id=" + pArea.id);

            cmd.Parameters.AddWithValue("@nome", pArea.nome);

            cmd.CommandText = sql.ToString();
            if (Connecta.CommandPersist(cmd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM areas ");
            sql.Append("WHERE id=" + pId);

            cmd.CommandText = sql.ToString();
            if (Connecta.CommandPersist(cmd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
