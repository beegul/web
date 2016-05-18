﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanetWrox.MasterPages
{
    public partial class Frontend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string SelectedTheme = Page.Theme;//Gets the current theme of the page.
                HttpCookie PreferredTheme = Request.Cookies.Get("PreferredTheme");//Gets the cookie "PrfefferedTheme" and saves it to a cookie variable.
                if(PreferredTheme != null)//Checks to see if the cookie contains a value.
                {
                    SelectedTheme = PreferredTheme.Value;//Sets the SelectedTheme varaible to the value contained in the cookie.
                }
                if(!string.IsNullOrEmpty(SelectedTheme))//Checks to see if "SelectedTheme" contains any data.
                {
                    ListItem Item = ThemeList.Items.FindByValue(SelectedTheme);//Gets the name of the theme stored in SelectedValue from the ThemeList Dropdown.
                    if(Item != null)//More null checking just to be sure.
                    {
                        Item.Selected = true;//Sets the value to be selected, this means it will be the value which always loads when the page is loaded by the user unless they change it.
                    }
                }
            }

        }

        protected void ThemeSelected(object sender, EventArgs e)
        {
            HttpCookie PreferredTheme = new HttpCookie("PreferredTheme");//Creates a cookie.
            PreferredTheme.Expires = DateTime.Now.AddMonths(3);//Sets its expiry date.
            PreferredTheme.Value = ThemeList.SelectedValue;//Sets the value of the cookie to the value in the drop down list.
            Response.Cookies.Add(PreferredTheme);//Adds the cookie to the cookie list.
            Response.Redirect(Request.Url.ToString());//Redirects the user back to the same page.
        }
    }
}