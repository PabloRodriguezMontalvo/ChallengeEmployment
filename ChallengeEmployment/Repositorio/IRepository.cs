using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ChallengeEmployment.Models.ViewModel;

namespace ChallengeEmployment.Repositorio
{
    public interface IRepository<TModelo, TViewModel>
           where TModelo : class
           where TViewModel : IViewModel<TModelo>
    {
        TViewModel Add(TViewModel model);
        int Borrar(TViewModel model);
        int Borrar(Expression<Func<TModelo, bool>> consulta);
        int Actualizar(TViewModel model);
        ICollection<TViewModel> Get();
        TViewModel Get(int keys);
        ICollection<TViewModel> Get(Expression<Func<TModelo, bool>> consulta);

    }
}