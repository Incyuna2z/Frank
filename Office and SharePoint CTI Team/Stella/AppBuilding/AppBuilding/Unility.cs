using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadDogObjects;
using System.Data;
using MDTables = MadDogObjects.Tables;
using MDTypes = MadDogObjects.QueryConstants.BaseObjectTypes;
using System.Reflection;
namespace AppBuilding
{
    public class Unility
    {
        private int _runID;
        private DataTable _resultTable;
       // private DataTable _issueTable;

        private DataTable ResultTable
        {
            get
            {
                return _resultTable;
            }
        }

        /// <summary>
        /// RunID for this instance of Utilities.Maddog, change it will affect results of each method.
        /// </summary>
        public int RunID
        {
            get
            {
                return _runID;
            }
            set
            {
                GenerateResultTable();
                _runID = value;
            }
        }

   

        private void GenerateResultTable()
        {
            string ResultSQL = " SELECT RunID, TestcaseID, TestcaseName, ContextID, ContextName, ResultTypeID, ResultTypeDescription, Analyzed, AnalyzedBit, Comment, FailCount, TotalCount, " +
                     " StartTime, EndTime, PrevTestcaseID, MachineID, MachineName, OSID, OSName, ProductID, ProductName, TestOwnerId, TestOwnerName, TeamID, TeamName, " +
                      " AreaID, AreaName, AreaHierarchy, DesignStatusID, DesignStatusName, RunStatusID, RunStatusName, TestDriverName, TestdriverID, TeamHierarchy, ResetCount, " +
                      " OwnerID, OwnerName, Priority, RunTimeInSeconds, RunTime, AutoAnalysisStatus, BranchID, BranchName, AnalysisDescription, AutoAnalysisInvalid" +
                      " FROM vResults WHERE (RunID IN ({0}))";

            QueryObject Robj = new QueryObject(string.Format(ResultSQL,RunID), MDTypes.Results);
            Console.WriteLine(Robj);
            _resultTable = Robj.GetDataSet().Tables[0];
        }

  

        public int BuildNo { set; get; }
        public int IntialPR { set; get; }
        public int FinalPR { set; get; }
        public string OS { set; get; }
        public string OSLan { set; get; }
        public string VSLan { set; get; }
        public int TestQuery { set; get; }


        public enum RunTableColumn
        {
            [EnumExtensions.StringValue("Run ID")]
            RunID,
            [EnumExtensions.StringValue("Build No")]
            BuildNum,
            [EnumExtensions.StringValue("Initial PR")]
            InitialPassingRate,
            [EnumExtensions.StringValue("Final PR")]
            PassingRate,
            OSLanguageLocale,
            [EnumExtensions.StringValue("OS")]
            OSName,
            [EnumExtensions.StringValue("OS Lang")]
            OSLang,
            [EnumExtensions.StringValue("VS Lang")]
            VSLang,
            [EnumExtensions.StringValue("test query")]
            Testquery,

        }

    
        /// <summary>
        /// Gets the enum members.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns></returns>
        internal static Dictionary<string, string> GetEnumMembers(Type enumType)
        {
            Dictionary<string, string> tokenDic = new Dictionary<string, string>();

            FieldInfo[] fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo var in fields)
            {
                tokenDic.Add(var.Name, var.GetValue(var).ToString());
            }

            return tokenDic;
        }
    }

}

