using RouteHandler.Service;

namespace RouteHandler.RouteHandler
{
    public class MyRouter : IRouter
    {
        private readonly IRouter _router;
        public MyRouter(IRouter router)
        {
            _router = router;
           
        }

        public VirtualPathData? GetVirtualPath(VirtualPathContext context)
        {
            return _router.GetVirtualPath(context);
        }

        public async Task RouteAsync(RouteContext context)
        {
            RouteService route = new RouteService();
            var url = context.HttpContext.Request;
            var result = route.UrlHandler(context.HttpContext.Request.Path);
            if (result.LastOrDefault() == "")
            {
                var routeHandling = route.Routes(result[0]);
                context.RouteData.Values["controller"] = "Home";
                context.RouteData.Values["action"] = "Index";
                await _router.RouteAsync(context);
            }
            else
            {
                var routeHandling = route.Routes(result.LastOrDefault());
                context.RouteData.Values["controller"] = routeHandling.Controller;
                context.RouteData.Values["action"] = routeHandling.Action;
                await _router.RouteAsync(context);
            }
          

           
        }
    }
}
