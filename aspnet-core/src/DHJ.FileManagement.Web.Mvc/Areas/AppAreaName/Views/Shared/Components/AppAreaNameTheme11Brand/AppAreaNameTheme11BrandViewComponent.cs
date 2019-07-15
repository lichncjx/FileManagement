﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DHJ.FileManagement.Web.Areas.AppAreaName.Models.Layout;
using DHJ.FileManagement.Web.Session;
using DHJ.FileManagement.Web.Views;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTheme11Brand
{
    public class AppAreaNameTheme11BrandViewComponent : FileManagementViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameTheme11BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
