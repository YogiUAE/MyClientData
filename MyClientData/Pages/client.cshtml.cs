using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace MyClientData.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientsInfo> ClientData = new List<ClientsInfo>();
        public void OnGet()
        {
            string myDbConnection = "SERVER=localhost;DATABASE=davdb;UID=root;";
            MySqlConnection clientdata = new MySqlConnection(myDbConnection);

            clientdata.Open();
            string clientstr = "select * from persons";
            MySqlCommand cmddata = new MySqlCommand(clientstr, clientdata);
            MySqlDataReader userreader = cmddata.ExecuteReader();

            while (userreader.Read())
            {

                ClientsInfo client = new ClientsInfo();

              
                client.id = userreader.GetInt32(0);
                client.name = userreader.GetString(1);
                
                client.email = userreader.GetString(2);
                client.phone = userreader.GetString(3);
                client.address = userreader.GetString(4);
                client.created_at = userreader.GetDateTime(5).ToString();


                ClientData.Add(client);
            }
            clientdata.Close();

        }
    }


    public class ClientsInfo
    {
        public int id ;
        public string name ;
        public string email ;
        public string phone ;
        public string address ;
        public string created_at;
    }

}
