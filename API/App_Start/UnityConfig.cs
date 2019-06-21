using BusinessLogic.Service;
using BusinessLogic.Service.Application;
using Common.Repository;
using Common.Repository.Application;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. 

            //this is for repository
            container.RegisterType<IHandoverRepository, HandoverRepository>();
            container.RegisterType<IReturnRepository, ReturnRepository>();
            container.RegisterType<IParameterRepository, ParameterRepository>();
            container.RegisterType<ITypeItemRepository, TypeItemRepository>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<IConditionRepository, ConditionRepository>();
            container.RegisterType<IItemRepository, ItemRepository>();
            container.RegisterType<IProcurementRepository, ProcurementRepository>();
            container.RegisterType<ILoaningRepository, LoaningRepository>();


            //this is for service
            container.RegisterType<IHandoverService, HandoverService>();
            container.RegisterType<IReturnService, ReturnService>();
            container.RegisterType<IParameterService, ParameterService>();
            container.RegisterType<ITypeItemService, TypeItemService>();
            container.RegisterType<ILocationService, LocationService>();
            container.RegisterType<IConditionService, ConditionService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IProcurementService, ProcurementService>();
            container.RegisterType<ILoaningService, LoaningService>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}