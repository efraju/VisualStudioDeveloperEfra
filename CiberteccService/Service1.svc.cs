﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccess;
using Models;

namespace CiberteccService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public IEnumerable<Artist> GetArtistList()
        {
            using(var unitOfWork=new UnitOfWork(new DatabaseContext()))
            {
                return unitOfWork.Artists.GetListOfArtistSP();
            }

        }

        public IEnumerable<CustomerInvoice> GetCustomerInvoice(string email,int invoiceId)
        {
            using (var unitOfWork = new UnitOfWork(new DatabaseContext()))
            {
                return unitOfWork.Customers.GetCustomerInvoice(email,invoiceId);
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
