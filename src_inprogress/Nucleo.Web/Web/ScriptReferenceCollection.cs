using System;
using System.Web.UI;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a collection of script references, which makes it easier to add bulk scripts when registering components.
	/// </summary>
	/// <example>
	/// protected override IEnumerable&lt;ScriptReference> GetScriptReferences()
	/// {
	///		ScriptReferenceCollection coll = new ScriptReferenceCollection();
	///		coll.Add("scripts.js");
	///		coll.Add("MyAssembly.MyScript.js", "MyAssembly");
	///		
	///		return coll;
	///		
	///		//OR to return one
	///		//return new ScriptReferenceCollection(new ScriptReference("MyAssembly.MyScript.js", "MyAssembly"));
	/// }
	/// </example>
	/// <remarks>This can aid with unit testing as you can convert the ienumerable response and check the collection counts, verifying what was passed along.</remarks>
	public class ScriptReferenceCollection : SimpleCollection<ScriptReference>
	{
		#region " Constructors "

		public ScriptReferenceCollection() { }

		public ScriptReferenceCollection(ScriptReference reference)
		{
			base.Add(reference);
		}

		public ScriptReferenceCollection(IEnumerable<ScriptReference> references)
		{
			this.AddRange(references);
		}

		#endregion



		#region " Methods "
		
		/// <summary>
		/// Adds the script path to the collection of scripts.  Must be a local path (i.e. Content/scripts.js).
		/// </summary>
		/// <param name="path">The path to the script file.</param>
		public void Add(string path)
		{
			this.Add(new NucleoScriptReference(path));
		}

		/// <summary>
		/// Adds the script that's an embedded resource to the collection of scripts.  Must match the assembly and fully-quantified name to the script.
		/// </summary>
		/// <param name="name">The fully quantified name (i.e. Nucleo.Web.ScriptFile.js) in the assembly.</param>
		/// <param name="assembly">The assembly containing the script (i.e. Nucleo for Nucleo.dll)</param>
		public void Add(string name, string assembly)
		{
			this.Add(new NucleoScriptReference(name, assembly));
		}

		/// <summary>
		/// Adds the script path to the collection of scripts.  Must be a local path (i.e. Content/scripts.js).
		/// </summary>
		/// <param name="path">The path to the script file.</param>
		/// <param name="mode">The mode for the script file (debug, release, etc).</param>
		public void Add(string path, ScriptMode mode)
		{
			NucleoScriptReference reference = new NucleoScriptReference(path);
			reference.ScriptMode = mode;
			this.Add(reference);
		}

		/// <summary>
		/// Adds the script that's an embedded resource to the collection of scripts.  Must match the assembly and fully-quantified name to the script.
		/// </summary>
		/// <param name="name">The fully quantified name (i.e. Nucleo.Web.ScriptFile.js) in the assembly.</param>
		/// <param name="assembly">The assembly containing the script (i.e. Nucleo for Nucleo.dll)</param>
		/// <param name="mode">The mode for the script file (debug, release, etc).</param>
		public void Add(string name, string assembly, ScriptMode mode)
		{
			NucleoScriptReference reference = new NucleoScriptReference(name, assembly);
			reference.ScriptMode = mode;
			this.Add(reference);
		}

		/// <summary>
		/// Adds a script reference to the collection.
		/// </summary>
		/// <param name="reference">The reference to add.</param>
		public void Add(ScriptReference reference)
		{
			if (reference == null)
				throw new ArgumentNullException("reference");

			base.Add(reference);
		}

		/// <summary>
		/// Adds a collection of script references to the collection.
		/// </summary>
		/// <param name="references">The collection of references to add.</param>
		public void AddRange(IEnumerable<ScriptReference> references)
		{
			this.Items.AddRange(references);
		}

		/// <summary>
		/// Gets a script reference using the specific details.
		/// </summary>
		/// <param name="details">The details of the script.</param>
		/// <returns>The specific script reference.</returns>
		public ScriptReference GetByDetails(ScriptReferencingRequestDetails details)
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				ScriptReference reference = this[index];

				if (!string.IsNullOrEmpty(details.Path))
				{
					if (string.Compare(reference.Path, details.Path, StringComparison.InvariantCultureIgnoreCase) == 0 &&
						reference.ScriptMode == details.Mode)
						return reference;
				}
				else
				{
					if (string.Compare(reference.Assembly, details.Assembly, StringComparison.InvariantCultureIgnoreCase) == 0 &&
						string.Compare(reference.Name, details.Type, StringComparison.InvariantCultureIgnoreCase) == 0 &&
						reference.ScriptMode == details.Mode)
						return reference;
				}
			}

			return null;
		}

		/// <summary>
		/// Inserts a script reference into the underlying collection.
		/// </summary>
		/// <param name="reference">The reference to insert.</param>
		/// <param name="index">The index to insert the script reference into.</param>
		public void Insert(ScriptReference reference, int index)
		{
			this.Items.Insert(index, reference);
		}

		#endregion
	}
}
