using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutomationElementXMLFile
{
    class Program
    {
        static List<AutomationBasicElements> GetAutomationList()
        {
            List<AutomationBasicElements> runlist =new List<AutomationBasicElements>();
            //just as sample code
            AutomationBasicElements runinfo = new AutomationBasicElements()
            {
                BuildNo =1,
                IntialPR = 50,
                FinalPR = 90,
                RunID = 123456,
                OS = "Winserver 2012R2",
                OSLan = "ENU",
                VSLan = "ENU",
                TestQuery =687858};
            runlist.Add(runinfo);
            return runlist;
        }

        static void CreateAutomationXML(String automation)
        {
            StringBuilder xmlResult = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            List<AutomationBasicElements> AutomationList = GetAutomationList();
            if (AutomationList != null && AutomationList.Count > 0)
            {
                xmlResult.Append("<Automation>");
                xmlResult.Append("<Run Info>");
                foreach (AutomationBasicElements RunInfo in AutomationList)
                {
                    xmlResult.AppendFormat("<BuildNo>{0}</BuildNo>",RunInfo.BuildNo);
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
                streamWriter.Close();           
                fileStream.Close();      
            }  
            catch (Exception e)  
            { 
                //You could write code to deal with exception
            }  
        }


        static void Main(string[] args)
        {
            //the arguement should have .xml
            CreateAutomationXML("automation.xml");
        }
    }
}
