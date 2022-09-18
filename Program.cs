using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;
namespace MascotaFeliz.App.Consola
{
   class Program
    {
  

        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        private static IRepositorioVisitaPyP _repoVisitaPyp = new RepositorioVisitaPyP(new Persistencia.AppContext());


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
          // AddDueno();   
           //BuscarDueno(6);
          // ListarDuenosFiltro();
           //ListarDuenos();
          // EliminarDueno();



          // AddVeterinario(); 
            
           //BuscarVeterinario(7);
          // ListarVeterinariosFiltro();
          // ListarVeterinarios();
            //EliminarVeterinario(7);


             //AddMascota();
           // BuscarMascota(5);
         // ListarMascotasFiltro();
           //ListarMascotas();
           // EliminarMascota(3);


          // AddHistoria() ;
            //BuscarHistoria();
           // ListarHistorias();
           // EliminarHistoria(1);

//////////////////////////////////////////
   // AsignarDueno();
          // AsignarVeterinario();
          // AsignarHistoria();
         // AddVisitaPyP();
          AsignarVisitaPyP();

        }

         private static void AsignarVeterinario() //asignar veterinario
    {
        var veterinario = _repoMascota.AsignarVeterinario(1, 2);
        Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos+"  ");

    }

    private static void AsignarDueno() //asignar Dueno
    {
        var dueno = _repoMascota.AsignarDueno(1,1);

        Console.WriteLine(dueno.Nombres + " " +dueno.Apellidos+"  ");

    }

    private static void AddVisitaPyP() //crear visitaPyP
        {
            var visitaPyP= new VisitaPyP
            {
             FechaVisita= new DateTime(2022,08,23),
            Temperatura= 34.6F,
            Peso = 45.3F,
            FrecuenciaRespiratoria= 38.5F,
            FrecuenciaCardiaca= 76.8F,
            EstadoAnimo="Decaido",
            Recomendaciones= "cuidados en casa"
            };
            _repoVisitaPyp.AddVisitaPyP(visitaPyP);

        }


    private static void AsignarVisitaPyP() //asignar Dueno
    {
        var visitaPyP = _repoHistoria.AsignarVisitaPyP(2,1);

        Console.WriteLine(visitaPyP.FechaVisita+ " " +VisitaPyP.Recomendaciones+"  ");

           
/*
     private static void AsignarVisitaPyP(int idHistoria, int VisitaPyP) // asignar visita
           
            {
                var historia = _repoHistoria.GetHistoria(idHistoria);
                if(historia != null)
                {
                    if (historia.VisitaPyP != null)
                    {
                    historia.VisitaPyP.Add(new VisitaPyP{ FechaVisita= new DateTime(2022,08,23),Temperatura= 34.6F, Peso = 45.3F, FrecuenciaRespiratoria= 38.5F, FrecuenciaCardiaca= 76.8F, EstadoAnimo="Delicado", Recomendaciones= "cuidados en casa"});

                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>(
                        new VisitaPyP{FechaVisita= new DateTime(2022,08,23),
                        Temperatura= 34.6F,
                        Peso = 45.3F,
                        FrecuenciaRespiratoria= 38.5F,
                        FrecuenciaCardiaca= 76.8F,
                        EstadoAnimo="Delicado",
                        Recomendaciones= "cuidados en casa"
                        });

                    };
                

                }
                _repoHistoria.UpdateHistoria(historia);
            }

  */      
    private static void AsignarHistoria() // asignar historia
    {
        var historia = _repoMascota.AsignarHistoria(1,2);
         Console.WriteLine(historia.FechaInicial+" ");

    }
 



///////////////////////////////////////////////////
        
        private static void AddDueno() // crear dueño
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "Jesus",
                Apellidos = "Arevalo",
                Direccion = "maridiaz",
                Telefono = "3123345348",
                Correo = "jesar@gmail.com"
            };
            _repoDueno .AddDueno(dueno);
        }


       

        private static void BuscarDueno(int idDueno) //consultar dueño
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres+" "+dueno.Apellidos+" "+dueno.Direccion+" "+dueno.Telefono+" "+dueno.Correo+" ");
        }
               
     private static void ListarDuenos() //consultar lista de dueños 
        {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno d in duenos)
            {

            Console.WriteLine(d.Nombres+" "+d.Apellidos+" ");
            }

        }


     private static void ListarDuenosFiltro() //consultar Dueños por filtro
         {
            var duenosm = _repoDueno.GetDuenosPorFiltro("J");
            foreach (Dueno m in duenosm)
            {

            Console.WriteLine(m.Nombres+" "+m.Apellidos+" " );
            }


            } 


     private static void EliminarDueno (int idDueno) // eliminar dueño
     {
        _repoDueno.DeleteDueno(idDueno);
          Console.WriteLine("Dueño Eliminado");


     }       
