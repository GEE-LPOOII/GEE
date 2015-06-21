﻿using GEEData;
using System.Text;
using MySql.Data.MySqlClient;
using ConectaDAO;


namespace GEERepository
{
    public class PessoasRepository
    {
        
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

    }
}