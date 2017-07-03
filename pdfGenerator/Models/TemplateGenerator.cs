using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplateViewRenderExample.TemplateHandler
{
    public static class TemplateGenerator
    {
    public static string RenderPartialViewToString(Controller controller, string viewName, object model)
    {
        controller.ViewData.Model = model;
        using (StringWriter sw = new StringWriter())
        {
            ViewEngineResult viewResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);
            ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData,
                controller.TempData, sw);
            viewResult.View.Render(viewContext, sw);

            return sw.ToString();
        }
    }
}
}
