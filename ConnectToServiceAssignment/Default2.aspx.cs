using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //int key = 0;

        CommunityAssistReference.CommunityServiceClient ca = new CommunityAssistReference.CommunityServiceClient();

        int success = ca.Login(UserTextBox.Text, PasswordTextBox.Text);

        if (success != 0)
        {
            
            Session["userKey"] = success;

            Response.Redirect("DonationHistory.aspx");

        }
        else
        {
            ResultLabel1.Text = "invalid login";
        }
    }
}