using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MVCHotel.CustomFilters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool ejecuta = true;  // Consulta estado SINPE

            if (!ejecuta)
            {
                context.Result = new EmptyResult();
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var userName = context.HttpContext.User.Identity.Name;

            string message = $"La acción {context.ActionDescriptor.DisplayName} " +
                            $"del controlador {context.ActionDescriptor.RouteValues["controller"]} " +
                            $"fue ejecutada por el usuario {userName} el día {DateTime.Now.ToString()}";


            string path = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "log.txt");

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}