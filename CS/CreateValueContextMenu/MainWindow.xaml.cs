using System.Data;
using System.Data.OleDb;
using System.Windows;
using DevExpress.Xpf.PivotGrid;
using HowToBindToMDB.NwindDataSetTableAdapters;
using DevExpress.Xpf.PivotGrid.Internal;

namespace HowToBindToMDB {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        NwindDataSet.SalesPersonDataTable salesPersonDataTable = new NwindDataSet.SalesPersonDataTable();
        SalesPersonTableAdapter salesPersonDataAdapter = new SalesPersonTableAdapter();

        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = salesPersonDataTable;
            pivotGridControl1.GridMenu.Opened += new System.EventHandler(GridMenu_Opened);
        }

        void GridMenu_Opened(object sender, System.EventArgs e) {
            if(pivotGridControl1.GridMenu.MenuType != PivotGridMenuType.HeadersArea) return;
            TestItem.IsVisible = (FieldArea)pivotGridControl1.GridMenu.PlacementTarget.GetValue(FieldHeaders.AreaProperty) == FieldArea.DataArea;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            salesPersonDataAdapter.Fill(salesPersonDataTable);
        }
    }
}
