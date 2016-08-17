using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Office=Microsoft.Office.Interop.Excel;

namespace PowerBIExcel
{
    public partial class Form1 : Form
    {        
        private List<ItemDataType> listPowerBIData;
        private DataTable dataTable;
        //"Devdiv"
        public string vSOProject;
        //"My Queries"
        public string queryFolderName;
        //"CTI Active Product Bugs"
        public string queryInstance;

        public Form1()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            vSOProject = "'"+projectText.Text+"'";
            queryFolderName = queryFolder.Text;
            queryInstance = queryName.Text;

            var list = ConnectedVSO();
            listPowerBIData = list.Select(x => new ItemDataType { Id = x.Id,Title = x.Title, AreaPath = x.AreaPath, IterationPath=x.IterationPath, CreatedBy = x.ChangedBy, CreatedDate = x.CreatedDate, State=x.State, URI =x.Uri }).ToList();

            dataTable=ConvertToDataTable<ItemDataType>(listPowerBIData);
            dataGridView1.DataSource = dataTable;
        }

        //Connected to VS Online, and retrive data by a specific query. 
        public List<WorkItem> ConnectedVSO()
        {

            List<WorkItem> itemStroage = new List<WorkItem>();

            //Connect to VS online project Collection
            TfsTeamProjectCollection VsoConllection = new TfsTeamProjectCollection(new Uri("https://devdiv.visualstudio.com/DefaultCollection/"));
            VsoConllection.Authenticate();

            //Fetch the  WorkItem Store
            var wis = (WorkItemStore)VsoConllection.GetService(typeof(WorkItemStore));

            //Query with clauses
            WorkItemCollection wic = wis.Query("Select * " + "From WorkItems " +
"Where [Work Item Type] = 'Bug' " + "And ([Created By] = 'v-stfa@microsoft.com' Or [Created By] = 'v-frankz@microsoft.com' Or [Created By] = 'v-chaoli@microsoft.com' Or [Created By] = 'v-sunwa@microsoft.com' )" +
   "And [Issue Type] <> 'Test Defect'");


            //Go through the specific query
            QueryHierarchy queryRoot = wis.Projects[0].QueryHierarchy;
            QueryFolder folder = (QueryFolder)queryRoot[queryFolderName];
            QueryDefinition query = (QueryDefinition)folder[queryInstance];
            var text = query.QueryText.Replace("@project", vSOProject);
            wic = wis.Query(text);

            foreach (WorkItem item in wic)
            {
                itemStroage.Add(item);
            }

            return itemStroage;
        }

        //Convert a List to a DataTable
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }


        //Export Excel
        private void buttonExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            int rowCount = dataTable.Rows.Count;
            int columnCount = dataTable.Columns.Count;

            // Start Excel and get Application object.
            var excel = new Office.Application();

            // for making Excel visible
            excel.Visible = false;
            excel.DisplayAlerts = false;

            // Creation a new Workbook
            excelworkBook = excel.Workbooks.Add(Type.Missing);

            // Work sheet
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "PowerBI work sheet";

            object[] Header = new object[dataTable.Columns.Count];
            for (int i =0;i<dataTable.Columns.Count;i++)
            {
                Header[i] = dataTable.Columns[i].ColumnName;
            }

            Microsoft.Office.Interop.Excel.Range HeaderRange = excelSheet.get_Range((Microsoft.Office.Interop.Excel.Range)(excelSheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(excelSheet.Cells[1, dataTable.Columns.Count]));
            HeaderRange.Value = Header;
            HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            HeaderRange.Font.Bold = true;

            //DataCells
            object[,] Cells = new object[dataTable.Rows.Count, dataTable.Columns.Count];
            for(int i=0;i<dataTable.Rows.Count;i++)
            {
                for(int j=0;j<dataTable.Columns.Count;j++)
                {
                    Cells[i, j] = dataTable.Rows[i][j];
                }
            }

            excelSheet.get_Range((Microsoft.Office.Interop.Excel.Range)(excelSheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(excelSheet.Cells[rowCount + 1, columnCount])).Value = Cells;


            // now we resize the columns
            excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[dataTable.Rows.Count, dataTable.Columns.Count]];
            excelCellrange.EntireColumn.AutoFit();

            Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

            //Turn off alerts, ic case we need to over-write
            excel.DisplayAlerts = false;
            //Save sheet
            // var fileDest = fileDestination.Text.ToString();
            string fileDest = @"c:\temp.xls";
            // check fielpath
            if (fileDest != null && fileDest != "")
            {
                try
                {
                    excelSheet.SaveAs(fileDest);
                    excel.Quit();
                    MessageBox.Show("Excel file saved!");
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                        + ex.Message);
                }
            }
            else    // no filepath is given
            {
                excel.Visible = true;
            }
        }
    }

        //Coloring The cells
        //public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        //{
        //    range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
        //    range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
        //    if (IsFontbool == true)
        //    {
        //        range.Font.Bold = IsFontbool;
        //    }
        //}
    
}
