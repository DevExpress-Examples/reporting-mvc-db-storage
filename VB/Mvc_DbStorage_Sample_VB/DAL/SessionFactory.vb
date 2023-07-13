Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports System.Web.Configuration

Namespace Services.DAL
	Public Module SessionFactory
		Private ReadOnly dataLayer As IDataLayer

		Sub New()
			Dim dictionary = New ReflectionDictionary()
			dictionary.GetDataStoreSchema(GetType(SessionFactory).Assembly)

			Dim connectionString = WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
			Dim dataStore = XpoDefault.GetConnectionProvider(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)

			dataLayer = New ThreadSafeDataLayer(dictionary, dataStore)
		End Sub

		Public Function Create() As UnitOfWork
			Return New UnitOfWork(dataLayer)
		End Function
	End Module
End Namespace
