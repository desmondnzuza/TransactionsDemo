using IS.Transactions.Demo.BusinessLogic;
using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Interface.Repository;
using IS.Transactions.Demo.SQL.Repository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace IS.Transactions.Demo.Web.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IPersonRepository, PersonRepository>();
            container.RegisterType<ITransactionRepository, TransactionRepository>();

            container.RegisterType<IAccountOperation, AccountOperation>();
            container.RegisterType<IPersonOperation, PersonOperation>();
            container.RegisterType<ITransactionOperation, TransactionOperation>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}