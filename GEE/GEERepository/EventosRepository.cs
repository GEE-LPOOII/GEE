using GEEData;
using System.Text;
using MySql.Data.MySqlClient;
using ConectaDAO;
using System;

namespace GEERepository
{
    public class EventosRepository
    {
        
        public void Create(Eventos pEventos)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO eventos (nome, telefone, email, cpf)");
            sql.Append("VALUES(@nome, @telefone, @email, @cpf)");

            cmd.Parameters.AddWithValue("@nome", pEventos.nome);
            cmd.Parameters.AddWithValue("@data_evento", Convert.ToDateTime(pEventos.data).ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@cidade", pEventos.cidade);
            cmd.Parameters.AddWithValue("@qtd_horas", pEventos.qtd_horas);
            cmd.Parameters.AddWithValue("@descricao", pEventos.descricao);
            cmd.Parameters.AddWithValue("@idpessoa", pEventos.pessoa);
            cmd.Parameters.AddWithValue("@sub_area", pEventos.sub_area);

            cmd.CommandText = sql.ToString();
            Connecta.CommandPersist(cmd);
        }

        public void Update(Eventos pEventos)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE pessoas SET nome=@nome, ");
            sql.Append("WHERE id=" + pEventos.id);

            cmd.Parameters.AddWithValue("@nome", pEventos.nome);
            cmd.Parameters.AddWithValue("@data_evento", Convert.ToDateTime(pEventos.data).ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@cidade", pEventos.cidade);
            cmd.Parameters.AddWithValue("@qtd_horas", pEventos.qtd_horas);
            cmd.Parameters.AddWithValue("@descricao", pEventos.descricao);
            cmd.Parameters.AddWithValue("@idpessoa", pEventos.pessoa);
            cmd.Parameters.AddWithValue("@idsub_area", pEventos.sub_area);

            cmd.CommandText = sql.ToString();
            Connecta.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM eventos ");
            sql.Append("WHERE id=" + pId);

            cmd.CommandText = sql.ToString();
            Connecta.CommandPersist(cmd);
        }

    }
}
