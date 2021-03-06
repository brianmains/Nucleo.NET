﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nucleo.TestData.DataObjects
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="NucleoIntegrationTests")]
	public partial class IntegrationTestDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDataContextManagerTestData(DataContextManagerTestData instance);
    partial void UpdateDataContextManagerTestData(DataContextManagerTestData instance);
    partial void DeleteDataContextManagerTestData(DataContextManagerTestData instance);
    partial void InsertObjectContextManagerTestData(ObjectContextManagerTestData instance);
    partial void UpdateObjectContextManagerTestData(ObjectContextManagerTestData instance);
    partial void DeleteObjectContextManagerTestData(ObjectContextManagerTestData instance);
    #endregion
		
		public IntegrationTestDataDataContext() : 
				base(global::Nucleo.Properties.Settings.Default.NucleoIntegrationTestsConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public IntegrationTestDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IntegrationTestDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IntegrationTestDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IntegrationTestDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DataContextManagerTestData> DataContextManagerTestDatas
		{
			get
			{
				return this.GetTable<DataContextManagerTestData>();
			}
		}
		
		public System.Data.Linq.Table<ObjectContextManagerTestData> ObjectContextManagerTestDatas
		{
			get
			{
				return this.GetTable<ObjectContextManagerTestData>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DataContextManagerTestData")]
	public partial class DataContextManagerTestData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _DataContextManagerTestDataKey;
		
		private string _Name;
		
		private int _SortOrder;
		
		private System.DateTime _CreatedDate;
		
		private System.Nullable<System.DateTime> _ModifiedDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDataContextManagerTestDataKeyChanging(System.Guid value);
    partial void OnDataContextManagerTestDataKeyChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSortOrderChanging(int value);
    partial void OnSortOrderChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    partial void OnModifiedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public DataContextManagerTestData()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataContextManagerTestDataKey", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid DataContextManagerTestDataKey
		{
			get
			{
				return this._DataContextManagerTestDataKey;
			}
			set
			{
				if ((this._DataContextManagerTestDataKey != value))
				{
					this.OnDataContextManagerTestDataKeyChanging(value);
					this.SendPropertyChanging();
					this._DataContextManagerTestDataKey = value;
					this.SendPropertyChanged("DataContextManagerTestDataKey");
					this.OnDataContextManagerTestDataKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SortOrder", DbType="Int NOT NULL")]
		public int SortOrder
		{
			get
			{
				return this._SortOrder;
			}
			set
			{
				if ((this._SortOrder != value))
				{
					this.OnSortOrderChanging(value);
					this.SendPropertyChanging();
					this._SortOrder = value;
					this.SendPropertyChanged("SortOrder");
					this.OnSortOrderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ObjectContextManagerTestData")]
	public partial class ObjectContextManagerTestData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ObjectContextManagerTestDataKey;
		
		private string _Name;
		
		private int _SortOrder;
		
		private System.DateTime _CreatedDate;
		
		private System.Nullable<System.DateTime> _ModifiedDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnObjectContextManagerTestDataKeyChanging(System.Guid value);
    partial void OnObjectContextManagerTestDataKeyChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSortOrderChanging(int value);
    partial void OnSortOrderChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    partial void OnModifiedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public ObjectContextManagerTestData()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ObjectContextManagerTestDataKey", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ObjectContextManagerTestDataKey
		{
			get
			{
				return this._ObjectContextManagerTestDataKey;
			}
			set
			{
				if ((this._ObjectContextManagerTestDataKey != value))
				{
					this.OnObjectContextManagerTestDataKeyChanging(value);
					this.SendPropertyChanging();
					this._ObjectContextManagerTestDataKey = value;
					this.SendPropertyChanged("ObjectContextManagerTestDataKey");
					this.OnObjectContextManagerTestDataKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SortOrder", DbType="Int NOT NULL")]
		public int SortOrder
		{
			get
			{
				return this._SortOrder;
			}
			set
			{
				if ((this._SortOrder != value))
				{
					this.OnSortOrderChanging(value);
					this.SendPropertyChanging();
					this._SortOrder = value;
					this.SendPropertyChanged("SortOrder");
					this.OnSortOrderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
