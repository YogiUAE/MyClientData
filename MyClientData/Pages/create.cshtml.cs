using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClientData.Pages.Clients;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MyClientData.Pages
{
    public class createModel : PageModel
    {
        public string name = "";
        public string email = "";
        public string phone = "";
        public string address = "";

        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Console.WriteLine("=====post"  +successMessage);
            name = Request.Form["name"];
            email = Request.Form["email"];
            phone = Request.Form["phone"];
            address = Request.Form["address"];

            if(name.Length == 0 || email.Length == 0 ||
                phone.Length == 0 || address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }
            string myDbConnection = "SERVER=localhost;DATABASE=davdb;UID=root;PASSWORD=";
            MySqlConnection creatdata = new MySqlConnection(myDbConnection);

            creatdata.Open();

            string sqlstr = "insert into persons (name,email,number,address) Values('" + name + "','" + email + "'," +
                "'" + phone + "','" + address + "')";

            MySqlCommand insertcmd =new MySqlCommand(sqlstr, creatdata);
            insertcmd.ExecuteReader();

           




            //save the new client into database
            name ="";
            email ="";
            phone ="";
            address = "";
            successMessage = "New Client Added successfully";

            Response.Redirect("/client");
            creatdata.Close();
        }
    }
}
