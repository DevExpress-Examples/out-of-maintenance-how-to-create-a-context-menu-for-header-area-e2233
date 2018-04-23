Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports HowToBindToMDB.NwindDataSetTableAdapters
Imports DevExpress.Xpf.PivotGrid.Internal

Namespace HowToBindToMDB
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private salesPersonDataTable As New NwindDataSet.SalesPersonDataTable()
		Private salesPersonDataAdapter As New SalesPersonTableAdapter()

		Public Sub New()
			InitializeComponent()
			pivotGridControl1.DataSource = salesPersonDataTable
			AddHandler pivotGridControl1.GridMenu.Opened, AddressOf GridMenu_Opened
		End Sub

		Private Sub GridMenu_Opened(ByVal sender As Object, ByVal e As System.EventArgs)
			If pivotGridControl1.GridMenu.MenuType <> PivotGridMenuType.HeadersArea Then
				Return
			End If
			TestItem.IsVisible = CType(pivotGridControl1.GridMenu.PlacementTarget.GetValue(FieldHeaders.AreaProperty), FieldArea) = FieldArea.DataArea
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			salesPersonDataAdapter.Fill(salesPersonDataTable)
		End Sub
	End Class
End Namespace
