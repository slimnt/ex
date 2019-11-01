using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Galaktika.External.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.Reports;

namespace Galaktika.External.Module.Reports.OrderReport
{
	/// <summary>
	/// Свойства источника данных.
	/// </summary>
	[VisibleInReports(true)]
	[NonPersistent]
	public class OrderReportData : XafariReportDataBase
	{
		public string Caption { get; set; }
		public IList<ExternalOrder> ExternalOrder { get; set; }
	}
}
