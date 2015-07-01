using GEEData;
using System.Text;
using MySql.Data.MySqlClient;
using ConectaDAO;
using System.Collections.Generic;


namespace GEERepository
{
    
    public class PessoasRepository
    {
        public static void conect()
        {
      Connecta.DBName("localhost", 3306, "gee", "root", "");
      Connecta.Connect();
        }
        public static Pessoas GetOne(string pCpf)
        {
            StringBuilder sql = new StringBuilder();
            Pessoas pessoa = new Pessoas();

            sql.Append("SELECT * ");
            sql.Append("FROM pessoas ");
            sql.Append("WHERE cpf=" + pCpf);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

           
            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                pessoa.id = (int)dr["id"];
                pessoa.nome = (string)dr["nome"];
                pessoa.telefone = (string)dr["telefone"];
                pessoa.email = (string)dr["email"];
                pessoa.cpf = (string)dr["cpf"];
            }

            return pessoa;
        }

        public static List<Pessoas> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Pessoas> pessoas = new List<Pessoas>();

            sql.Append("SELECT * ");
            sql.Append("FROM pessoas ");
            sql.Append("ORDER BY id DESC ");
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                pessoas.Add(
                    new Pessoas
                    {
                        id = (int)dr["id"],
                        nome = (string)dr["nome"],
                        telefone = (string)dr["telefone"],
                        email = (string)dr["email"],
                        cpf = (string)dr["cpf"]
                    });
            }
            return pessoas;
        }

        public bool Create(Pessoas pPessoas)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO pessoas (nome, telefone, email, cpf)");
            sql.Append("VALUES(@nome, @telefone, @email, @cpf)");

            cmd.Parameters.AddWithValue("@nome", pPessoas.nome);
            cmd.Parameters.AddWithValue("@telefone", pPessoas.telefone);
            cmd.Parameters.AddWithValue("@email", pPessoas.email);
            cmd.Parameters.AddWithValue("@cpf", pPessoas.cpf);

            cmd.CommandText = sql.ToString();
            if(Connecta.CommandPersist(cmd))
            {
                return true;
            }
            else
            {
                return false;
            }
                          
        }

        public bool Update(Pessoas pPessoas)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE pessoas SET nome=@nome, ");
            sql.Append("WHERE id=" + pPessoas.id);

            cmd.Parameters.AddWithValue("@nome", pPessoas.nome);
            cmd.Parameters.AddWithValue("@telefone", pPessoas.telefone);
            cmd.Parameters.AddWithValue("@email", pPessoas.email);
            cmd.Parameters.AddWithValue("@cpf", pPessoas.cpf);

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

            sql.Append("DELETE FROM pessoas ");
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

        public bool Valida(Pessoas pessoa)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("SELECT * FROM pessoas ");
            sql.Append("WHERE cpf='" + pessoa.cpf + "'");

            cmd.CommandText = sql.ToString();
            MySqlDataReader dr;
            dr = Connecta.Get(cmd);

            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Subscribe (int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

           //Inscrever-se
        }

    }
}
