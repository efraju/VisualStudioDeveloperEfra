using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormCibertec.ArtistWeb
{
    public partial class CreateArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
           // var artist = txtName.Text;

        }

        [WebMethod(EnableSession =true)]
        public static bool InsertArtist(string name)
        {
            Artist artist = new Artist()
            {
                Name = name
            };

            using (var unitOfWork =
                new UnitOfWork(new DatabaseContext()))
            {
                unitOfWork.Artists.Add(artist);
                return unitOfWork.Complete() > 0;
            }
        }
    }
}