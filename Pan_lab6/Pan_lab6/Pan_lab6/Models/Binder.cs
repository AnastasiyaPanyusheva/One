using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Pan_lab6.Models
{
    public class Binder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Note))
            {

                return new Note(bindingContext.ValueProvider.GetValue("Name").AttemptedValue, bindingContext.ValueProvider.GetValue("Text").AttemptedValue);
                //// call the default model binder this new binding context
                //return base.BindModel(controllerContext, newBindingContext);
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}