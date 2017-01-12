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

    class PassRate 
    {
       
        private int _runID;
        private DataTable _resultTable;

        public PassRate(int runID)
        {
            Initialize(runID);
            
        }
   
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

     
   
        private void Initialize(int runID)
        {
            _runID = runID;

            try
            {
                this.RunID = runID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
     
        
        public string InitialPassingRate
        {
            get
            {
                double initialPassingRate = (double)this.InitialPassedResultCount / this.TotalResultCount;
                return initialPassingRate.ToString("p");
            }
        }
        public string FinalPassingRate
        {
            get
            {
                double currentPassingRate = (double)this.PassResultCount / this.TotalResultCount;
                return currentPassingRate.ToString("p");
            }
        }

        public int InitialPassedResultCount
        {
            get
            {
                return GetInitialPassedResultCount();
            }
        }

        public int TotalResultCount
        {
            get
            {
                return GetTotalResultCount();
            }
        }

        public int PassResultCount
        {
            get
            {
                return GetFinalPassedResultCount();
            }
        }

      
        private void GenerateResultTable()
        {

            string ResultSQL = " SELECT RunID, TestcaseID, TestcaseName, ContextID, ContextName, ResultTypeID, ResultTypeDescription, Analyzed, AnalyzedBit, Comment, FailCount, TotalCount, " +
                     " StartTime, EndTime, PrevTestcaseID, MachineID, MachineName, OSID, OSName, ProductID, ProductName, TestOwnerId, TestOwnerName, TeamID, TeamName, " +
                      " AreaID, AreaName, AreaHierarchy, DesignStatusID, DesignStatusName, RunStatusID, RunStatusName, TestDriverName, TestdriverID, TeamHierarchy, ResetCount, " +
                      " OwnerID, OwnerName, Priority, RunTimeInSeconds, RunTime, AutoAnalysisStatus, BranchID, BranchName, AnalysisDescription, AutoAnalysisInvalid" +
                      " FROM vResults WHERE (RunID IN ({0}))";

            QueryObject Robj = new QueryObject(string.Format(ResultSQL, RunID), MDTypes.Results);

            _resultTable = Robj.GetDataSet().Tables[0];
        }




   
        public int GetTotalResultCount()
        {
            int count = this._resultTable.Rows.Count;
           
            return count;
        }

        

        public int GetInitialPassedResultCount()
        {
            int ret = 0;

            foreach (DataRow row in this._resultTable.Rows)
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

       

        public int GetFinalPassedResultCount()
        {
            int ret = 0;
            foreach (DataRow row in this._resultTable.Rows)
            {
                int rTypeID = Convert.ToInt32(row["ResultTypeID"].ToString());

                if (rTypeID == 1)
                {
                    ret++;
                }
            }
            return ret;
        }




    }
}