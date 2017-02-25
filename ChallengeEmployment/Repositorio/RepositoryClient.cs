using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChallengeEmployment.Models;
using ChallengeEmployment.Models.ViewModel;

namespace ChallengeEmployment.Repositorio
{
  
        public partial class RepositoryClient : Repository<Clients, ClientViewModel>
        {
            public RepositoryClient(NewAppEntities2 context)
                : base(context)
            {

            }
        }
    
}