using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nucleo.EventArguments;
using Nucleo.State;


namespace Nucleo.Demos.MvpScenarios.TabbedForms
{
	public interface IRecord
	{
		int Key { get; set; }
	}

	//Sample data factory for test purposes.
	public static class DataFactory
	{
		public static void Add<T>(T entity)
			where T : IRecord
		{
			var list = GetList<T>();

			var item = list.FirstOrDefault(i => i.Key == entity.Key);
			if (item != null)
				list.Remove(item);

			list.Add(entity);

			UpdateList(list);
		}

		public static T Get<T>(int key)
			where T : IRecord
		{
			var list = GetList<T>();

			return list.FirstOrDefault(i => i.Key == key);
		}

		public static IEnumerable<T> GetAll<T>()
		{
			return GetList<T>();
		}

		private static List<T> GetList<T>()
		{
			var list = HttpContext.Current.Session[typeof(T).Name] as List<T>;

			if (list == null)
			{
				list = new List<T>();
				HttpContext.Current.Session.Add(typeof(T).Name, list);
			}

			return list;
		}

		private static void UpdateList<T>(List<T> list)
		{
			HttpContext.Current.Session[typeof(T).Name] = list;
		}
	}


	public class AppStateProvider : Nucleo.State.ICurrentExecutionState
	{
		public event StateValueChangedEventHandler ValueChanged;
		private Dictionary<object, object> _dict = new Dictionary<object, object>();




		public static AppStateProvider Instance
		{
			get
			{
				AppStateProvider prov = HttpContext.Current.Items[typeof(AppStateProvider)] as AppStateProvider;
				if (prov == null)
				{
					prov = new AppStateProvider();
					HttpContext.Current.Items.Add(typeof(AppStateProvider), prov);
				}

				return prov;
			}
		}


		public StateValue Get(object key)
		{
			if (_dict.ContainsKey(key))
				return new StateValue { Key = key, Value = _dict[key] };
			else
				return null;
		}

		public StateValueCollection GetAll()
		{
			return new StateValueCollection(
				_dict.Select(i => new StateValue { Key = i.Key, Value = i.Value }));
		}

		public bool HasValue(object key)
		{
			return _dict.ContainsKey(key);
		}

		protected virtual void OnValueChanged(StateValueChangedEventArgs e)
		{
			if (ValueChanged != null)
				ValueChanged(this, e);
		}

		public void Set(StateValue value)
		{
			_dict[value.Key] = value.Value;
		}
	}
}