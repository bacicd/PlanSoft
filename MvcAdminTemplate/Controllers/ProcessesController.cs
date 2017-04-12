using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class ProcessesController : Controller
    {
        private DBModelEntities db = new DBModelEntities();
        //
        // GET: /Processes/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getData(string data)
        {
            string processesData = data;
            DataTable processTable = new DataTable("Processes");


            string[] subtasks = data.Split(new string[] { "SUBTASK:" }, StringSplitOptions.None);
            for (int i = 0; i < subtasks.Length; i++)
            {
                //get list of stubtasks to check against later
                //First value is not used                
                subtasks[i] = Extension.Slice(subtasks[i], 0, subtasks[i].IndexOf("\n"));
                string temp = subtasks[i];
            }

            //get list of attributes
            var attributeContext = new DBModelEntities();
            IList<Models.Attribute> attributelist = attributeContext.Attributes.ToList();



            //Set columns of datatable
            processTable.Columns.Add("OrgID", typeof(string));
            //processTable.Columns.Add("TaskID", typeof(string));
            processTable.Columns.Add("TabName", typeof(string));
            //processTable.Columns.Add("STID", typeof(string));
            processTable.Columns.Add("STName", typeof(string));
            processTable.Columns.Add("Attribute", typeof(string));
            processTable.Columns.Add("ACode", typeof(string));

            /*
            //Add ID column (PK)
            DataColumn column = new DataColumn("ID", typeof(string));
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.AutoIncrementStep = 1;
            processTable.Columns.Add(column);
            */

            //Set primary key of datatable
            DataColumn[] columns = new DataColumn[3];
            //columns[0] = processTable.Columns["TaskID"];
            //columns[1] = processTable.Columns["STID"];
            columns[2] = processTable.Columns["ACode"];
            processTable.PrimaryKey = columns;



            string task, subtask, attrib = "";

            string[] delim = new string[] { "\nTASK:" };
            string[] dataArr = data.Split(delim, StringSplitOptions.None);

            //For every task
            for (int i = 1; i < dataArr.Length; i++)
            {
                //For every attribute in task
                for (int j = 0; j < Extension.subStrCount(dataArr[i], "ATTRIBUTE:"); j++)
                {
                    int attribIndex = Extension.NthIndexOf(dataArr[i], "ATTRIBUTE", j);
                    attrib = Extension.Slice(dataArr[i], attribIndex + 10, dataArr[i].IndexOf("\n", Extension.NthIndexOf(dataArr[i], "ATTRIBUTE", j)));
                    subtask = Extension.Slice(dataArr[i], dataArr[i].LastIndexOf("SUBTASK:", dataArr[i].IndexOf(attrib)) + 8, dataArr[i].IndexOf("\n", dataArr[i].LastIndexOf("SUBTASK:", dataArr[i].IndexOf(attrib))));
                    task = Extension.Slice(dataArr[i], 0, dataArr[i].IndexOf("\n"));
                    int subtaskID = Array.IndexOf(subtasks, subtask);
                    int attribCode = 0;
                    for (int k = 0; k < attributelist.Count; k++)
                    {
                        if (attributelist[k].Name == attrib.Trim())
                        {
                            attribCode = attributelist[k].Code;
                        }
                    }

                    //OrgID, taskID, taskName, STID, STname, Attribute, Acode
                    processTable.Rows.Add("1", task, subtask, attribCode);
                }
            }

            foreach (Process procc in db.Processes)
            {
                db.Processes.Remove(procc);
            }

            foreach (DataRow row in processTable.Rows)
            {
                Process proc = new Process();
                //proc.OrgID = 10;
                proc.TabName = row[1].ToString();
                proc.SubName = row[2].ToString();
                proc.ACode = Convert.ToInt32(row[3]);
                db.Processes.Add(proc);
                db.SaveChanges();
            }



            return Json(true);
        }



        public JsonResult DropDownAttributes(string attribute)
        {
            var attributeContext = new DBModelEntities();
            IList<Models.Attribute> attributelist = attributeContext.Attributes.ToList();
            return Json(new
            {
                attribute = attributelist.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }
    }

    static class Extension
    {
        public static int NthIndexOf(string target, string value, int n)
        {
            int i = 0;
            int index = 0;
            while (i <= n)
            {
                index = target.IndexOf(value, index + 1);
                i++;

            }
            return index;
        }


        public static int subStrCount(string str, string subStr)
        {
            //get number of subStr in string
            int pos = 0;
            int attribCount = 0;
            while (str.IndexOf(subStr, pos) != -1)
            {
                pos = str.IndexOf(subStr, pos) + 1;
                attribCount++;
            }

            return attribCount;
        }


        public static string Slice(this string source, int start, int end)
        {
            if (end < 0) // Keep this for negative end support
            {
                end = source.Length + end;
            }
            int len = end - start;               // Calculate length
            return source.Substring(start, len); // Return Substring of length
        }

    }
}

