using System;
using System.Reflection;
using System.Globalization;
using System.Web.UI;
using System.Web.Handlers;


namespace Nucleo.Web
{
	public class NucleoScriptReference : ScriptReference
	{
		private bool _isReferencedScript = false;
		private string _originalPath = null;
		private string _uniqueIdentifier = null;



		#region " Properties "

		 public bool IsReferencedScript
		{
			get { return _isReferencedScript; }
			internal set { _isReferencedScript = value; }
		}

		 /// <summary>
		 /// Gets or sets the original path used, in cases where the path is covered up because it's a web resource.
		 /// </summary>
		 public string OriginalPath
		 {
			 get { return !string.IsNullOrEmpty(_originalPath) ? _originalPath : string.Empty; }
			 set { _originalPath = value; }
		 }

		 /// <summary>
		 /// Gets or sets a unique identifier for the script, which is a logical name for it.
		 /// </summary>
		 public string UniqueIdentifier
		 {
			 get { return _uniqueIdentifier; }
			 set { _uniqueIdentifier = value; }
		 }

		#endregion



		#region " Constructors "

		public NucleoScriptReference()
			: base() { }

		public NucleoScriptReference(string path)
			: this()
		{
			this.Path = path;
		}

		public NucleoScriptReference(string path, string originalPath, bool isEmbeddedResource)
			: this()
		{
			this.Path = path;

			if (isEmbeddedResource)
				_originalPath = originalPath;
			else
				_originalPath = null;
		}

		public NucleoScriptReference(string name, string assemblyName)
			: this()
		{
			this.Name = name;
			this.Assembly = assemblyName;
		}

		#endregion
	}




//#if NET20 || NET35
//    public class NucleoScriptReference : ScriptReference
//#else
//    public class NucleoScriptReference : ScriptReferenceBase
//#endif
//    {
//#if NET40
//        private string _assembly = null;
//        private string _name = null;
//#endif

//        private CultureInfo _culture = CultureInfo.InvariantCulture;
//        private bool _isReferencedScript = false;
//        private string _originalPath = null;
//        private string _uniqueIdentifier = null;



//        #region " Properties "

//#if NET40
//        public string Assembly
//        {
//            get { return _assembly; }
//            set { _assembly = value; }
//        }

//        public string Name
//        {
//            get { return _name; }
//            set { _name = value; }
//        }
//#endif

//        public CultureInfo Culture
//        {
//            get { return _culture; }
//            set { _culture = value; }
//        }

//        public bool IsReferencedScript
//        {
//            get { return _isReferencedScript; }
//            internal set { _isReferencedScript = value; }
//        }

//        /// <summary>
//        /// Gets or sets the original path used, in cases where the path is covered up because it's a web resource.
//        /// </summary>
//        public string OriginalPath
//        {
//            get { return !string.IsNullOrEmpty(_originalPath) ? _originalPath : string.Empty; }
//            set { _originalPath = value; }
//        }

//        /// <summary>
//        /// Gets or sets a unique identifier for the script, which is a logical name for it.
//        /// </summary>
//        public string UniqueIdentifier
//        {
//            get { return _uniqueIdentifier; }
//            set { _uniqueIdentifier = value; }
//        }

//        #endregion



//        #region " Constructors "

//        public NucleoScriptReference()
//            : base() { }

//        public NucleoScriptReference(string path)
//            : this() 
//        {
//            this.Path = path;
//        }

//        public NucleoScriptReference(string path, string originalPath, bool isEmbeddedResource)
//            : this()
//        {
//            this.Path = path;

//            if (isEmbeddedResource)
//                _originalPath = originalPath;
//            else
//                _originalPath = null;
//        }

//        public NucleoScriptReference(string name, string assemblyName)
//            : this() 
//        {
//            this.Name = name;
//            this.Assembly = assemblyName;
//        }

//        #endregion



//        #region " Methods "

//        protected virtual Assembly GetAssembly()
//        {
//            if (!string.IsNullOrEmpty(this.Assembly))
//                return System.Reflection.Assembly.LoadFrom(this.Assembly);
//            else
//                return null;
//        }

//        protected virtual Assembly GetAssembly(ScriptManager manager)
//        {
//            if (!string.IsNullOrEmpty(this.Assembly))
//                return System.Reflection.Assembly.LoadFrom(this.Assembly);
//            else
//#if NET40
//                return manager.AjaxFrameworkAssembly;
//#else
//                return typeof(ScriptManager).Assembly;
//#endif
//        }

//        private CultureInfo GetCulture()
//        {
//            return _culture;
//            //MethodInfo method = typeof(ScriptReference).GetMethod("DetermineCulture", BindingFlags.Instance | BindingFlags.NonPublic);
//            //return (CultureInfo)method.Invoke(((ScriptReference)this), new object[] { });
//        }

//#if NET35 || NET40

//        protected override string GetUrl(ScriptManager scriptManager, bool zip)
//        {
//            if (!string.IsNullOrEmpty(this.Path))
//                return this.RetrieveUrlFromPath(scriptManager);
//            else
//                return this.RetrieveUrlFromName(scriptManager, zip);
//        }

//#endif

//#if NET40
//        protected override bool IsAjaxFrameworkScript(ScriptManager scriptManager)
//        {
//            return (this.GetAssembly() == scriptManager.AjaxFrameworkAssembly);			
//        }

//        protected override bool IsFromSystemWebExtensions()
//        {
//            return (this.GetAssembly() == typeof(ScriptManager).Assembly);
//        }
//#endif

//        private string RetrieveUrlFromName(ScriptManager scriptManager, bool zip)
//        {
//            Assembly assembly = this.GetAssembly(scriptManager);

//            CultureInfo culture = scriptManager.EnableScriptLocalization ? this.GetCulture() : CultureInfo.InvariantCulture;
//            if (string.IsNullOrEmpty(scriptManager.ScriptPath))
//            {
//                try
//                {
//                    MethodInfo scriptResourceUrlMethod = typeof(ScriptResourceHandler).GetMethod("GetScriptResourceUrl", BindingFlags.Static | BindingFlags.NonPublic, null,
//                        new Type[] { typeof(Assembly), typeof(string), typeof(CultureInfo), typeof(bool), typeof(bool) }, null);
//                    return (string)scriptResourceUrlMethod.Invoke(null, new object[] { assembly, this.Name, culture, zip, base.NotifyScriptLoaded });
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("An exception occurred while trying to register a script for '{0}', assembly '{1}'.  This could be because the script has not had its Build Action set to Embedded Resource in the properties window, or that the WebResource definition is missing.", this.Name, assembly), ex);
//                }
//            }
//            else
//            {
//                MethodInfo getScriptMethod = typeof(ScriptReference).GetMethod("GetScriptPath", BindingFlags.Static | BindingFlags.NonPublic);
//                return scriptManager.Page.ResolveClientUrl((string)getScriptMethod.Invoke(null, new object[] { this.Path, assembly, culture, scriptManager.ScriptPath }));
//            }
//        }

//        private string RetrieveUrlFromPath(ScriptManager scriptManager)
//        {
//            string path = this.Path;

//            if (scriptManager.EnableScriptLocalization)
//            {
//                CultureInfo info = this.GetCulture();
//                if (!info.Equals(CultureInfo.InvariantCulture))
//                {
//                    if (path.EndsWith(".debug.js"))
//                        path = path.Insert(path.Length - 10, info.ToString());
//                    else
//                        path = path.Insert(path.Length - 3, info.ToString());
//                }
//            }

//            return scriptManager.Page.ResolveClientUrl(path);
//        }

//        #endregion
//	}
}
