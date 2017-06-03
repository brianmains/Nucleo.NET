using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

using Nucleo.Web.Core;
using Nucleo.Web.CodeGeneration;


namespace Nucleo.Web.Ajax
{
	public class PresenterProxyGenerator
	{
		private Type _presenterType = null;



		#region " Constructors "

		private PresenterProxyGenerator() { }

		#endregion



		#region " Methods "

		public static PresenterProxyGenerator Create(Type presenterType)
		{
			if (presenterType == null)
				throw new ArgumentNullException("presenterType");

			PresenterProxyGenerator proxy = new PresenterProxyGenerator();
			proxy._presenterType = presenterType;

			return proxy;
		}

		public string Generate()
		{
			return Generate(null);
		}

		public string Generate(IList<string> methodNames)
		{
			ClassDefinition definition = new ClassDefinition { SourceType = _presenterType };
			MethodInfo[] methods = _presenterType.GetMethods();

			for (int index = 0, len = methods.Length; index < len; index++)
			{
				MethodInfo method = methods[index];
				PresenterWebMethodAttribute attribute = null;

				if (methodNames != null)
				{
					if (methodNames.Contains(method.Name))
						attribute = new PresenterWebMethodAttribute();
				}
				else
					attribute = method.GetCustomAttribute<PresenterWebMethodAttribute>(false);

				if (attribute != null)
				{
					ClassMethodMember methodMember = new ClassMethodMember { Name = method.Name };
					foreach (ParameterInfo parameter in method.GetParameters())
						methodMember.Parameters.Add(parameter.Name);

					definition.AddMember(methodMember);
				}
			}

			return string.Format(@"
				Sys.Application.add_init(function() {{
					if (typeof(n$) === 'undefined') n$ = {{}};
					if (typeof(n$.Presenters) === 'undefined') n$.Presenters = {{}};

					n$.Presenters[""{0}""] = {1}
				}});", _presenterType.Name,
				new PresenterClassGenerator(Nucleo.Web.Framework.FrameworkSettings.ServiceContext).Generate(definition));

			//MethodInfo[] methods = _presenterType.GetMethods();
			//StringBuilder builder = new StringBuilder();
			//builder.AppendFormat("n$.Presenters[\"{0}\"] = (function() {{", _presenterType.Name);
			//builder.Append("return {{");

			//for (int index = 0, len = methods.Length; index < len; index++)
			//{
			//    MethodInfo method = methods[index];
			//    PresenterWebMethodAttribute attribute = method.GetCustomAttribute<PresenterWebMethodAttribute>(false);

			//    if (attribute != null)
			//    {
			//        builder.AppendFormat("{0} : function");
			//    }
			//}

			//builder.Append("}}"); //ending for return
			//builder.Append("})();"); //ending for closure

			//return builder.ToString();
		}

		#endregion
	}
}
