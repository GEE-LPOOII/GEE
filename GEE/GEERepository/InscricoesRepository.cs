using ConectaDAO;
using GEEData;
using MySql.Data.MySqlClient;
using System.Text;

namespace GEERepository
{
    public class InscricoesRepository
    {
        public bool Create(Inscricoes pInscricoes)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO inscricoes (status, id_pessoa, id_evento)");
            sql.Append("VALUES('0', @id_pessoa, @id_evento)");

            cmd.Parameters.AddWithValue("@status", pInscricoes.status);
            cmd.Parameters.AddWithValue("@id_pessoa", pInscricoes.id_pessoa);
            cmd.Parameters.AddWithValue("@id_evento", pInscricoes.id_evento);

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

        public bool Update(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE inscricoes SET status='1'");
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

        public bool Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM inscricoes ");
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
