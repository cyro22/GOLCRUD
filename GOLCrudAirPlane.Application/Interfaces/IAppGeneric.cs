using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOLCrudAirplane.Application
{
    public interface IAppGeneric<T> where T : class 
    {
        string Add(T entity);
        string Update(T entity);
        string Delete(Guid Id);
        Task<T> GetEntity(Guid id);
        List<T> List();
    }
}
