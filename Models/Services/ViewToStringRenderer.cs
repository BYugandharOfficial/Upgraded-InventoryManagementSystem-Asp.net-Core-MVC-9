//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Abstractions;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc.ViewEngines;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;

//namespace InevntoryManagementSystem.Models.Services
//{
//    public class ViewToStringRenderer : IViewToStringRenderer
//    {
//        private readonly IViewEngine _viewEngine;
//        private readonly ITempDataProvider _tempDataProvider;
//        private readonly IServiceProvider _serviceProvider;

//        public ViewToStringRenderer(IViewEngine viewEngine,
//                                    ITempDataProvider tempDataProvider,
//                                    IServiceProvider serviceProvider)
//        {
//            _viewEngine = viewEngine;
//            _tempDataProvider = tempDataProvider;
//            _serviceProvider = serviceProvider;
//        }

//        public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
//        {
//            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
//            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

//            var viewResult = _viewEngine.FindView(actionContext, viewName, false);

//            if (viewResult.View == null)
//            {
//                throw new ArgumentNullException($"{viewName} does not match any available view");
//            }

//            var viewData = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
//            {
//                Model = model
//            };
//            await using var sw = new StringWriter();
//            var viewContext = new ViewContext(
//                actionContext,
//                viewResult.View,
//                viewData,
//                new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
//                sw,
//                new HtmlHelperOptions()
//            );

//            await viewResult.View.RenderAsync(viewContext);
//            return sw.ToString();
//        }
//    }
//    // Add the missing interface definition for IViewToStringRenderer
//    public interface IViewToStringRenderer
//    {
//        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
//    }
//}



