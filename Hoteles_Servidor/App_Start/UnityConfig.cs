using Hoteles_Servidor.Models;
using Hoteles_Servidor.Repositories;
using Hoteles_Servidor.Services;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Web.Http;
using Unity.WebApi;
using System;
using System.Collections.Generic;
using Hoteles_Servidor.Exceptions;

namespace Hoteles_Servidor
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();


            container.AddNewExtension<Interception>();

            container.RegisterType<IHotelesService, HotelesService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<IHotelesRepository, HotelesRepository>();

            container.RegisterType<IReservasService, ReservasService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<IReservasRepository, ReservasRepository>();         

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public class DBInterceptor : IInterceptionBehavior
        {
            public IMethodReturn Invoke(IMethodInvocation input,
              GetNextInterceptionBehaviorDelegate getNext)
            {
                IMethodReturn result;
                if (ApplicationDbContext.applicationDbContext == null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        ApplicationDbContext.applicationDbContext = context;
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {

                                result = getNext()(input, getNext);


                                if (result.Exception != null)
                                {
                                    throw result.Exception;
                                }
                                context.SaveChanges();

                                dbContextTransaction.Commit();
                            }
                            catch (NoEncontradoException e)
                            {
                                dbContextTransaction.Rollback();
                                ApplicationDbContext.applicationDbContext = null;
                                throw e;
                            }
                            catch (Exception e)
                            {
                                dbContextTransaction.Rollback();
                                ApplicationDbContext.applicationDbContext = null;
                                throw new Exception("He hecho rollback de la transacción", e);
                            }
                        }
                    }
                    ApplicationDbContext.applicationDbContext = null;
                }
                else
                {

                    result = getNext()(input, getNext);


                    if (result.Exception != null)
                    {
                        throw result.Exception;
                    }
                }
                return result;
            }

            public IEnumerable<Type> GetRequiredInterfaces()
            {
                return Type.EmptyTypes;
            }

            public bool WillExecute
            {
                get { return true; }
            }

            private void WriteLog(string message)
            {

            }
            
        }
    }
}