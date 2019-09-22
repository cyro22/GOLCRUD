using GOLCrudAirplane.Domain.Entidades;
using GOLCrudAirplane.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOLCrudAirplane.Application
{
    public class ApplicationAirplane : IAppAirplane
    {
        InterfaceAirplane _interfaceAirplane;

        public ApplicationAirplane(InterfaceAirplane interfaceAirplane)
        { 
            _interfaceAirplane = interfaceAirplane;
        }

        public string Add(Airplane entity)
        {
           return _interfaceAirplane.Add(entity);
        }

        public string Delete(Guid Id)
        {
           return _interfaceAirplane.Delete(Id);
        }

        public async Task<Airplane> GetEntity(Guid id)
        {
            return await _interfaceAirplane.GetEntity(id);
            
        }

        public List<Airplane> List()
        {
            return _interfaceAirplane.List();
        }

        public string Update(Airplane entity)
        {
            return _interfaceAirplane.Update(entity);
        }
    }
}
