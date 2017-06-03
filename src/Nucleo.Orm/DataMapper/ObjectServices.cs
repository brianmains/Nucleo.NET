using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using Nucleo.DataMapper.Incrementing;


namespace Nucleo.DataMapper
{
	/// <summary>
	/// Represents the core component to provide services for objects.
	/// </summary>
	public class ObjectServices
	{
		#region " Constructors "

		public ObjectServices() { }

		#endregion



		#region " Methods "

		private IList<T> IncrementMappingWithChildren<T>(IncrementMappings map, IMappingGenerator gen, int index)
		{
			IncrementMapping mapping = map.GetMapping(index);
			List<T> output = new List<T>();

			if (mapping == null)
				return output;

			for (var i = map.MappingCount - 1; i > index; i--)
				output.AddRange(IncrementMappingWithChildren<T>(map, gen, i));

			while (mapping.Increment())
			{
				output.Add((T)gen.Generate(map));

				for (var i = map.MappingCount - 1; i > index; i--)
					output.AddRange(IncrementMappingWithChildren<T>(map, gen, i));
			}

			return output;
		}

		public IEnumerable<T> GenerateNewObjects<T>(IMappingGenerator gen, params FieldMapping[] mappings)
		{
			IncrementMappings map = new IncrementMappings();

			foreach (FieldMapping mapping in mappings)
			{
				if (mapping.Value is IRangeValue)
					map.Register(mapping.Field, ((IRangeValue)mapping.Value).GetValues());
				else
					map.Register(mapping.Field, new object[] { mapping.Value.GetValue() });
			}

			int currentIncrementIndex = map.MappingCount - 1;
			List<T> output = new List<T>();
			output.Add((T)gen.Generate(map));

			for (int i = currentIncrementIndex; i >= 0; i--)
			{
				//Don't start at zero index for the current mapping
				map.GetMapping(i).Increment();
				output.AddRange(IncrementMappingWithChildren<T>(map, gen, i));

				//Reset above entries
				for (int j = i; j < map.MappingCount; j++)
					map.GetMapping(j).Reset();
			}

			return output;
		}

		#endregion
	}
}
