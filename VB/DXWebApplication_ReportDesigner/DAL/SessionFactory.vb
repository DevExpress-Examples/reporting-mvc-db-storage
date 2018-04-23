Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports System.Web.Configuration

Namespace DXWebApplication_ReportDesigner.DAL
	Public NotInheritable Class SessionFactory

		Private Sub New()
		End Sub
		Private Shared ReadOnly dataLayer As IDataLayer

		Shared Sub New()
			Dim dictionary = New ReflectionDictionary()
			dictionary.GetDataStoreSchema(GetType(SessionFactory).Assembly)

			Dim connectionString = WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
			Dim dataStore = XpoDefault.GetConnectionProvider(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)

			dataLayer = New ThreadSafeDataLayer(dictionary, dataStore)
		End Sub

		Public Shared Function Create() As UnitOfWork
			Return New UnitOfWork(dataLayer)
		End Function
	End Class
End Namespace