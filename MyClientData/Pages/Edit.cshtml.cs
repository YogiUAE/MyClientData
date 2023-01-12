using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClientData.Pages.Clients;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace MyClientData.Pages
{
    public class EditModel : PageModel
    {


        public ClientsInfo clientss = new ClientsInfo();

        public string errorMessage = "";
        public void OnGet()
        {
            Console.WriteLine("=====edit");

            string id = Request.Query["id"];
            Console.WriteLine(id);

            string constring = "SERVER=localhost;DATABASE=davdb;UID=root;";
            MySqlConnection sqlCon = new MySqlConnection(constring);

            sqlCon.Open();

            string updateStr = "select * from persons where id = '" + id + "'";
            MySqlCommand ecmd = new MySqlCommand(updateStr, sqlCon);
            MySqlDataReader reader = ecmd.ExecuteReader();

            while (reader.Read())
            {

                clientss.id = reader.GetInt32(0);
                clientss.name = reader.GetString(1);
                clientss.email = reader.GetString(2);
                clientss.phone = reader.GetString(3);
                clientss.address = reader.GetString(4);



            }

            sqlCon.Close();


        }

        public void OnPost()
        {
            Console.WriteLine("=====post");

            string id = Request.Form["id"] ;
            Console.WriteLine("id====="+id);
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            string address = Request.Form["address"];

            if(id.Length == 0 || name.Length == 0 || email.Length == 0 ||
                phone.Length == 0 || address.Length == 0) 
            {
                errorMessage = "All the fields are required";
                return;
            }
            string DbCon = "SERVER=localhost;DATABASE=davdb;UID=root;PASSWORD=";
            MySqlConnection edit = new MySqlConnection(DbCon);

            edit.Open();

            string sqlstr = "update  persons  set name = '" + name + "', email = '" + email + "',number ='" + phone + "',address = '" + address + "' where id='" + id + "'";

            MySqlCommand updatetcmd =new MySqlCommand(sqlstr, edit);
            updatetcmd.ExecuteReader();

            Response.Redirect("/client");
            edit.Close();
        }
    }
}
