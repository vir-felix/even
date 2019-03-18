﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using RoastedMarketplace.Core.Infrastructure;
using RoastedMarketplace.Data.Extensions;

namespace RoastedMarketplace.Infrastructure.ViewEngines
{
    public class DefaultAppViewEngine : IAppViewEngine
    {
        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            if (!viewName.StartsWith("Components"))
            {
                var controller = context.ActionDescriptor.RouteValues["controller"];
                viewName = $"{controller}/{viewName}";
            }

            return GetView(viewName, isMainPage);
        }

        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            return GetView(viewPath, isMainPage);
        }

        private ViewEngineResult GetView(string viewName, bool isMainPage)
        {
            var viewAccountant = DependencyResolver.Resolve<IViewAccountant>();
            var viewFilePath = viewAccountant.GetThemeViewPath(viewName);
            if (!viewFilePath.IsNullEmptyOrWhiteSpace())
            {
                return ViewEngineResult.Found(viewFilePath, new RoastedLiquidView(viewFilePath, viewName, viewAccountant));
            }
            return ViewEngineResult.NotFound(viewName, viewAccountant.GetSearchLocations());
        }
    }
}