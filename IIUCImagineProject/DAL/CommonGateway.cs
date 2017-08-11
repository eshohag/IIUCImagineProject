using System.Data.SqlClient;
using System.Web.Configuration;

namespace IIUCImagineProject.DAL
{
    public class CommonGateway
    {
        private string ConnectionString = WebConfigurationManager.ConnectionStrings["IIUCImagineProject"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        public CommonGateway()
        {
            Connection = new SqlConnection(ConnectionString);
        }
    }
}