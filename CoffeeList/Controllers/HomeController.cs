using System.Diagnostics;
using System.Xml.Linq;
using CoffeeList.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Entry> entries = new();
        private static Dictionary<string , int> dict = new();

        public HomeController( ILogger<HomeController> logger )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEntry( string Name )
        {
            Entry entry = new Entry( Name );
            if(!entries.Any(e => e.Name == Name )){
                entries.Add( entry );
            }                      

            return PartialView( "Entry" , entries );
        }

        public IActionResult DeleteEntry( string name )
        {
            entries.Remove( entries.Where( p => p.Name == name ).First() );

            return PartialView( "Entry" , entries );
        }

        public IActionResult UpdateEntry( string name, string newname )
        {
            if ( !entries.Any( e => e.Name == newname ) )
            {
                entries.Where( p => p.Name == name ).First().Name = newname;
            }

            return PartialView( "Entry" , entries );
        }

        public IActionResult UpdateCount( string name , int newcount )
        {

            entries.Where( p => p.Name == name ).First().Count = newcount;
            

            return PartialView( "Entry" , entries );
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache( Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true )]
        public IActionResult Error()
        {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}