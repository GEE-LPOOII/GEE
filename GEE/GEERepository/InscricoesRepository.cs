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

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

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

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

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

        public static List<Eventos> GetIsncricoesPendentes()
        {
            StringBuilder sql = new StringBuilder();
            

            //sql da tabela incricoes
            //sql.Append("select pessoas.nome,pessoas.cpf,pessoas.telefone from pessoas ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            
           

           

            return null;

            

           
        }

        public static List<Inscricoes> GetIsncricoesAprovadas()
        {
            StringBuilder sql = new StringBuilder();
            List<Inscricoes> inscricoes = new List<Inscricoes>();

            sql.Append("SELECT i.*, p.nome as pessoa, e.nome as evento ");
            sql.Append("FROM inscricoes i ");
            sql.Append("INNER JOIN pessoas p ");
            sql.Append("ON i.id_pessoa=p.id ");
            sql.Append("INNER JOIN eventos e ");
            sql.Append("ON i.id_evento=e.id ");
            sql.Append("WHERE status=1 ");
            sql.Append("ORDER BY id DESC ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                inscricoes.Add(
                    new Inscricoes
                    {
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
        
        public bool Create(int IdPessoa, int IdEvento)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO inscricoes (id_pessoa, id_evento)");
            sql.Append("VALUES(@id_pessoa, @id_evento)");

            cmd.Parameters.AddWithValue("@id_pessoa", IdPessoa);
            cmd.Parameters.AddWithValue("@id_evento", IdEvento);

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

            sql.Append("UPDATE inscricoes SET status='1' ");
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
