using MySql.Data.MySqlClient;
using System.Text;

namespace ConectaDAO
{
    public class Connecta
    {
  
      static StringBuilder StrConn = new StringBuilder();
      static MySqlConnection conn = new MySqlConnection();
      static MySqlCommand cmd = new MySqlCommand();
      static MySqlDataReader dr;
          
       public static void DBName (string pServer,int pPort,string pDB,string pUid,string pPwd)       
       {
           StrConn.Append("Server="+pServer+";");
           StrConn.Append("port="+pPort+";");
           StrConn.Append("Database="+pDB+";");
           StrConn.Append("Uid="+pUid+";");
           StrConn.Append("Pwd="+pPwd+";");
           StrConn.Append("Allow User Variables=True;");
       }

       public static bool Connect()
       { 
           if (conn.State == System.Data.ConnectionState.Closed)           
           {
               
               conn.ConnectionString = StrConn.ToString();
               conn.Open();
           }           
           return true;
       }

       public static bool CommandPersist(MySqlCommand pCmd)
       {
           pCmd.Connection = conn;
           pCmd.ExecuteNonQuery();
           return true;
       }

       public static MySqlDataReader Get(MySqlCommand cmd)
       {
           Connect();
           if (dr != null && !dr.IsClosed)
               dr.Close();
           cmd.Connection = conn;
           dr = cmd.ExecuteReader();
           return dr;

       }
       
    }
}
