using System;
using System.Collections;
using System.Linq;


namespace Nucleo.DataMapper.Incrementing
{
	public class StringTemplateMappingGenerator : IMappingGenerator
	{
		private string _template = null;



		#region " Constructors "

		public StringTemplateMappingGenerator(string template)
		{
			_template = template;
		}

		#endregion



		#region " Methods "

		public object Generate(IncrementMappings map)
		{
			IncrementMappingCollection mappings = map.GetMappings();
			ArrayList values = new ArrayList();

			foreach (IncrementMapping mapping in mappings)
				values.Add(mapping.GetValue());

			return String.Format(_template, values.ToArray());
		}

		#endregion
	}
}
