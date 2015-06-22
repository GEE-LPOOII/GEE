using ConectaDAO;
using GEEData;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace GEERepository
{
    public class SubareasRepository
    {

        public static Subareas GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Subareas subarea = new Subareas();

            sql.Append("SELECT s.*, a.nome as area ");
            sql.Append("FROM subareas s ");
            sql.Append("INNER JOIN areas a ");
            sql.Append("ON s.id_area=a.id ");
            sql.Append("WHERE s.id=" + pId);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                subarea.id = (int)dr["id"];
                subarea.nome = (string)dr["nome"];
                subarea.id_area = new Areas
                {
                    nome = (string)dr["area"]
                };
            }
            return subarea;
        }

        public static List<Subareas> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Subareas> subareas = new List<Subareas>();

            sql.Append("SELECT s.*, a.nome as area ");
            sql.Append("FROM subareas s ");
            sql.Append("INNER JOIN areas a ");
            sql.Append("ON s.id_area=a.id ");
            sql.Append("ORDER BY id DESC ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                subareas.Add(
                    new Subareas
                    {
                        id = (int)dr["id"],
                        nome = (string)dr["nome"],
                        id_area = new Areas
                        {
                            nome = (string)dr["area"],
                        },
                    });
            }
            return subareas;
        }
        
        public bool Create(Subareas pSubarea)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO subareas (nome, id_area)");
            sql.Append("VALUES(@nome, @id_area)");

            cmd.Parameters.AddWithValue("@nome", pSubarea.nome);
            cmd.Parameters.AddWithValue("@id_area", pSubarea.id_area);

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

        public bool Update(Subareas pSubarea)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE subareas SET nome=@nome, id_area=@id_area");
            sql.Append("WHERE id=" + pSubarea.id);

            cmd.Parameters.AddWithValue("@nome", pSubarea.nome);
            cmd.Parameters.AddWithValue("@id_area", pSubarea.id_area);

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

            sql.Append("DELETE FROM subareas ");
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
