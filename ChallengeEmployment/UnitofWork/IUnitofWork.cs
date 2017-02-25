using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeEmployment.UnitofWork
{
    public interface IUnitofWork
    {
        void Commit();
        bool LazyLoadingEnabled { get; set; }
        bool ProxyCreationEnabled { get; set; }
        string ConnectionString { get; set; }
    }
}