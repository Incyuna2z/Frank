using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadDogObjects;
using System.IO;
namespace AppBuilding
{
    class Utity 
    {
         static void Main(string[] args)
          {
            connectDB();
            CreateAutomationXML("automation.xml");

            Console.ReadKey();
          }

        /// <summary>
        /// Connect Maddog Database
        /// </summary>
        public static void connectDB()
        {
            MadDogObjects.Utilities.Security.SetDB("mdsql3", "OrcasTS");
            MadDogObjects.Utilities.Security.AppName = "MDTesting";
            MadDogObjects.Utilities.Security.AppOwner = Environment.UserName; 
        }

        public static List<RunInfo> GetAutomationList()
        {
            Console.WriteLine("Please enter a Run ID:");
            string RunID = Console.ReadLine();
            int runid = int.Parse(RunID);
            Run run = new Run(runid);
            
            PassRate PR = new PassRate(runid);

            List<RunInfo> runlist = new List<RunInfo>();
            RunInfo runinfo = new RunInfo()
            {
                BuildNo = run.ProductVersion.ToString(),
                IntialPR = PR.InitialPassingRate.ToString(),
                FinalPR = PR.FinalPassingRate.ToString(),
                RunID = runid.ToString(),
                OS = run.OS.ToString(),
                OSLan = run.OS.LanguageLocale.ToString(),
                VSLan = run.Product.LanguageLocale.ToString(),
                TestQuery = run.TestcaseQuery.ID.ToString(),
            };

               
                runlist.Add(runinfo);
                return runlist;
            }

         /// <summary>
         /// Create a automation xml
         /// </summary>
         /// <param name="automation"></param>

        public static  void CreateAutomationXML(String automation)
        {
            StringBuilder xmlResult = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            List<RunInfo> AutomationList = GetAutomationList();
            if (AutomationList != null && AutomationList.Count > 0)
            {
                xmlResult.Append("<Automation>");
                xmlResult.Append("<Run Info>");
                foreach (RunInfo RunInfo in AutomationList)
                {
                    xmlResult.AppendFormat("<BuildNo>{0}</BuildNo>", RunInfo.BuildNo);
                    xmlResult.AppendFormat("<IntialPR>{0}</IntialPR>", RunInfo.IntialPR);
                    xmlResult.AppendFormat("<FinalPR>{0}</FinalPR>", RunInfo.FinalPR);
                    xmlResult.AppendFormat("<RunID>{0}</RunID>", RunInfo.RunID);
                    xmlResult.AppendFormat("<OS>{0}</OS>", RunInfo.OS);
                    xmlResult.AppendFormat("<OSLan>{0}</OSLan>", RunInfo.OSLan);
                    xmlResult.AppendFormat("<VSLan>{0}</VSLan>", RunInfo.VSLan);
                    xmlResult.AppendFormat("<TestQuery>{0}</TestQuery>", RunInfo.TestQuery);
                }
                xmlResult.Append("</Run Info>");
                xmlResult.Append("</Automation>");
            }

            try
            {
                FileStream fileStream = new FileStream(automation, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(xmlResult);
                Console.WriteLine("Create successfully! You can gain detail in Building/AppBuilding/bin/Debug/automation.xml");
                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exist an error");
            }
        }
    }

    }

