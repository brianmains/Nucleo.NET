using System;
using System.Web.Mvc;

using Nucleo.Models;
using Nucleo.Reflection;
using Nucleo.Lookups;


namespace Nucleo.Web.Controllers
{
	public static class ControllerExtensions
	{
		public static ViewResult NucleoView(this ControllerBase controller, object model)
		{
			return NucleoView(controller, null, model);
		}

		public static ViewResult NucleoView(this ControllerBase controller, string viewName, object model)
		{
			return NucleoView(controller, viewName, null, model);
		}

		public static ViewResult NucleoView(this ControllerBase controller, string viewName, string masterName, object model)
		{
			ReflectPropertyCollection props = Reflect.Public(model).Properties().WithAttribute(typeof(LookupAttribute));
			if (props.Count > 0)
			{
				LookupManager mgr = LookupManager.Create();

				foreach (ReflectProperty prop in props)
				{
					LookupAttribute attribute = prop.GetAttribute<LookupAttribute>(false);
					prop.SetValue(mgr.GetLookupRepository(attribute.LookupName).GetAllValues(null));
				}
			}

			if (model != null)
				controller.ViewData.Model = model;

			return new ViewResult
			{
				ViewName = viewName,
				MasterName = masterName,
				ViewData = controller.ViewData
			};
		}

		public static ViewResult NucleoView(this ControllerBase controller, BaseModel model)
		{
			return NucleoView(controller, null, model);
		}

		public static ViewResult NucleoView(this ControllerBase controller, string viewName, BaseModel model)
		{
			return NucleoView(controller, viewName, null, model);
		}

		public static ViewResult NucleoView(this ControllerBase controller, string viewName, string masterName, BaseModel model)
		{
			ReflectPropertyCollection props = Reflect.Public(model).Properties().WithAttribute(typeof(LookupAttribute));
			if (props.Count > 0)
			{
				LookupManager mgr = LookupManager.Create();

				foreach (ReflectProperty prop in props)
				{
					LookupAttribute attribute = prop.GetAttribute<LookupAttribute>(false);
					prop.SetValue(mgr.GetLookupRepository(attribute.LookupName).GetAllValues(null));
				}
			}

			if (model != null)
				controller.ViewData.Model = model;

			return new ViewResult
			{
				ViewName = viewName,
				MasterName = masterName,
				ViewData = controller.ViewData
			};
		}
	}
}
