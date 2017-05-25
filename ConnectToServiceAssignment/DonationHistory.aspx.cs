using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DonationHistory : System.Web.UI.Page
{
    CommunityAssistReference.CommunityServiceClient ca = new CommunityAssistReference.CommunityServiceClient();



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userKey"] == null)

            Response.Redirect("Default2.aspx");


        int key = (int)Session["userKey"];

        //CommunityAssistReference.CommunityServiceClient ca = new CommunityAssistReference.CommunityServiceClient();
        CommunityAssistReference.GrantRequest[] grant = ca.ReviewGrant(key);

        GridView1.DataSource = grant;
        GridView1.DataBind();
    }
}