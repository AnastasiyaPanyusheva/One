using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pan_lab6.Models
{
    public class ActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            Log(controllerName.ToString(), actionName.ToString(), DateTime.Now);
        }
        private void Log(string messageType, string messageText, DateTime messageDate){
            using (var connection = new SqlConnection(@"Data Source=VAIO\VAIO;Initial Catalog=IntProgLog;Integrated Security=True"))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO [Log] (controller, action, date) VALUES (@controller, @action, @date);";

                    command.Parameters.AddWithValue("@controller", messageType);
                    command.Parameters.AddWithValue("@action", messageText);
                    command.Parameters.AddWithValue("@date", messageDate);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}