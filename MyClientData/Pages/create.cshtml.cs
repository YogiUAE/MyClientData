using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClientData.Pages.Clients;

namespace MyClientData.Pages
{
    public class createModel : PageModel
    {
        public ClientsInfo cinfo = new ClientsInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            cinfo.name = Request.Form["name"];
            cinfo.name = Request.Form["email"];
            cinfo.name = Request.Form["phone"];
            cinfo.name = Request.Form["address"];

            if(cinfo.name.Length == 0 || cinfo.email.Length == 0 ||
                cinfo.phone.Length == 0 || cinfo.address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //save the new client into database
            cinfo.name ="";
            cinfo.name ="";
            cinfo.name ="";
            cinfo.name = "";
            successMessage = "New Client Added successfully"
        }
    }
}
