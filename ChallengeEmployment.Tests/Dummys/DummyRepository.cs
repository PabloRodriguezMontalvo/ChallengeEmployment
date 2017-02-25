using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ChallengeEmployment.Models;
using ChallengeEmployment.Models.ViewModel;
using ChallengeEmployment.Repositorio;

namespace ChallengeEmployment.Tests.Dummys
{
    class DummyRepository:IRepository<Clients,ClientViewModel>
    {
        List<ClientViewModel> d_clients = null;
        public DummyRepository(List<ClientViewModel> clients)
        {
            d_clients = clients;
        }
        public ClientViewModel Add(ClientViewModel model)
        {
           
           
            d_clients.Add(model);
            return model;
        }

        public int Borrar(ClientViewModel model)
        {
          
            d_clients.Remove(model);
            return model.id;
        }

        public int Borrar(Expression<Func<Clients, bool>> consulta)
        {
            var list = d_clients.Where((Func<ClientViewModel, bool>) consulta.Compile());
     
            var result= d_clients.Except(list.ToList());

            return result.Count();
        }

        public int Actualizar(ClientViewModel model)
        {
           
        d_clients.FirstOrDefault(d => d.id == model.id).Tel=model.Tel;
        d_clients.FirstOrDefault(d => d.id == model.id).Birthday=model.Birthday;
        d_clients.FirstOrDefault(d => d.id == model.id).Country =model.Country;
        d_clients.FirstOrDefault(d => d.id == model.id).DNI =model.DNI;
        d_clients.FirstOrDefault(d => d.id == model.id).Email =model.Email;
        d_clients.FirstOrDefault(d => d.id == model.id).Name =model.Name;
        d_clients.FirstOrDefault(d => d.id == model.id).Surname =model.Surname;

         
            return model.id;

        }

        public ICollection<ClientViewModel> Get()
        {
          
            return d_clients;
        }

        public ClientViewModel Get(int keys)
        {
            var model= d_clients.Find(o=>o.id==keys);
         
           
        
            return model;
        }

        public ICollection<ClientViewModel> Get(Expression<Func<Clients, bool>> consulta)
        {
            var list = d_clients.Where((Func<ClientViewModel, bool>) consulta.Compile());
        
            return (ICollection<ClientViewModel>) list;
        }
    }
}
