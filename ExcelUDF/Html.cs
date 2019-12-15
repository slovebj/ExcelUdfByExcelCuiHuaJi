﻿using ExcelDna.Integration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack; 
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelCuiHuaJi
{
    public partial class ExcelUDF
    {

        [ExcelFunction(Category = "Html解析", Description = "对网页HTML进行抓取解析！")]
        public static string HtmlNode(
            [ExcelArgument(Description = "解析的网址")] string url,
            [ExcelArgument(Description = "xpath")] string htmlNode
        )
        {
            if(url != null & htmlNode != null)
            {
                HtmlWeb web = new HtmlWeb();
            //从url中加载
            HtmlDocument doc = web.Load(url);
            //获得title标签节点，其子标签下的所有节点也在其中
            HtmlNode SingleNode = doc.DocumentNode.SelectSingleNode(htmlNode);
            //获得title标签中的内容
            return SingleNode.InnerText;
            }
            else
            {
                return "#参数错误！";
            }
        }

    }
}
