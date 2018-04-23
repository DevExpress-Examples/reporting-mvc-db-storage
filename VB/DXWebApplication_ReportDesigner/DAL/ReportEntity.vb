Imports DevExpress.Xpo

Namespace DXWebApplication_ReportDesigner.DAL
	<DeferredDeletion(False)>
	Public Class ReportEntity
		Inherits XPCustomObject

'INSTANT VB NOTE: The variable url was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private url_Renamed As String
		Private name As String
'INSTANT VB NOTE: The variable layout was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private layout_Renamed() As Byte

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Key>
		Public Property Url() As String
			Get
				Return url_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Url", url_Renamed, value)
			End Set
		End Property

		Public Property Layout() As Byte()
			Get
				Return layout_Renamed
			End Get
			Set(ByVal value As Byte())
				SetPropertyValue("Layout", layout_Renamed, value)
			End Set
		End Property
	End Class
End Namespace