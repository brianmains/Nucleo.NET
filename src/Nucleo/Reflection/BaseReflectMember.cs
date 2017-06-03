using System;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.Attributes;


namespace Nucleo.Reflection
{
	public abstract class BaseReflectMember
	{
		private string _name = null;
		private object _target = null;
		private bool _isPrivate = false;



		#region " Properties "

		protected bool IsPrivate
		{
			get { return _isPrivate; }
		}

		public string Name
		{
			get { return _name; }
		}

		protected object Target
		{
			get { return _target; }
		}

		#endregion



		#region " Constructors "

		public BaseReflectMember(string name, object target, bool isPrivate)
		{
			_name = name;
			_target = target;
			_isPrivate = isPrivate;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the attribute of a given type from the member.
		/// </summary>
		/// <param name="attributeType">The type of attribute to get.</param>
		/// <param name="includeFromInheritedTypes">Whether to look for the definition from inherited types.</param>
		/// <returns>The object attribute reference.</returns>
		public object GetAttribute(Type attributeType, bool includeFromInheritedTypes)
		{
			object[] attributes = this.GetMember().GetCustomAttributes(attributeType, includeFromInheritedTypes);
			return (attributes != null && attributes.Length > 0) ? attributes[0] : null;
		}

		/// <summary>
		/// Gets the attribute of a given type from the member, in strongly-typed form.
		/// </summary>
		/// <param name="includeFromInheritedTypes">Whether to look for the definition from inherited types.</param>
		/// <returns>The attribute reference in strong type form.</returns>
		public A GetAttribute<A>(bool includeFromInheritedTypes)
			where A : Attribute
		{
			object attribute = GetAttribute(typeof(A), includeFromInheritedTypes);
			return (attribute != null) ? (A)attribute : default(A);
		}

		/// <summary>
		/// Gets the attributes of a given type from the member.
		/// </summary>
		/// <param name="attributeType">The type of attribute to look for.</param>
		/// <param name="includeFromInheritedTypes">Whether to look for the definition from inherited types.</param>
		/// <returns>The attribute references.</returns>
		public object[] GetAttributes(Type attributeType, bool includeFromInheritedTypes)
		{
			return this.GetMember().GetCustomAttributes(attributeType, includeFromInheritedTypes);
		}

		/// <summary>
		/// Gets the attributes of a given type from the member, in strongly-typed form.
		/// </summary>
		/// <param name="includeFromInheritedTypes">Whether to look for the definition from inherited types.</param>
		/// <returns>The attribute references in strong type form.</returns>
		public A[] GetAttributes<A>(bool includeInherited)
			where A : Attribute
		{
			return (A[])this.GetMember().GetCustomAttributes(typeof(A), includeInherited);
		}

		private static Type GetAttributeType(ITypeAttribute attribute)
		{
			if (!string.IsNullOrEmpty(attribute.TypeName))
				return Type.GetType(attribute.TypeName);
			else
				return attribute.Type;
		}

		protected BindingFlags GetFlags()
		{
			if (_isPrivate)
				return (BindingFlags.Instance | BindingFlags.NonPublic);
			else
				return (BindingFlags.Instance | BindingFlags.Public);
		}

		/// <summary>
		/// Gets the explicit member.
		/// </summary>
		/// <returns>The member information.</returns>
		public abstract MemberInfo GetMember();

		public O[] GetObjectFromTypeAttributes<O>()
		{
			return GetObjectFromTypeAttributes<O, ITypeAttribute>(false);
		}

		public O[] GetObjectFromTypeAttributes<O>(bool includeInherited)
		{
			return GetObjectFromTypeAttributes<O, ITypeAttribute>(includeInherited);
		}

		public O[] GetObjectFromTypeAttributes<O, A>()
			where A : ITypeAttribute
		{
			return GetObjectFromTypeAttributes<O, A>(false);
		}

		public O[] GetObjectFromTypeAttributes<O, A>(bool includeInherited)
			where A : ITypeAttribute
		{
			return GetObjectFromTypeAttributes<O, A>(null, includeInherited);
		}

		public O[] GetObjectFromTypeAttributes<O, A>(Action<O> action, bool includeInherited)
			where A: ITypeAttribute
		{
			object[] attributes = GetAttributes(typeof(A), includeInherited);
			List<O> outputList = new List<O>();

			foreach (object attribute in attributes)
			{
				if (attribute is A)
				{
					Type objectType = GetAttributeType((ITypeAttribute)attribute);
					O obj = (O)Activator.CreateInstance(objectType);

					if (action != null)
						action(obj);

					outputList.Insert(0, obj);
				}
			}

			return outputList.ToArray();
		}

		#endregion
	}
}
