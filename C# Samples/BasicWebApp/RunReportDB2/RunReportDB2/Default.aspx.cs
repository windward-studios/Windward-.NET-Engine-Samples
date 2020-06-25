﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using net.windward.api.csharp;
using System.IO;

namespace BasicWindwardEngine
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

			// if connector is not installed, tell user
			if (!IsDb2DotNetConnectorInstalled)
				throw new ApplicationException("Please install the DB2 ADO.NET connector to run this example. Details at http://rpt.me/DB2Connector");
		}

        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            // DisplayReport.aspx will generate the report.
            Response.Redirect("DisplayReport.aspx");
        }

		#region test for connector

		/// <summary>
		/// Returns true if DB2 connector is installed.
		/// </summary>
		public static bool IsDb2DotNetConnectorInstalled
		{
			get
			{
				try
				{
					DataTable providers = DbProviderFactories.GetFactoryClasses();
					foreach (DataRow row in providers.Rows)
					{
						string providerClass = ((string)row[2]).ToLower();
						if (providerClass.StartsWith("ibm.data.db2"))
							return true;
					}
					return false;
				}
				catch (Exception)
				{
					return false;
				}
			}
		}

		#endregion
       
    }
}