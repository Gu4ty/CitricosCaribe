using Microsoft.EntityFrameworkCore;
using CitricosCaribe.Models;

namespace CitricosCaribe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Producto> Productos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<EmpresaNacional> EmpresasNacionales { get; set; }

        public DbSet<EmpresaExtranjera> EmpresasExtranjeras { get; set; }

        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Medio> Medios { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Frigorifico> Frigorificos { get; set; }
        public DbSet<BaseTransporte> BasesTransportes { get; set; }
        public DbSet<VehiculoAsignado> VehiculosAsignados { get; set; }
        
        public DbSet<MedioAsignado> MediosAsignados { get; set; }
        public DbSet<TipoDireccionTrabajador> TipoDireccionTrabajadores { get; set; }
        public DbSet<TipoDireccionBaseTransporte> TipoDireccionBaseTransportes { get; set; }
        public DbSet<TipoDireccionFrigorifico> TipoDireccionFrigorificos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }

        public DbSet<ContratoCompraInternacional> ContratosComprasInternacionales { get; set; }
        public DbSet<ContratoVentaNacional> ContratosVentasNacionales { get; set; }
        public DbSet<ContratoVentaInternacional> ContratosVentasInternacionales { get; set; }
        public DbSet<ContratoCompraNacional> ContratosComprasNacionales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            
            

            modelBuilder.Entity<Producto>()
                .Property(p=>p.Nombre)
                .IsRequired();


            modelBuilder.Entity<Trabajador>()
                .HasKey(t => t.CI);

            modelBuilder.Entity<VehiculoAsignado>()
                .HasKey(v => v.VehiculoID);
            modelBuilder.Entity<VehiculoAsignado>()
                .HasOne(v => v.Vehiculo)
                .WithOne(v => v.VehiculoAsignado)
                .IsRequired()
                .HasForeignKey<VehiculoAsignado>(v => v.VehiculoID);
            modelBuilder.Entity<VehiculoAsignado>()
                .HasOne(v => v.Trabajador)
                .WithOne(t => t.VehiculoAsignado)
                .HasForeignKey<VehiculoAsignado>(v => v.TrabajadorID);
               
            
            modelBuilder.Entity<MedioAsignado>()
                .HasKey(m => new{m.TrabajadorID,m.MedioID});

            modelBuilder.Entity<MedioAsignado>()
                .HasOne(m => m.Medio)
                .WithMany(m => m.MedioAsignado)
                .HasForeignKey(m => m.MedioID);
            modelBuilder.Entity<MedioAsignado>()
                .HasOne(m => m.Trabajador)
                .WithMany(t => t.MedioAsignado)
                .HasForeignKey(m => m.TrabajadorID);

            modelBuilder.Entity<TipoDireccionTrabajador>()
                .HasKey(t => t.TrabajadorID);
            modelBuilder.Entity<TipoDireccionTrabajador>()
                .HasOne(t => t.Direccion)
                .WithMany(d => d.TipoDireccionTrabajador)
                .HasForeignKey(t => t.DireccionID);
            modelBuilder.Entity<TipoDireccionTrabajador>()
                .HasOne(t => t.Trabajador)
                .WithOne(t => t.TipoDireccionTrabajador)
                .IsRequired()
                .HasForeignKey<TipoDireccionTrabajador>(t => t.TrabajadorID);
                
            modelBuilder.Entity<TipoDireccionBaseTransporte>()
                .HasKey(t => t.BaseTransporteID);
            modelBuilder.Entity<TipoDireccionBaseTransporte>()
                .HasOne(t => t.Direccion)
                .WithMany(d => d.TipoDireccionBaseTransportes)
                .HasForeignKey(t => t.DireccionID);
            modelBuilder.Entity<TipoDireccionBaseTransporte>()
                .HasOne(t => t.BaseTransporte)
                .WithOne(t => t.TipoDireccionBaseTransporte)
                .IsRequired()
                .HasForeignKey<TipoDireccionBaseTransporte>(t => t.BaseTransporteID);
            
            modelBuilder.Entity<TipoDireccionFrigorifico>()
                .HasKey(t => t.FrigorificoID);
            modelBuilder.Entity<TipoDireccionFrigorifico>()
                .HasOne(t => t.Direccion)
                .WithMany(d => d.TipoDireccionFrigorificos)
                .HasForeignKey(t => t.DireccionID);
            modelBuilder.Entity<TipoDireccionFrigorifico>()
                .HasOne(t => t.Frigorifico)
                .WithOne(f => f.TipoDireccionFrigorifico)
                .IsRequired()
                .HasForeignKey<TipoDireccionFrigorifico>(t => t.FrigorificoID);

            modelBuilder.Entity<Solicitud>()
                .HasKey(s => new{s.ProductoID,s.EmpresaID,s.FechaOferta});
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Producto)
                .WithMany(p => p.Solicitudes)
                .HasForeignKey(s => s.ProductoID);
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Solicitudes)
                .HasForeignKey(s => s.EmpresaID);
            
            modelBuilder.Entity<Pedido>()
                .HasKey(s => new{s.ProductoID,s.EmpresaID,s.FechaOferta});
            modelBuilder.Entity<Pedido>()
                .HasOne(s => s.Producto)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(s => s.ProductoID);
            modelBuilder.Entity<Pedido>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Pedidos)
                .HasForeignKey(s => s.EmpresaID);
            
            modelBuilder.Entity<Oferta>()
                .HasKey(s => new{s.ProductoID,s.EmpresaID,s.FechaOferta});
            modelBuilder.Entity<Oferta>()
                .HasOne(s => s.Producto)
                .WithMany(p => p.Ofertas)
                .HasForeignKey(s => s.ProductoID);
            modelBuilder.Entity<Oferta>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Ofertas)
                .HasForeignKey(s => s.EmpresaID);
            
            modelBuilder.Entity<ContratoCompraInternacional>()
                .HasKey(c => new{c.EmpresaID,c.TrabajadorID,c.ProductoID,c.FechaContrato,c.FechaOferta});
            modelBuilder.Entity<ContratoCompraInternacional>()
                .HasOne(c => c.Empresa)
                .WithMany(e => e.ContratoCompraInternacionales)
                .HasForeignKey(c => c.EmpresaID);
            modelBuilder.Entity<ContratoCompraInternacional>()
                .HasOne(c => c.Producto)
                .WithMany(p => p.ContratoCompraInternacionales)
                .HasForeignKey(c => c.ProductoID);
            modelBuilder.Entity<ContratoCompraInternacional>()
                .HasOne(c => c.Trabajador)
                .WithMany(t => t.ContratoCompraInternacionales)
                .HasForeignKey(c => c.TrabajadorID);

            modelBuilder.Entity<ContratoVentaNacional>()
                .HasKey(c => new{c.EmpresaID,c.TrabajadorID,c.ProductoID,c.FechaContrato,c.FechaSolicitud});
            modelBuilder.Entity<ContratoVentaNacional>()
                .HasOne(c => c.Empresa)
                .WithMany(e => e.ContratoVentaNacionales)
                .HasForeignKey(c => c.EmpresaID);
            modelBuilder.Entity<ContratoVentaNacional>()
                .HasOne(c => c.Producto)
                .WithMany(p => p.ContratoVentaNacionales)
                .HasForeignKey(c => c.ProductoID);
            modelBuilder.Entity<ContratoVentaNacional>()
                .HasOne(c => c.Trabajador)
                .WithMany(t => t.ContratoVentaNacionales)
                .HasForeignKey(c => c.TrabajadorID);

            modelBuilder.Entity<ContratoVentaInternacional>()
                .HasKey(c => new{c.EmpresaID,c.TrabajadorID,c.ProductoID,c.FechaContrato,c.FechaPedido});
            modelBuilder.Entity<ContratoVentaInternacional>()
                .HasOne(c => c.Empresa)
                .WithMany(e => e.ContratoVentaInternacionales)
                .HasForeignKey(c => c.EmpresaID);
            modelBuilder.Entity<ContratoVentaInternacional>()
                .HasOne(c => c.Producto)
                .WithMany(p => p.ContratoVentaInternacionales)
                .HasForeignKey(c => c.ProductoID);
            modelBuilder.Entity<ContratoVentaInternacional>()
                .HasOne(c => c.Trabajador)
                .WithMany(t => t.ContratoVentaInternacionales)
                .HasForeignKey(c => c.TrabajadorID);

            modelBuilder.Entity<ContratoCompraNacional>()
                .HasKey(c => new{c.EmpresaID,c.TrabajadorID,c.ProductoID,c.FechaContrato,c.FechaPedido});
            modelBuilder.Entity<ContratoCompraNacional>()
                .HasOne(c => c.Empresa)
                .WithMany(e => e.ContratoCompraNacionales)
                .HasForeignKey(c => c.EmpresaID);
            modelBuilder.Entity<ContratoCompraNacional>()
                .HasOne(c => c.Producto)
                .WithMany(p => p.ContratoCompraNacionales)
                .HasForeignKey(c => c.ProductoID);
            modelBuilder.Entity<ContratoCompraNacional>()
                .HasOne(c => c.Trabajador)
                .WithMany(t => t.ContratoCompraNacionales)
                .HasForeignKey(c => c.TrabajadorID);
            
            
        }
    }
}
