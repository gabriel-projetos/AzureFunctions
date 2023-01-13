using Api.Service.Stock.Context;
using Api.Service.Stock.Models;
using Interfaces.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Services
{
    [Ioc(Interface = typeof(ClientService))]
    public class ClientService
    {
        private SharedDbContext Context { get; set; }

        public ClientService(SharedDbContext context)
        {
            Context = context;
        }


        public void InsertClient(Cliente client)
        {
            Context.Clientes.Add(client);
            Context.SaveChanges();
        }
    }
}
