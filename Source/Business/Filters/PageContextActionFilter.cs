using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Business.Factories;
using Brightfind.EktronToEpiserverLab.Business.Interfaces;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer.Web.Routing;

namespace Brightfind.EktronToEpiserverLab.Business.Filters
{
    public class PageContextActionFilter : IResultFilter
    {
        private readonly PageViewContextFactory _contextFactory;

        public PageContextActionFilter(PageViewContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;
            var model = viewModel as IPageViewModel<SpockPageBase>;
            if (model == null) return;

            var currentContentLink = filterContext.RequestContext.GetContentLink();
            var layoutModel = model.Layout ?? _contextFactory.CreateLayoutModel(currentContentLink, filterContext.RequestContext);
            var layoutController = filterContext.Controller as IModifyLayout;
            if(layoutController != null)
            {
                layoutController.ModifyLayout(layoutModel);
            }

            model.Layout = layoutModel;

            if(model.Section == null)
            {
                model.Section = _contextFactory.GetSection(currentContentLink);
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            
        }
    }
}