using System;
using System.Collections.Generic;
using System.Linq;
using API_Enhancement.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Enhancement.Controllers
{
    [Route("api/[controller]")]
    //[Area("Blog")]
    //[ApiController]
    public class APIEnhancementController : ControllerBase
    {
        private readonly curContext _dbContext;

        public APIEnhancementController(curContext dbContext)
        {
            this._dbContext = dbContext;
        }
        /// <summary>
        /// Get lineItem/UnblendedCost grouping by product/productname
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Api1")]
        public Dictionary<string?,double> Api1(string id)
        {
            var aa = _dbContext.Curs.Where(m=>m.LineItemUsageAccountId==id).GroupBy(m => m.ProductProductName).Select(m => new 
            {
                //product_ProductName = m.Key,
                //sum_lineitem_unblendedcost = m.Select(c=>Convert.ToDouble(c.LineItemUnblendedCost)).Sum()
                product_ProductName = m.Key,
                sum_lineitem_unblendedcost = m.Select(c => Convert.ToDouble(c.LineItemUnblendedCost)).Sum()
            })?.ToDictionary(m=>m.product_ProductName,m=>m.sum_lineitem_unblendedcost);
            
            return aa;
        }
        /// <summary>
        /// Get daily lineItem/UsageAmount grouping by product/productname
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Api2")]
        public Dictionary<string?, Dictionary<string, double>> Api2(string id)
        {
            //需要用到的欄位，只篩選過id 以date+productname group
            var tabA = _dbContext.Curs.Where(m => m.LineItemUsageAccountId == id).Select(m => new
            {
                ProductProductName= m.ProductProductName,
                LineItemUsageStartDate = Convert.ToDateTime(m.LineItemUsageStartDate).Date,
                LineItemUsageEndDate = Convert.ToDateTime(m.LineItemUsageEndDate).Date,
                LineItemUsageAmount=m.LineItemUsageAmount
            }).ToList().GroupBy(m =>new { m.ProductProductName,m.LineItemUsageStartDate,m.LineItemUsageEndDate}).Select(m => new
            {
                ProductProductName = m.Key.ProductProductName,
                LineItemUsageStartDate = m.Key.LineItemUsageStartDate,
                LineItemUsageEndDate = m.Key.LineItemUsageEndDate,
                sum_LineItemUsageAmount = m.Select(c => Convert.ToDouble(c.LineItemUsageAmount)).Sum()
            }).ToList();

            //先抓該TabA後 Group product的最大 和最小的時間列表
            //該production的 最大日期 和最小日期 和時間差距(含當天)
            var tabB=tabA.GroupBy(m => m.ProductProductName).Select(m => new
            {
                ProductProductName=m.Key,
                MinDate =m.Select(c=>c.LineItemUsageStartDate).Min(),
                MaxDate=m.Select(c=>c.LineItemUsageEndDate).Max(),
                //差距日數
                AllDiffDays= (m.Select(c => c.LineItemUsageEndDate).Max()- m.Select(c => c.LineItemUsageStartDate).Min()).Days+1,
                //Dailys=new List<DateTime>()
                Dailys=new Dictionary<string,double>()
            }).ToList();


            //把最大最小的時間點 每天列出來
            //--.從最小天數開始  後續每天加1天變成列表
            foreach (var b in tabB) 
            {
                for (int i = 0;i<b.AllDiffDays; i++)
                {
                    if ((b.MaxDate - b.MinDate.AddDays(i)).Days == -1) break;//防止超過截止日
                    b.Dailys.Add(b.MinDate.AddDays(i).ToString("yyyy/MM/dd"),0);
                }
            }
            
            foreach (var B in tabB)
            {
                foreach (var A in tabA.Where(m=>m.ProductProductName==B.ProductProductName))
                {
                    for (int i = 0; i <= B.AllDiffDays; i++)
                    {
                        if ((A.LineItemUsageEndDate - A.LineItemUsageStartDate.AddDays(i)).Days <= -1) break;//防止超過截止日
                        var DiffDays = (A.LineItemUsageEndDate - A.LineItemUsageStartDate).Days;
                        double num = (A.sum_LineItemUsageAmount / (DiffDays + 1));

                        if (!B.Dailys.ContainsKey(A.LineItemUsageStartDate.AddDays(i).ToString("yyyy/MM/dd"))) break;//防止沒有這個key
                        B.Dailys[A.LineItemUsageStartDate.AddDays(i).ToString("yyyy/MM/dd")] += num;
                    }

                }
            }

            var result =tabB.ToDictionary(m => m.ProductProductName, m => m.Dailys);
            

            return result;
        }


        [HttpGet]
        [Route("Api1Paginaton")]
        public Dictionary<string?, double> Api1Paginaton(string id,int onePageCount,int page)
        {
            var aa = _dbContext.Curs.Where(m => m.LineItemUsageAccountId == id).GroupBy(m => m.ProductProductName).Select(m => new
            {
                //product_ProductName = m.Key,
                //sum_lineitem_unblendedcost = m.Select(c=>Convert.ToDouble(c.LineItemUnblendedCost)).Sum()
                product_ProductName = m.Key,
                sum_lineitem_unblendedcost = m.Select(c => Convert.ToDouble(c.LineItemUnblendedCost)).Sum()
            });


            //分頁
            var bb = aa.Skip(onePageCount* (page-1)).Take(onePageCount)?.ToDictionary(m => m.product_ProductName, m => m.sum_lineitem_unblendedcost); ;


            return bb;
        }

        [HttpGet]
        [Route("Api2Paginaton")]
        public Dictionary<string?, Dictionary<string, double>> Api2Paginaton(string id, int onePageCount, int page)
        {
            //需要用到的欄位，只篩選過id 以date+productname group
            var tabA = _dbContext.Curs.Where(m => m.LineItemUsageAccountId == id).Select(m => new
            {
                ProductProductName = m.ProductProductName,
                LineItemUsageStartDate = Convert.ToDateTime(m.LineItemUsageStartDate).Date,
                LineItemUsageEndDate = Convert.ToDateTime(m.LineItemUsageEndDate).Date,
                LineItemUsageAmount = m.LineItemUsageAmount
            }).ToList().GroupBy(m => new { m.ProductProductName, m.LineItemUsageStartDate, m.LineItemUsageEndDate }).Select(m => new
            {
                ProductProductName = m.Key.ProductProductName,
                LineItemUsageStartDate = m.Key.LineItemUsageStartDate,
                LineItemUsageEndDate = m.Key.LineItemUsageEndDate,
                sum_LineItemUsageAmount = m.Select(c => Convert.ToDouble(c.LineItemUsageAmount)).Sum()
            }).ToList();

            //先抓該TabA後 Group product的最大 和最小的時間列表
            //該production的 最大日期 和最小日期 和時間差距(含當天)
            var tabB = tabA.GroupBy(m => m.ProductProductName).Select(m => new
            {
                ProductProductName = m.Key,
                MinDate = m.Select(c => c.LineItemUsageStartDate).Min(),
                MaxDate = m.Select(c => c.LineItemUsageEndDate).Max(),
                //差距日數
                AllDiffDays = (m.Select(c => c.LineItemUsageEndDate).Max() - m.Select(c => c.LineItemUsageStartDate).Min()).Days + 1,
                //Dailys=new List<DateTime>()
                Dailys = new Dictionary<string, double>()
            }).ToList();


            //把最大最小的時間點 每天列出來
            //--.從最小天數開始  後續每天加1天變成列表
            foreach (var b in tabB)
            {
                for (int i = 0; i < b.AllDiffDays; i++)
                {
                    if ((b.MaxDate - b.MinDate.AddDays(i)).Days == -1) break;//防止超過截止日
                    b.Dailys.Add(b.MinDate.AddDays(i).ToString("yyyy/MM/dd"), 0);
                }
            }

            foreach (var B in tabB)
            {
                foreach (var A in tabA.Where(m => m.ProductProductName == B.ProductProductName))
                {
                    for (int i = 0; i <= B.AllDiffDays; i++)
                    {
                        if ((A.LineItemUsageEndDate - A.LineItemUsageStartDate.AddDays(i)).Days <= -1) break;//防止超過截止日
                        var DiffDays = (A.LineItemUsageEndDate - A.LineItemUsageStartDate).Days;
                        double num = (A.sum_LineItemUsageAmount / (DiffDays + 1));

                        if (!B.Dailys.ContainsKey(A.LineItemUsageStartDate.AddDays(i).ToString("yyyy/MM/dd"))) break;//防止沒有這個key
                        B.Dailys[A.LineItemUsageStartDate.AddDays(i).ToString("yyyy/MM/dd")] += num;
                    }

                }
            }

            var result = tabB.Skip(onePageCount * (page - 1)).Take(onePageCount)?.ToDictionary(m => m.ProductProductName, m => m.Dailys);


            return result;
        }

    }
}
