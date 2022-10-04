namespace RouteHandler.Service
{
    public interface IRouteService
    {
        string[] UrlHandler(string url);
        RoutesClass Routes(string route);
    }
    public class RouteService : IRouteService
    {

        public RoutesClass Routes(string route)
        {
            List<RoutesClass> routes = new List<RoutesClass>()
            {
                new RoutesClass(){Action="Index",Controller="Home",Slug="/"},
                new RoutesClass(){Action="Privacy",Controller="Home",Slug="Hakkimizda"},
            };
            return routes.Where(x => x.Slug == route).FirstOrDefault();
        }

        public string[] UrlHandler(string url)
        {
           return url.Split('/');
        }
    }
    public class RoutesClass
    {
        public string Slug { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
