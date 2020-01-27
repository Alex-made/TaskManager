//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.SessionState;
//using WebApplication1.Controllers;

//namespace WebApplication1.Util
//{
//    public class CustomControllerFactory : IControllerFactory
//    {
//        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
//        {
//            IRepository repository = new MSSQLRepository();
//            var controller = new HomeController(repository);
//            return controller;
//        }
//        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(
//           System.Web.Routing.RequestContext requestContext, string controllerName)
//        {
//            return SessionStateBehavior.Default;
//        }
//        public void ReleaseController(IController controller)
//        {
//            IDisposable disposable = controller as IDisposable;
//            if (disposable != null)
//                disposable.Dispose();
//        }
//    }
//}