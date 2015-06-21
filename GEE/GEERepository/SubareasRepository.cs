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
    public class SubareasRepository
    {
        public bool Create(Subareas pSubarea)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO subareas (nome, id_area)");
            sql.Append("VALUES(@nome, @id_area)");

            cmd.Parameters.AddWithValue("@nome", pSubarea.nome);
            cmd.Parameters.AddWithValue("@telefone", pSubarea.id_area);

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
            cmd.Parameters.AddWithValue("@telefone", pSubarea.id_area);

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
