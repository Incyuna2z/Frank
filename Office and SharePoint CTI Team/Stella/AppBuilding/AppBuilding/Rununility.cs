using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDTypes = MadDogObjects.QueryConstants.BaseObjectTypes;
using MadDogObjects;
using System.Data;
using System.Data.SqlClient;


namespace AppBuilding
{

    class Rununility : Unility
    {



        private string _runLable;
        private int _runID;
        private Rununility _resultUtl;
        private DataTable _resultTable;
        private static bool createResults;
        private static bool startRun;




        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //connection database
            MadDogObjects.Utilities.Security.SetDB("mdsql3", "OrcasTS");
            MadDogObjects.Utilities.Security.AppName = "MDTesting";
            MadDogObjects.Utilities.Security.AppOwner = Environment.UserName;
            Console.WriteLine("Please enter a Run ID:");
            string RunID = Console.ReadLine();
            int runid = int.Parse(RunID);
            /*string sql = "SELECT Run.RunID As RunID, Run.Title As Title, RunOS.OSName As OSName, RunProductsBranches.BranchName As BranchName, " +
                        "RunOSLCIDs.LanguageLocale As OSLanguageLocale, RunProductsLCIDs.LanguageLocale As ProductLanguageLocale" +
                        "FROM dbo.Run WITH (NOLOCK) INNER JOIN dbo.OS As RunOS WITH(NOLOCK)  ON(Run.OSID = RunOS.OSID) where(RunID in ({ 0})); ";
          
            string sql = "SELECT Run.RunID As RunID, Run.Title As Title, RunOS.OSName As OSName, RunProductsBranches.BranchName As BranchName, " +
                        "RunOSLCIDs.LanguageLocale As OSLanguageLocale, RunProductsLCIDs.LanguageLocale As ProductLanguageLocale" +
                        "FROM dbo.Run WITH (NOLOCK) INNER JOIN dbo.OS As RunOS WITH(NOLOCK)  ON (Run.OSID = RunOS.OSID) where RunID='3935639';";
           */
            Run run = new Run(runid);
            string branch=(run.Branch).ToString();
            string Testquery=run.TestcaseQuery.ToString();
            string BuildNo = run.ProductVersion.ToString();
            string OS = run.OS.ToString();
           
            string b=run.GetResultsSummary().ToString();
         
          //  Console.WriteLine("buildno:   " + BuildNo);
           // Console.WriteLine("runid:     "+runid);
          //  Console.WriteLine("OS:        " + OS);
          //  Console.WriteLine("branch:    " + branch);
          //  Console.WriteLine("Testquery: ");
           // Console.WriteLine("Final PR:  ");
           
            Console.WriteLine("c:");
          //  Console.WriteLine(b);
            Console.ReadKey();


        }


        /// <summary>
        /// Get TotalResultCount 
        /// </summary>
        public int TotalResultCount
        {
            get
            {
                return _resultUtl.GetTotalResultCount();
            }
        }

        /// <summary>
        /// Gets total run result count by run id.
        /// </summary>
        /// <param name="runID">Maddog Run ID, if it is not set we will use RunID property in this class</param>
        /// <returns></returns>
        public int GetTotalResultCount()
        {
            int count = this.ResultTable.Rows.Count;
            return count;

        }


        /// <summary>
        /// Gets result table, you need to set RunID before get the property.
        /// </summary>
        /// <value>
        /// The result table.
        /// </value>
        private DataTable ResultTable
        {
            get
            {
                return _resultTable;
            }
        }



        /// <summary>
        /// Gets the initial passed result count.
        /// </summary>
        public int InitialPassedResultCount
        {
            get
            {
                return _resultUtl.GetInitialPassedResultCount();
            }
        }
        public int GetInitialPassedResultCount()
        {
            int ret = 0;
            foreach (DataRow row in this.ResultTable.Rows)
            {
                int rCount = Convert.ToInt32(row["ResetCount"].ToString());
                int rTypeID = Convert.ToInt32(row["ResultTypeID"].ToString());

                if (rCount == 0 && rTypeID == 1)
                {
                    ret++;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets the pass result count.
        /// </summary>
        public int PassResultCount
        {
            get
            {
                return _resultUtl.GetFinalPassedResultCount();
            }
        }

        public int GetFinalPassedResultCount()
        {
            int ret = 0;
            foreach (DataRow row in this.ResultTable.Rows)
            {
                int rTypeID = Convert.ToInt32(row["ResultTypeID"].ToString());

                if (rTypeID == 1)
                {
                    ret++;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets the initial passing rate.
        /// </summary>
        public string InitialPassingRate
        {
            get
            {
                double initialPassingRate = (double)this.InitialPassedResultCount / this.TotalResultCount;
                return initialPassingRate.ToString("p");

            }
        }


        /// <summary>
        /// Gets the passing rate.
        /// </summary>
        public string FinalPassingRate
        {
            get
            {
                double currentPassingRate = (double)this.PassResultCount / this.TotalResultCount;
                return currentPassingRate.ToString("p");
            }
        }

        /// <summary>
        /// Get a DataTable from Run IDs with default columns
        /// </summary>
        /// <param name="runIDs">The run Ids.</param>
        /// <returns></returns>
        /*public static DataTable GetDataFromRunID(int runID)
        {
            List<RunTableColumn> tableColumns = new List<RunTableColumn>();
            Dictionary<string, string> dict = GetEnumMembers(typeof(RunTableColumn));
            foreach (KeyValuePair<string, string> item in dict)
            {
                RunTableColumn col;
                Enum.TryParse(item.Key, out col);
                tableColumns.Add(col);
            }

            DataTable runTable = Rununility.GetDataFromRunIDs(runID, tableColumns);
            return runTable;
        }

        /// <summary>
        /// Get a DataTable from RunIDs
        /// </summary>
        /// <param name="runIDs"></param>
        /// <param name="tableColumns"></param>
        /// <returns></returns>
        public static DataTable GetDataFromRunIDs(int runIDs, List<RunTableColumn> tableColumns)
        {
            DataTable runTable = new DataTable("RunDetail");

            #region Prepare table columns

            for (int i = 0; i < tableColumns.Count; i++)
            {
                DataColumn column = new DataColumn();

                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = tableColumns[i].ToString();
                column.Caption = tableColumns[i].GetStringValue();

                runTable.Columns.Add(column);
            }

            #endregion Prepare table columns

            #region Insert table datas

            for (int i = 0; i <= runIDs; i++)
            {
                DataRow dataRow = runTable.NewRow();
                Rununility runUtl = new Rununility(runIDs);

                foreach (RunTableColumn column in tableColumns)
                {
                    string currentColumnName = column.ToString();
                    switch (column)
                    { 
                        case RunTableColumn.RunID:
                            dataRow[currentColumnName] = runUtl.RunID;
                            break;
                        case RunTableColumn.PassingRate:
                            dataRow[currentColumnName] = runUtl.FinalPassingRate;
                            break;
                        case RunTableColumn.InitialPassingRate:
                            dataRow[currentColumnName] = runUtl.InitialPassingRate;
                            break;
                        
                        default:
                            throw new NotImplementedException("Not implement for " + tableColumns[i].ToString());
                           
                    }
                }

                runTable.Rows.Add(dataRow);
            }

            #endregion Insert table datas

            return runTable;
          
        }

    }
}

    */
    }
}