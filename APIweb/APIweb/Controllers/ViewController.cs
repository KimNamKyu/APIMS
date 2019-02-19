using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using Test;

namespace APIweb.Controllers
{
    
    public class ViewController : Controller
    {
        [Route("api/Views")]
        [HttpGet]
        public ArrayList Views()
        {
            ArrayList list = new ArrayList();

            Database db = new Database(DataBaseInfo.TestDBInfo());
            Hashtable resultMap = db.GetReader("select rNo, rName, rDesc from [Rule];");
            string result = "";

            if (Convert.ToInt32(resultMap["MsgCode"]) == -1)
            {
                Console.WriteLine(resultMap["Msg"].ToString());
            }
            else
            {
                ArrayList resultList = (ArrayList)resultMap["Data"];
                //foreach (string[] row in resultList)
                //{
                //    result += string.Format("rNo : {0}, rName : {1}, rDesc : {2}", row[0], row[1], row[2]);
                //}
                foreach (var row in resultList)
                {
                    list.Add(row);
                    //list.Add( row["rNo"].ToString(),row["rName"].ToString(), row["rDesc"].ToString());
                }
                
            }
            return list;
        }
    }
}
