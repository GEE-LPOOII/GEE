using ConectaDAO;
using GEEData;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GEERepository
{
    public class InscricoesRepository
    {

        public static Inscricoes GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Inscricoes inscricao = new Inscricoes();

            sql.Append("SELECT i.*, p.nome as pessoa, e.nome as evento ");
            sql.Append("FROM inscricoes i ");
            sql.Append("INNER JOIN pessoas p ");
            sql.Append("ON i.id_pessoa=p.id ");
            sql.Append("INNER JOIN eventos e ");
            sql.Append("ON i.id_evento=e.id ");
            sql.Append("WHERE i.id=" + pId);

            MySqlDataReader dr = Connecta.Get(sql.ToString());

            while (dr.Read())
            {
                inscricao.id = (int)dr["id"];
                inscricao.id_pessoa = new Pessoas
                {
                    nome = (string)dr["pessoa"]
                };
                inscricao.id_evento = new Eventos
                {
                    nome = (string)dr["evento"]
                };
            }
            return inscricao;
        }

        public static List<Inscricoes> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Inscricoes> inscricoes = new List<Inscricoes>();
            
            sql.Append("SELECT i.*, p.nome as pessoa, e.nome as evento ");
            sql.Append("FROM inscricoes i ");
            sql.Append("INNER JOIN pessoas p ");
            sql.Append("ON i.id_pessoa=p.id ");
            sql.Append("INNER JOIN eventos e ");
            sql.Append("ON i.id_evento=e.id ");
            sql.Append("ORDER BY id DESC ");

            MySqlDataReader dr = Connecta.Get(sql.ToString());

            while (dr.Read())
            {
                inscricoes.Add(
                    new Inscricoes {
                        id = (int)dr["id"],
                        id_pessoa = new Pessoas
                        {
                            nome = (string)dr["pessoa"],
                        },
                        id_evento = new Eventos
                        {
                            nome = (string)dr["evento"],
                        }
                    });
            }
            return inscricoes;
        }
        
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
