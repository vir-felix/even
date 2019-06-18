﻿using EvenCart.Data.Extensions;
using EvenCart.Infrastructure;
using EvenCart.Infrastructure.Mvc;
using EvenCart.Infrastructure.Routing;
using EvenCart.Infrastructure.ViewEngines;
using Microsoft.AspNetCore.Mvc;

namespace EvenCart.Areas.Administration.Controllers
{
    /// <summary>
    /// Allows store admins to view dashboard summaries
    /// </summary>
    public class DashboardController : FoundationAdminController
    {
        private readonly IViewAccountant _viewAccountant;
        public DashboardController(IViewAccountant viewAccountant)
        {
            _viewAccountant = viewAccountant;
        }
        [DualGet("~/admin", Name = AdminRouteNames.Dashboard)]
        public IActionResult Index()
        {
            return R.Success.Result;
        }

        [DualGet("templates/get", Name = AdminRouteNames.GetTemplates, OnlyApi = true)]
        public IActionResult LoadTemplates(string context)
        {
            if (context.IsNullEmptyOrWhiteSpace())
                return R.Success.With("templates", null).Result;
            var templates = _viewAccountant.CompileAllViews(context, ApplicationConfig.AdminAreaName);
            return R.Success.With("templates", templates).Result;
        }
    }
}