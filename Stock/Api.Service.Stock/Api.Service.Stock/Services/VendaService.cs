using Api.Service.Stock.Context;
using Api.Service.Stock.Models;
using Interfaces.Annotations;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Services
{
    [Ioc(Interface = typeof(VendaService))]
    public class VendaService
    {
        private SharedDbContext Context { get; set; }

        public VendaService(SharedDbContext context)
        {
            Context = context;
        }


        public async Task<List<ITipoPagamento>> GetTipoPagamentos()
        {
            //return await Context.TipoPagamentos.ToListAsync<ITipoPagamento>();

            var tipoPag = new TipoPagamento
            {
                RolesCanRead = RoleType.Viewer | RoleType.Anonymous
            };

            IQueryable<TipoPagamento> query = null;

            query = Context.TipoPagamentos.AsQueryable();

            //query = query.Where(p => tipoPag.RolesCanRead.ToString().Contains(p.RolesCanRead.ToString()));
            //query = query.Where(p => ((byte)tipoPag.RolesCanRead & (byte)p.RolesCanRead) > 0);
            //query = query.Where(p => (tipoPag.RolesCanRead & p.RolesCanRead) != 0);
            query = query.Where(p => p.RolesCanRead.HasFlag(RoleType.Viewer));

            //Context.TipoPagamentos.
            //Context.SaveChanges();



            var result = await query.ToListAsync<ITipoPagamento>().ConfigureAwait(false);
            return result;
        }
    }
}
