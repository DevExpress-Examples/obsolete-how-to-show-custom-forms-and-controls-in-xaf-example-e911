Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports E911.Module.Editors

Namespace E911.Module.Win.Controls
	''' <summary>
	''' This is a custom WinForms form that displays persistent data received from XPO.
	''' You do not need to implement the IXpoSessionAwareControl interface if your form gets data from other sources or does not require data at all.
	''' </summary>
	Partial Public Class WinCustomForm
		Inherits DevExpress.XtraEditors.XtraForm
		Implements IXpoSessionAwareControl
		Public Sub New()
			InitializeComponent()
		End Sub
		#Region "IXpoSessionAwareControl Members"
		Public Sub UpdateDataSource(ByVal session As Session) Implements IXpoSessionAwareControl.UpdateDataSource
			'Initializing a child control when it is not created by XAF (placed on a custom form).
			CType(Me.CustomUserControl, IXpoSessionAwareControl).UpdateDataSource(session)
		End Sub
		#End Region
	End Class
End Namespace