using Api.Service.Stock.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Context
{
    public abstract class SharedDbContext : DbContext
    {
        public SharedDbContext()
        {

        }

        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ItensCompra> ItensCompras { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<TipoPagamento> TipoPagamentos { get; set; }
        public virtual DbSet<ItensVenda> ItensVendas { get; set; }

        protected void ApplyConfiguration(ModelBuilder modelBuilder, string[] namespaces)
        {
            var methodInfo = (typeof(ModelBuilder).GetMethods()).Single((e =>
                e.Name == "ApplyConfiguration" &&
                e.ContainsGenericParameters &&
                e.GetParameters().SingleOrDefault()?.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var configType in typeof(MsSqlDbContext).GetTypeInfo().Assembly.GetTypes()

                .Where(t => t.Namespace != null &&
                            namespaces.Any(n => n == t.Namespace) &&
                            t.GetInterfaces().Any(i => i.IsGenericType &&
                                                       i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))))
            {
                var type = configType.GetInterfaces().First();
                methodInfo.MakeGenericMethod(type.GenericTypeArguments[0]).Invoke(modelBuilder, new[]
                {
                    Activator.CreateInstance(configType)
                });
            }
        }
    }
}
