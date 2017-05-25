using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApplyForGrant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userKey"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {

        string date = DateTextBox.Text;
        string Amount = AmountTextBox.Text;
        string explains = ExplainTextBox.Text;

        CommunityAssistReference.CommunityServiceClient ca = new CommunityAssistReference.CommunityServiceClient();

        CommunityAssistReference.GrantRequest apply = new CommunityAssistReference.GrantRequest();

        apply.GrantRequestDate = DateTime.Parse(date);
        apply.GrantRequestAmount = decimal.Parse(Amount);
        apply.GrantRequestExplanation = explains;

        apply.PersonKey = (int)Session["userKey"];

        bool result = ca.newGrant(apply);

        if (result)
        {
            Response.Redirect("DonationHistory.aspx");
        }

        else
        {
            ErrorLabel.Text = "Try again";
        }
    }
}