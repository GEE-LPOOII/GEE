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
    public class AdmRepository
    {
        public bool Create(Adms pAdm)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO administrador (nome, telefone, email, cpf,senha)");
            sql.Append("VALUES(@nome, @telefone, @email, @cpf,@senha)");

            cmd.Parameters.AddWithValue("@nome", pAdm.nome);
            cmd.Parameters.AddWithValue("@telefone", pAdm.telefone);
            cmd.Parameters.AddWithValue("@email", pAdm.email);
            cmd.Parameters.AddWithValue("@cpf", pAdm.cpf);
            cmd.Parameters.AddWithValue("@senha", pAdm.senha);

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
             public bool Update(Adms pAdm)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE administrador SET nome=@nome, ");
            sql.Append("WHERE cpf=" + pAdm.cpf);

            cmd.Parameters.AddWithValue("@nome", pAdm.nome);
            cmd.Parameters.AddWithValue("@telefone", pAdm.telefone);
            cmd.Parameters.AddWithValue("@email", pAdm.email);
            cmd.Parameters.AddWithValue("@cpf", pAdm.cpf);
            cmd.Parameters.AddWithValue("@senha",pAdm.senha);


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

         public bool Delete(Adms pid)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM administrador ");
            sql.Append("WHERE cpf=" + pid);

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


         public static bool Login (string cpf,string senha)
         {
             StringBuilder sql = new StringBuilder();
             Adms administrador = new Adms();

             sql.Append("SELECT * ");
             sql.Append("FROM administrador ");
             sql.Append("WHERE cpf=" + cpf+ " and senha=" +senha);
             MySqlCommand cmd = new MySqlCommand();
             cmd.CommandText = sql.ToString();




             try
             {
                 MySqlDataReader dr = Connecta.Get(cmd);
                 return true;
             }
             catch (Exception)
             {
                return false;

             }

            
             
         }
        }
    }

