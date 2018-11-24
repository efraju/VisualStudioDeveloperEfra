using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormCibertec
{
    public class Global : HttpApplication
    {
        private ILog _logger;

        public Global()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(typeof(Global));
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

          
            _logger.Debug("Logging is enabled");
            Application["Users"] = 0;


        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["Users"] =(int)Application["Users"] + 1;
            Session["Session1"] = 0;
            NumberOfUsers();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["Users"] = (int)Application["Users"] -1;
            NumberOfUsers();
        }


        protected void Application_Error(object sender,EventArgs e)
        {
            Exception ex = Server.GetLastError();
            //Response.Redirect("http://localhost/WebFormCibertec/Error.aspx");
            _logger = LogManager.GetLogger(typeof(Global));
            _logger.Error(ex);
        }

        private void NumberOfUsers()
        { 
            _logger.Info($"Numero de usuarios conectados: {Application["Users"]}");
        }
    }
}