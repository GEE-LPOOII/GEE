using GEEData;
using System.Text;
using MySql.Data.MySqlClient;
using ConectaDAO;
using System;
using System.Collections.Generic;

namespace GEERepository
{
    public class EventosRepository
    {

        public static Eventos GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Eventos evento = new Eventos();

            sql.Append("Select * ");
            sql.Append("from eventos ");
            sql.Append(" where id= " + pId);

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                evento.id = (int)dr["id"];
                evento.nome = (string)dr["nome"];
                evento.descricao = (string)dr["descricao"];
                evento.cidade = (string)dr["cidade"];
                evento.qtd_horas = (int)dr["qtd_horas"];
                evento.data = (DateTime)dr["data"];
                
               
            }
            return evento;
        }

        public static List<Eventos> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Eventos> eventos = new List<Eventos>();

            sql.Append("SELECT * ");
            sql.Append("FROM eventos ");
           

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                eventos.Add(
                    new Eventos
                    {
                        id = (int)dr["id"],
                        nome = (string)dr["nome"],
                        descricao = (string)dr["descricao"],
                        cidade = (string)dr["cidade"],
                        qtd_horas = (int)dr["qtd_horas"],
                        data = (DateTime)dr["data"],
                       
                        
                    });
            }
            return eventos;
        }

        public static List<Eventos> GetEventosPendentes()
        {
            StringBuilder sql = new StringBuilder();
            List<Eventos> eventos = new List<Eventos>();

            sql.Append("SELECT e.*, p.nome as pessoa, s.nome as subarea, s.id_area ");
            sql.Append("FROM eventos e ");
            sql.Append("INNER JOIN pessoas p ");
            sql.Append("ON e.id_pessoa=p.id ");
            sql.Append("INNER JOIN subareas s ");
            sql.Append("ON e.id_subarea=s.id ");
            sql.Append("WHERE e.status=0 ");
            sql.Append("ORDER BY id DESC ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                eventos.Add(
                    new Eventos
                    {
                        id = (int)dr["id"],
                        nome = (string)dr["nome"],
                        descricao = (string)dr["descricao"],
                        cidade = (string)dr["cidade"],
                        qtd_horas = (int)dr["qtd_horas"],
                        data = (DateTime)dr["data"],
                        
                        id_pessoa = new Pessoas
                        {
                            nome = (string)dr["pessoa"]
                        },
                        id_subarea = new Subareas
                        {
                            nome = (string)dr["subarea"],
                            id_area = (Areas)dr["s.id_area"]
                        },
                    });
            }
            return eventos;
        }

        public static List<Eventos> GetEventosAprovados()
        {
            StringBuilder sql = new StringBuilder();
            List<Eventos> eventos = new List<Eventos>();

            sql.Append("SELECT e.*, p.nome as pessoa, s.nome as subarea, s.id_area ");
            sql.Append("FROM eventos e ");
            sql.Append("INNER JOIN pessoas p ");
            sql.Append("ON e.id_pessoa=p.id ");
            sql.Append("INNER JOIN subareas s ");
            sql.Append("ON e.id_subarea=s.id ");
            sql.Append("WHERE e.status=1 ");
            sql.Append("ORDER BY id DESC ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = Connecta.Get(cmd);

            while (dr.Read())
            {
                eventos.Add(
                    new Eventos
                    {
                        id = (int)dr["id"],
                        nome = (string)dr["nome"],
                        descricao = (string)dr["descricao"],
                        cidade = (string)dr["cidade"],
                        qtd_horas = (int)dr["qtd_horas"],
                        data = (DateTime)dr["data"],
                        
                        id_pessoa = new Pessoas
                        {
                            nome = (string)dr["pessoa"]
                        },
                        id_subarea = new Subareas
                        {
                            nome = (string)dr["subarea"],
                            id_area = (Areas)dr["s.id_area"]
                        },
                    });
            }
            return eventos;
        }
        
        public bool Create(Eventos pEventos)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO eventos (nome, descricao, cidade, qtd_horas, data, id_pessoa, id_subarea) ");
            sql.Append("VALUES(@nome, @descricao, @cidade, @qtd_horas, @data, @id_pessoa, @id_subarea)");

            cmd.Parameters.AddWithValue("@nome", pEventos.nome);
            cmd.Parameters.AddWithValue("@descricao", pEventos.descricao);
            cmd.Parameters.AddWithValue("@cidade", pEventos.cidade);
            cmd.Parameters.AddWithValue("@qtd_horas", pEventos.qtd_horas);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(pEventos.data).ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@id_pessoa", pEventos.id_pessoa);
            cmd.Parameters.AddWithValue("@id_subarea", pEventos.id_subarea);

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

        public bool Update(Eventos pEventos)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE eventos SET nome=@nome, descricao=@descricao, cidade=@cidade, qtd_horas=@qtd_horas, data=@data, id_pessoa=@id_pessoa, id_subarea=@id_subarea");
            sql.Append("WHERE id=" + pEventos.id);

            cmd.Parameters.AddWithValue("@nome", pEventos.nome);
            cmd.Parameters.AddWithValue("@descricao", pEventos.descricao);
            cmd.Parameters.AddWithValue("@cidade", pEventos.cidade);
            cmd.Parameters.AddWithValue("@qtd_horas", pEventos.qtd_horas);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(pEventos.data).ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@id_pessoa", pEventos.id_pessoa);
            cmd.Parameters.AddWithValue("@id_subarea", pEventos.id_subarea);

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

        public bool UpdateStatus(Eventos pEventos)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE eventos SET status='1' ");
            sql.Append("WHERE id=" + pEventos.id);

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

            sql.Append("DELETE FROM eventos ");
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
