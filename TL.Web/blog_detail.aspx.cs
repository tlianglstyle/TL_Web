using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TL.Data;
using TL.Common;

namespace TL.Web
{
    public partial class blog_detail : System.Web.UI.Page
    {
        public DataRowView row = null;
        public string GetULinki(object o)
        {
            if (o != null)
            {
                if (o.ToString().Length > 10)
                    return " target=\"_blank\" title=\"" + o.ToString() + "\" style=\"cursor:pointer;\" href=\"" + o.ToString() + "\"";
            }
            return "";
        }
        public string GetULink(object o)
        {
            if (o != null)
            {
                if (o.ToString().Length > 10)
                    return " target=\"_blank\" title=\"" + o.ToString() + "\" style=\"color:#D932E0;cursor:pointer;\" href=\"" + o.ToString() + "\"";
            }
            return "";
        }
        public string lastArticle = "";
        public string nextArticle = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataView dv = BaseDAO.GetListAll("select * from Blog where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + "  and ([type] like '%,%' or len([type])=1) and id=" + id);
            if (dv.Count > 0)
                row = dv[0];
            else
            {
                Response.Redirect("blog.aspx");
            }
            service.action.autoAdd(id, "blog", "clicks");
            string types = row["type"].ToString();
            rpt_type.DataSource = BaseDAO.GetListAll("select * from Blog_Type where id in (" + types + ")");
            rpt_type.DataBind();

            rpt_list.DataSource = BaseDAO.GetListAll("select a.*,u.uname uname,u.url url,u.img uimg from Blog_Reply a left join [user] u on a.userid=u.id where a.blogid=" + id + " order by a.RecordDate desc ");
            rpt_list.DataBind();


            string sql = @"select y,yy,m,tCount from 
                 (
	                 select * from (
						 select max(mm.recorddate) RecordDate
						 ,max(Year(cast(mm.RecordDate as datetime))) y,0 yy
						 ,max(Month(cast(mm.RecordDate as datetime))) m
						 ,(select COUNT(1) from Blog data_b where 
						 Month(cast(data_b.RecordDate as datetime))=max(Month(cast(mm.RecordDate as datetime))) 
						 and Year(cast(data_b.RecordDate as datetime))=max(Year(cast(mm.RecordDate as datetime))) ) tCount 
						 from 
						 (select cast(Year(cast(data.RecordDate as datetime)) as varchar)+'_'+cast(Month(cast(data.RecordDate as datetime)) as varchar) ym
							,data.recorddate
						  from Blog data  and (data.[type] like '%,%' or len(data.[type])=1)) 
						 mm group by ym
	                 ) data_m 
                 union (
	                 select max(recorddate) RecordDate,Year(cast(RecordDate as datetime)) y,Year(cast(RecordDate as datetime)) yy,13 m ,-1 tCount from Blog and ([type] like '%,%' or len([type])=1) group by Year(cast(RecordDate as datetime)) 
	                 )  
                 ) data 
                 order by y desc ,m desc ";
            //rpt_date.DataSource = BaseDAO.GetListAll(sql);
            //rpt_date.DataBind();


            sql = "select ID,Name from blog where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + "  and ([type] like '%,%' or len([type])=1) order by recorddate desc ";
            rpt_topic.DataSource = BaseDAO.GetListAll(sql);
            rpt_topic.DataBind();

            dv = BaseDAO.GetListAll("select  top 1 id,name,recorddate from blog where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + "  and ([type] like '%,%' or len([type])=1) and id<" + id + " order by recorddate desc ");
            if (dv.Count > 0)
                lastArticle = "<a target=\"_blank\" href=\"http://www.tliangl.com/article" + dv[0]["id"].ToString() + ".aspx\" title=\"" + dv[0]["name"].ToString() + "\">" + dv[0]["name"].ToString() + "</a>";
            else
                lastArticle = "没有了";

            dv = BaseDAO.GetListAll("select  top 1 id,name,recorddate from blog where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + "  and ([type] like '%,%' or len([type])=1) and id>" + id + " order by recorddate  ");
            if (dv.Count > 0)
                nextArticle = "<a target=\"_blank\" href=\"http://www.tliangl.com/article" + dv[0]["id"].ToString() + ".aspx\" title=\"" + dv[0]["name"].ToString() + "\">" + dv[0]["name"].ToString() + "</a>";
            else
                nextArticle = "没有了";


        }

        public string emtion_1()
        {
            string html = "";
            for (int i = 1; i <= 55; i++)
            {//84
                html += "<li><img index=\"" + i + "\" url=\"jx2/j_" + numFour(i) + "\" lazy-src=\"/j/editor/dialogs/emotion/images/jx2/j_" + numFour(i) + ".gif\"></li>";
            }
            return html;
        }
        public string emtion_2()
        {
            string html = "";
            for (int i = 1; i <= 55; i++)
            {//84
                html += "<li><img index=\"" + i + "\" url=\"bobo/b_" + numFour(i) + "\" lazy-src=\"/j/editor/dialogs/emotion/images/bobo/b_" + numFour(i) + ".gif\"></li>";
            }
            return html;
        }
        public string emtion_3()
        {
            string html = "";
            for (int i = 1; i <= 20; i++)
            {//84
                html += "<li><img index=\"" + i + "\" url=\"babycat/C_" + numFour(i) + "\" lazy-src=\"/j/editor/dialogs/emotion/images/babycat/C_" + numFour(i) + ".gif\"></li>";
            }
            return html;
        }
        public string emtion_4()
        {
            string html = "";
            for (int i = 1; i <= 52; i++)
            {//84
                html += "<li><img index=\"" + i + "\" url=\"ldw/w_" + numFour(i) + "\" lazy-src=\"/j/editor/dialogs/emotion/images/ldw/w_" + numFour(i) + ".gif\"></li>";
            }
            return html;
        }
        public string emtion_5()
        {
            string html = "";
            for (int i = 1; i <= 40; i++)
            {//84
                html += "<li><img index=\"" + i + "\" url=\"tsj/t_" + numFour(i) + "\" lazy-src=\"/j/editor/dialogs/emotion/images/tsj/t_" + numFour(i) + ".gif\"></li>";
            }
            return html;
        }
        public string emtion_6()
        {
            string html = "";
            for (int i = 1; i <= 40; i++)
            {//84
                html += "<li><img index=\"" + i + "\" url=\"youa/y_" + numFour(i) + "\" lazy-src=\"/j/editor/dialogs/emotion/images/youa/y_" + numFour(i) + ".gif\"></li>";
            }
            return html;
        }

        string numFour(int n)
        {
            if (n < 10)
                return "000" + n;
            else if (n < 100)
                return "00" + n;
            else if (n < 1000)
                return "0" + n;
            else
                return "0000";
        }
    }
}