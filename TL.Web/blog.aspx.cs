using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;

namespace TL.Web
{
    public partial class blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = @"select y,yy,m,tCount from 
                 (
	                 select * from (
						 select max(mm.recorddate) RecordDate
						 ,max(Year(cast(mm.RecordDate as datetime))) y,0 yy
						 ,max(Month(cast(mm.RecordDate as datetime))) m
						 ,(select COUNT(1) from Blog data_b where data_b.IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + @" and 
						 Month(cast(data_b.RecordDate as datetime))=max(Month(cast(mm.RecordDate as datetime))) 
						 and Year(cast(data_b.RecordDate as datetime))=max(Year(cast(mm.RecordDate as datetime))) ) tCount 
						 from 
						 (select cast(Year(cast(data.RecordDate as datetime)) as varchar)+'_'+cast(Month(cast(data.RecordDate as datetime)) as varchar) ym
							,data.recorddate
						  from Blog data  where data.IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + @" and (data.[type] like '%,%' or len(data.[type])=1) ) 
						 mm group by ym
	                 ) data_m 
                 union (
	                 select max(recorddate) RecordDate,Year(cast(RecordDate as datetime)) y,Year(cast(RecordDate as datetime)) yy,13 m ,-1 tCount from Blog  where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + @" and ([type] like '%,%' or len([type])=1) group by Year(cast(RecordDate as datetime)) 
	                 )  
                 ) data 
                 order by y desc ,m desc 
                 ";
            rpt_date.DataSource = BaseDAO.GetListAll(sql);
            rpt_date.DataBind();

            sql = "select  ID,Name from Blog_Type where orderindex=2";//顶部标签类型
            rpt_tag.DataSource = BaseDAO.GetListAll(sql);
            rpt_tag.DataBind();


            rpt_type.DataSource = BaseDAO.GetListAll("select ID,Name,stats from Blog_Type");
            rpt_type.DataBind();

            sql = "select ID,Name,RecordDate from blog where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + " and ([type] like '%,%' or len([type])=1) order by recorddate desc ";
            rpt_topic.DataSource = BaseDAO.GetListAll(sql);
            rpt_topic.DataBind();
        }
    }
}