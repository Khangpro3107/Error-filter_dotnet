using DI.Filters;
using ErrorHandling.Exceptions;
using ErrorHandling.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers
{
    [GlobalFilter("Controller", -10)]       // this filter is at the controller scope
    public class HomeController : Controller
    {
        // this action and the ones after throw random errors
        [Route("/get-handled-error")]
        public string Get()
        {
            try
            {
                //throw new IOException("IOException");
                //throw new Exception("This is an exception");
                throw new CustomException();
            }
            catch (IOException ex) {
                Console.WriteLine($"IOException: {ex.Message}");
                return $"{ex.Message}";
            } catch (CustomException ex) {
                Console.WriteLine($"CustomException: {ex.Message}");
                return $"{ex.Message}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown exception: {ex.GetType()} {ex.Message}");
                return $"{ex.Message}";
            }
        }

        [Route("/get-unhandled-error")]
        public string GetUnhandled()
        {
            //throw new Exception("This exception is not handled!");
            throw new CustomException();
        }

        [Route("/basic")]
        public string GetBasic()
        {
            try
            {
                /*
                 Code that may throw an exception, like an API call...
                 */

                //throw new IOException("IOException");
                throw new IOException("This is an exception");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IOException: {ex.Message}");
                return $"{ex.Message}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown exception: {ex.Message}");
                return $"{ex.Message}";
            }
            //throw new CustomException();
        }

        [Route("/action-filter")]
        public string ActionFilter()
        {
            //throw new Exception("ActionFilter Exception");
            return "ActionFilter";
        }

        [Route("/global-filter")]
        [GlobalFilter("Action")]        // action-scoped filter
        public string GlobalFilter()
        {
            //throw new Exception("ActionFilter Exception");
            return "GlobalFilter";
        }

        [Route("/async-filter")]
        [AsyncFilter]                   // using an async filter
        public string AsyncFilter()
        {
            Console.WriteLine("Executing AsyncFilter Action");
            return "AsyncFilter";
        }
    }
}
