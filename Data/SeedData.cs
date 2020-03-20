using System;
using System.Linq;
using CitricosCaribe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CitricosCaribe.Data
{
    public static  class SeedData
    {
        public static void Init(IServiceProvider serviceProvider){
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                var productos = new Producto[]
                {
                    new Producto{ID=1, Nombre= "Producto1", Descripcion="Este es el producto1"},
                    new Producto{ID=2, Nombre= "Producto2", Descripcion="Este es el producto2"},
                    new Producto{ID=3, Nombre= "Producto3", Descripcion="Este es el producto3"},
                    new Producto{ID=4, Nombre= "Producto4", Descripcion="Este es el producto4"},
                    new Producto{ID=5, Nombre= "Producto5", Descripcion="Este es el producto5"},
                    new Producto{ID=6, Nombre= "Producto6", Descripcion="Este es el producto6"},
                };

                var empresas = new EmpresaNacional[]
                {
                    new EmpresaNacional{ID=100,Name="Empresa1",Provincia="Provincia1"},
                    new EmpresaNacional{ID=200,Name="Empresa2",Provincia="Provincia2"},
                    new EmpresaNacional{ID=300,Name="Empresa3",Provincia="Provincia3"},
                    new EmpresaNacional{ID=400,Name="Empresa4",Provincia="Provincia4"},
                };

                var pedidos = new Pedido[]
                {
                    new Pedido{ProductoID=1,EmpresaID=100,FechaOferta= DateTime.Parse("2001-09-01"),Cantidad=1},
                    new Pedido{ProductoID=2,EmpresaID=200,FechaOferta= DateTime.Parse("2001-09-02"),Cantidad=2},
                    new Pedido{ProductoID=3,EmpresaID=300,FechaOferta= DateTime.Parse("2001-09-03"),Cantidad=3},
                };

                var trabajadores = new Trabajador[]
                {
                    new Trabajador{CI=1000,Nombre="Bob",Sueldo=1500},
                    new Trabajador{CI=2000,Nombre="Alice",Sueldo=1600},
                    new Trabajador{CI=3000,Nombre="Bob1",Sueldo=1700},
                    new Trabajador{CI=4000,Nombre="Alice1",Sueldo=1800},
                };

                var vehiculos = new Vehiculo[]
                {
                    new Vehiculo{ID=5000,Marca="Marca1",Modelo="Modelo1",Motor="Motor1"},
                    new Vehiculo{ID=6000,Marca="Marca2",Modelo="Modelo2",Motor="Motor2"},
                    new Vehiculo{ID=7000,Marca="Marca3",Modelo="Modelo3",Motor="Motor3"},
                    new Vehiculo{ID=8000,Marca="Marca4",Modelo="Modelo4",Motor="Motor4"},
                };

                var medios = new Medio[]
                {
                    new Medio{ID=9000,Nombre="Medio1"},
                    new Medio{ID=10000,Nombre="Medio2"},
                    new Medio{ID=11000,Nombre="Medio3"},
                    new Medio{ID=12000,Nombre="Medio4"},
                };

                var direcciones = new Direccion[]
                {
                    new Direccion{ID=13,Tipo="Tipo1"},
                    new Direccion{ID=14,Tipo="Tipo2"},
                    new Direccion{ID=15,Tipo="Tipo3"},
                    new Direccion{ID=16,Tipo="Tipo4"},
                };

                var frigorificos = new Frigorifico[]
                {
                    new Frigorifico{ID=21,Nombre="Frigorifico1",Direccion="Direccion1"},
                    new Frigorifico{ID=22,Nombre="Frigorifico2",Direccion="Direccion2"},
                    new Frigorifico{ID=23,Nombre="Frigorifico3",Direccion="Direccion3"},
                    new Frigorifico{ID=24,Nombre="Frigorifico4",Direccion="Direccion4"},
                };

                var bases = new BaseTransporte[]
                {
                    new BaseTransporte{ID=31,Direccion="Direccionf1",Nombre="Nombref1"},
                    new BaseTransporte{ID=32,Direccion="Direccionf2",Nombre="Nombref2"},
                    new BaseTransporte{ID=33,Direccion="Direccionf3",Nombre="Nombref3"},
                    new BaseTransporte{ID=34,Direccion="Direccionf4",Nombre="Nombref4"},
                };

                if(!context.Productos.Any()){
                    foreach(var p in productos)
                        context.Productos.Add(p);
                    foreach(var e in empresas)
                        context.Empresas.Add(e);
                    foreach(var p in pedidos)
                        context.Pedidos.Add(p);
                    foreach(var t in trabajadores)
                        context.Trabajadores.Add(t);
                    foreach(var v in vehiculos)
                        context.Vehiculos.Add(v);
                    foreach(var m in medios)
                        context.Medios.Add(m);
                    foreach(var d in direcciones)
                        context.Direcciones.Add(d);
                    foreach(var f in frigorificos)
                        context.Frigorificos.Add(f);
                    foreach(var b in bases)
                        context.BasesTransportes.Add(b);
                    context.SaveChanges();
                
                }

            
            }
        }
        
    }
}