using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria
    {
        /// <summary>
        /// Referencia al contexto de Historia
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioHistoria(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Historia AddHistoria(Historia historia) //crear dueño
        {
            var historiaAdicionado = _appContext.Historias.Add(historia);
            _appContext.SaveChanges();
            return historiaAdicionado.Entity;
        }

        public void DeleteHistoria(int idHistoria)  //borrar dueño
        {
            var historiaEncontrado = _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
            if (historiaEncontrado == null)
                return;
            _appContext.Historias.Remove(historiaEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Historia> GetAllHistorias()  //consultar todos los dueños
        {
               return _appContext.Historias;//return GetAllHistorias_();
        }

        /*public IEnumerable<Historia> GetHistoriaPorFiltro(string filtro) //consultar dueño por filtro
        {
            var historias = GetAllHistorias(); // Obtiene todos los saludos
            if (historias != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    historias = historias.Where(s => s.Id. Contains (filtro));
                }
            }
            return historias;
        }*/

        //public IEnumerable<Dueno> GetAllDuenos_()
        //{
          //  return _appContext.Duenos;
        //}

        public Historia GetHistoria(int idHistoria)
        {
            return _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
        }

        public Historia UpdateHistoria(Historia historia)
        {
            var historiaEncontrado = _appContext.Historias.FirstOrDefault(d => d.Id == historia.Id);
            if (historiaEncontrado != null)
            {
                historiaEncontrado.Id = historia.Id;
                historiaEncontrado.FechaInicial = historia.FechaInicial;
                historiaEncontrado.VisitasPyP= historia.VisitasPyP;
                _appContext.SaveChanges();
            }
            return historiaEncontrado;
        } 


        public VisitaPyP AsignarVisitaPyP(int idHistoria, int idVisitaPyP)
        {
            var historiaEncontrado = _appContext.Historias.FirstOrDefault(p => p.Id == idHistoria);
            if (historiaEncontrado != null)
            {
                var visitaPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(m => m.Id == idVisitaPyP);
                if (visitaPyPEncontrado != null)
                {
                    historiaEncontrado.VisitaPyP = visitaPyPEncontrado;
                    _appContext.SaveChanges();
                }
                return visitaPyPEncontrado;
            }
            return null;
        }      
    }
}

