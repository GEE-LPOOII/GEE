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

        public static Areas GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Areas area = new Areas();

            sql.Append("SELECT * ");
            sql.Append("FROM areas ");
            sql.Append("WHERE id=" + pId);

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                area.id = (int)dr["id"];
                area.nome = (string)dr["nome"];
            }

            return area;
        }

        public static List<Areas> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Areas> areas = new List<Areas>();

            sql.Append("SELECT * ");
            sql.Append("FROM areas ");
            sql.Append("ORDER BY id DESC ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);
            while (dr.Read())
            {
                areas.Add(
                    new Areas
                    {
                        id = (int)dr["id"],
                        nome = (string)dr["nome"]
                    });
            }
            return areas;
        }
        
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