//////////////////////////////////////////////////////////


     private static void AddVeterinario() // crear veterinario
        {
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Nombres = "Armando",
                Apellidos = "Casas",
                Direccion = "Sprinfield",
                Telefono = "1223874590",
                TarjetaProfesional = "TP12363434645"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }
     
     
     private static void BuscarVeterinario(int idVeterinario) //consultar veterinario
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres+" "+veterinario.Apellidos+" "+veterinario.Direccion+" "+veterinario.Telefono+" "+veterinario.TarjetaProfesional+" ");
        }
        

     private static void ListarVeterinarios() //consultar lista de veterinarios
        {
            var veterinarios = _repoVeterinario.GetAllVeterinarios();
            foreach (Veterinario v in veterinarios)
            {

            Console.WriteLine(v.Nombres+" "+v.Apellidos+" "+v.TarjetaProfesional+" ");
            }

        }

        private static void ListarVeterinariosFiltro() //consultar veterinarios por filtro
         {
            var veterinariosm = _repoVeterinario.GetVeterinariosPorFiltro("E");
            foreach (Veterinario m in veterinariosm)
            {

            Console.WriteLine(m.Nombres+" "+m.TarjetaProfesional+" " );
            }


            }  


        
     private static void EliminarVeterinario (int idVeterinario) // eliminar veterinario
     {
        _repoVeterinario.DeleteVeterinario(idVeterinario);
          Console.WriteLine("veterinario Eliminado");


     }       

   
//////////////////////////////////////////////////////////
        
        private static void AddMascota()  // crear mascota
        {
            var mascota = new Mascota
            {
                
                Nombre = "Pacncho",
                Color = "blanco-negro",
                Especie = "canino",
                Raza = "Dalmata",
                
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void BuscarMascota(int idMascota) //consultar mascota
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre+" "+mascota.Color+" "+mascota.Especie+" "+mascota.Raza+" ");
        }
    
     private static void ListarMascotas() //listar mascotas
        {
            var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascotas)
            {

            Console.WriteLine(m.Nombre+" "+m.Especie+" ");
            }

        }

     private static void ListarMascotasFiltro() //consultar mascotas por filtro
         {
         var mascotasm = _repoMascota.GetMascotasPorFiltro("Pe");
            foreach (Mascota m in mascotasm)
            {

            Console.WriteLine(m.Nombre+" ");
            }


      } 

     
     private static void EliminarMascota (int idMascota) // eliminar mascota
     {
        _repoMascota.DeleteMascota(idMascota);
          Console.WriteLine("Mascota Eliminado");


     }       

    //////////////////////////////////////////// historia no se puede listarpor filtro
     private static void AddHistoria() // agregar historia
     {
        var historia= new Historia
        {
            FechaInicial= new DateTime (2022, 07, 23)
        };
        _repoHistoria.AddHistoria(historia);


     }
     
      private static void BuscarHistoria(int idHistoria) //consultar mascota
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            Console.WriteLine(historia.Id+" "+historia.FechaInicial+" ");
        }



    private static void ListarHistorias() //consultar lista de historias
        {
            var historias = _repoHistoria.GetAllHistorias();
            foreach (Historia d in historias)
            {

            Console.WriteLine(d.FechaInicial+" "+d.Id+" ");
            }

        }


    
     private static void EliminarHistoria (int idHistoria) // eliminar historia
     {
        _repoHistoria.DeleteHistoria(idHistoria);
          Console.WriteLine("historia Eliminada");


     }       
    } 
}
