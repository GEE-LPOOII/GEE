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

            sql.Append("INSERT INTO eventos (nome, descricao, cidade, qtd_horas, data, id_pessoa, id_subarea)");
            sql.Append("VALUES(@nome, @descricao, @cidade, @qtd_horas, @data, @id_pessoa, @id_subarea)");

            cmd.Parameters.AddWithValue("@nome", pEventos.nome);
            cmd.Parameters.AddWithValue("@descricao", pEventos.descricao);
            cmd.Parameters.AddWithValue("@cidade", pEventos.cidade);
            cmd.Parameters.AddWithValue("@qtd_horas", pEventos.qtd_horas);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(pEventos.data).ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@id_pessoa", pEventos.pessoa);
            cmd.Parameters.AddWithValue("@id_subarea", pEventos.subarea);

            cmd.CommandText = sql.ToString();
            Connecta.CommandPersist(cmd);
        }

        public void Update(Eventos pEventos)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE pessoas SET nome=@nome, descricao=@descricao, cidade=@cidade, qtd_horas=@qtd_horas, data=@data, id_pessoa=@id_pessoa, id_subarea=@id_subarea");
            sql.Append("WHERE id=" + pEventos.id);

            cmd.Parameters.AddWithValue("@nome", pEventos.nome);
            cmd.Parameters.AddWithValue("@descricao", pEventos.descricao);
            cmd.Parameters.AddWithValue("@cidade", pEventos.cidade);
            cmd.Parameters.AddWithValue("@qtd_horas", pEventos.qtd_horas);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(pEventos.data).ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@id_pessoa", pEventos.pessoa);
            cmd.Parameters.AddWithValue("@id_subarea", pEventos.subarea);

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
