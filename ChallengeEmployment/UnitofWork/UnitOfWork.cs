using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChallengeEmployment.Models;
using ChallengeEmployment.Models.ViewModel;
using ChallengeEmployment.Repositorio;

namespace ChallengeEmployment.UnitofWork
{
    public class UnitOfWork : IUnitofWork, IDisposable
    {

        NewAppEntities2 context = new NewAppEntities2(); //TKPruebasEntities es el contexto de Entity Framework (Model.Context)

        public UnitOfWork()
        {
            context = new NewAppEntities2();
       
        }
        public UnitOfWork(IRepository<Clients,ClientViewModel> repo)
        {
            repoClient = repo;
        }

        private IRepository<Clients, ClientViewModel> repoClient;

        public IRepository<Clients, ClientViewModel> RepoClient
        {
            get
            {

                if (repoClient == null)
                {
                    repoClient = new RepositoryClient(context);
                }
                return repoClient;
            }
        }

      
        public void Commit()
        {
            context.SaveChanges();
        }

        public bool LazyLoadingEnabled
        {
            get { return context.Configuration.LazyLoadingEnabled; }
            set { context.Configuration.LazyLoadingEnabled = value; }
        }
        public bool ProxyCreationEnabled
        {
            get { return context.Configuration.ProxyCreationEnabled; }
            set { context.Configuration.ProxyCreationEnabled = value; }
        }
        public string ConnectionString
        {
            get { return context.Database.Connection.ConnectionString; }
            set { context.Database.Connection.ConnectionString = value; }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}