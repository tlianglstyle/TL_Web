using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;
using System.Data;

namespace TL.Web
{
    public partial class share_detail : System.Web.UI.Page
    {
        public DataRowView row = null;
        public DataView dv = null;
        public DataView dv_imgList = null;
        public int id = 0;
        public int cid = 0;
        public int imgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "";
            if (Request.QueryString["cid"] != null)
            {
                cid = Convert.ToInt32(Request.QueryString["cid"]);
                dv = BaseDAO.GetListAll("select shareid,sid from share_img where id=" + cid);
                id = Convert.ToInt32(dv[0]["shareid"]);
                imgId = Convert.ToInt32(dv[0]["sid"]);//请求图片路径ID
            }
            else
                id = Convert.ToInt32(Request.QueryString["id"]);
            dv = BaseDAO.GetListAll("select * from Share where id=" + id);
            if (dv.Count > 0)
            {
                row = dv[0];
                if (imgId == 0)
                    imgId = Convert.ToInt32(row["url"]);//默认图片路径ID
            }
            else
            {
                Response.Redirect("share.aspx");
            }
            service.action.autoAdd(id,"share", "clicks");


            dv_imgList = BaseDAO.GetListAll("select * from share_img where shareID=" + id + " order by RecordDate");
            rpt_img.DataSource = dv_imgList;
            rpt_img.DataBind();

            rpt_other.DataSource = BaseDAO.GetListAll("select aa.id,sid,shareid,bb.name from  Share_Img aa right join (select top 3 min(b.id) id,min(a.name) name from share a left join share_img b on a.id=b.shareid where a.id!=" + id + " group by a.id  order by a.id desc) bb on aa.id=bb.id ");
            rpt_other.DataBind();

            sql = "select top 8 ID,Name from blog   where ([type] like '%,%' or len([type])=1)order by recorddate desc ";
            rpt_topic.DataSource = BaseDAO.GetListAll(sql);
            rpt_topic.DataBind();
        }
    }
}