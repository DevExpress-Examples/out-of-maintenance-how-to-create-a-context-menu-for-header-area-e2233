Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports HowToBindToMDB.NwindDataSetTableAdapters
Imports DevExpress.Xpf.PivotGrid.Internal

Namespace HowToBindToMDB

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Private salesPersonDataTable As NwindDataSet.SalesPersonDataTable = New NwindDataSet.SalesPersonDataTable()

        Private salesPersonDataAdapter As SalesPersonTableAdapter = New SalesPersonTableAdapter()

        Public Sub New()
            Me.InitializeComponent()
            Me.pivotGridControl1.DataSource = salesPersonDataTable
            AddHandler Me.pivotGridControl1.GridMenu.Opened, New System.EventHandler(AddressOf GridMenu_Opened)
        End Sub

        Private Sub GridMenu_Opened(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.pivotGridControl1.GridMenu.MenuType <> PivotGridMenuType.HeadersArea Then Return
            Me.TestItem.IsVisible = CType(Me.pivotGridControl1.GridMenu.PlacementTarget.GetValue(FieldHeadersBase.AreaProperty), FieldArea) = FieldArea.DataArea
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            salesPersonDataAdapter.Fill(salesPersonDataTable)
        End Sub
    End Class
End Namespace
