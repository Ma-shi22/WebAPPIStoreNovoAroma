using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServiceContext : DbContext
    {

        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoCliente> TiposClientes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Producto>()
            .ToTable("Productos");

            builder.Entity<Pedido>(pedido =>
            {
                pedido.ToTable("Pedidos");
                pedido.HasOne<Producto>().WithMany().HasForeignKey(p => p.IdProducto);
                //pedido.HasOne<ProductoItem>().WithMany().HasForeignKey(p => p.Precio);
                pedido.HasOne<Cliente>().WithMany().HasForeignKey(p => p.IdCliente);
            });

            builder.Entity<Persona>()
            .ToTable("Personas");

            builder.Entity<Usuario>(usuario =>
            {
                usuario.ToTable("Usuarios");
                usuario.HasOne<Persona>().WithMany().HasForeignKey(u => u.IdPersona);
                usuario.HasIndex(c => c.IdPersona).IsUnique();
                usuario.HasOne<Rol>().WithMany().HasForeignKey(u => u.IdRol);

            });

            builder.Entity<Cliente>(cliente =>
            {
                cliente.ToTable("Clientes");
                cliente.HasOne<Persona>().WithMany().HasForeignKey(c => c.IdPersona);
                cliente.HasIndex(c => c.IdPersona).IsUnique();

                cliente.HasOne<Rol>().WithMany().HasForeignKey(c => c.IdRol);
                cliente.HasOne<TipoCliente>().WithMany().HasForeignKey(c => c.IdTipoCliente);
            });

            builder.Entity<Rol>()
            .ToTable("Roles");

            builder.Entity<TipoCliente>()
            .ToTable("TiposClientes");

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }

    }


}

