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
            ArrayList resultList = null;
            
            Database db = new Database(DataBaseInfo.RealDBInfo());      // 실제 RealDBInfo로 바꾸면 됨.
            Hashtable resultMap = db.GetReader("select bNo, bTitle, bContents from [Board];"); // 쿼리만 가변적으로 바뀌면 가능!

            if (Convert.ToInt32(resultMap["MsgCode"]) == -1)
            {
                Console.WriteLine(resultMap["Msg"].ToString());
            }
            else
            {
                 resultList = (ArrayList)resultMap["Data"];
                
                //foreach (var row in resultList)
                //{
                //    list.Add(row);
                //}
                
            }
            return resultList;
        }
    }
}
