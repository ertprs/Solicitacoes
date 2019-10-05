
using System.Data.SqlClient;

namespace Repository.Contexto
{
    public class Context
    {

        public SqlConnection getConnection()
        {
           SqlConnection conn = new SqlConnection("Data Source=DESKTOP-N4OBCPJ\\SQLEXPRESS;Initial Catalog=ProjetoModelo;Integrated Security=True");
           return conn;
        }
    }
}
