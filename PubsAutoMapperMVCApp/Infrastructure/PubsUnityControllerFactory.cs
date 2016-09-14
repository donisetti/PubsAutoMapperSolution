using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using PubsAutoMapperMVCApp.DataContexts;
using PubsAutoMapperMVCApp.Models;
using PubsDomainLibrary.Abstract;
using PubsDomainLibrary.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PubsAutoMapperMVCApp.Infrastructure
{
    public class PubsUnityControllerFactory: DefaultControllerFactory
    {
        IUnityContainer _unityContainer;
        public PubsUnityControllerFactory()
        {
            _unityContainer = new UnityContainer();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : _unityContainer.Resolve(controllerType) as IController;
        }

        private void AddBindings()
        {
            _unityContainer.RegisterType<IBookRepository, EfBookRepository>();
            _unityContainer.RegisterType<IAuthorRepository, EfAuthorRepository>();

            //Identity Security
            _unityContainer.RegisterType<UserManager<ApplicationUser>>();
            _unityContainer.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            _unityContainer.RegisterType<DbContext, ApplicationDbContext>();
            _unityContainer.RegisterType<Controllers.AccountController>(new InjectionConstructor());
        }
    }
}