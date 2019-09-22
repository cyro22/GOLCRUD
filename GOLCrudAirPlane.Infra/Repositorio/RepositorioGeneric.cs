using GOLCrudAirplane.Domain.Interfaces;
using GOLCrudAirplane.Infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOLCrudAirplane.Infra.Repositorio
{
    public class RepositorioGeneric<T> : InterfaceGeneric<T>, IDisposable where T : class
    {

        private readonly DbContextOptionsBuilder<ContextoBase> _optionsBuilder;

        public RepositorioGeneric()
        {
            _optionsBuilder = new DbContextOptionsBuilder<ContextoBase>();
        }

        public string Add(T entity)
        {
            using (var AirplaneDb = new ContextoBase(_optionsBuilder.Options))
            {
                try
                {
                    AirplaneDb.Set<T>().Add(entity);
                    AirplaneDb.SaveChanges();

                    return "Registro incluído com sucesso!";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }
        }

        public string Delete(Guid Id)
        {
            using (var AirplaneDb = new ContextoBase(_optionsBuilder.Options))
            {
                try
                {
                    var airplaneRemove = AirplaneDb.Set<T>().Find(Id);

                    AirplaneDb.Set<T>().Remove(airplaneRemove);
                    AirplaneDb.SaveChanges();

                    return "Registro removido com sucesso!";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }
        }


        public async Task<T> GetEntity(Guid id)
        {
            using (var AirplaneDb = new ContextoBase(_optionsBuilder.Options))
            {
                return await AirplaneDb.Set<T>().FindAsync(id);
            }
            
        }

        public List<T> List()
        {
            using (var AirplaneDb = new ContextoBase(_optionsBuilder.Options))
            {
                return AirplaneDb.Set<T>().AsNoTracking().ToList();
            }
        }

        public string Update(T entity)
        {
            using (var AirplaneDb = new ContextoBase(_optionsBuilder.Options))
            {
                try
                {
                    AirplaneDb.Set<T>().Update(entity);
                    AirplaneDb.SaveChanges();

                    return "Registro atualizado com sucesso!";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDispose)
        {
            if (!isDispose) return;
        }

        ~RepositorioGeneric()
        {
            Dispose(false);
        }

    }
}
