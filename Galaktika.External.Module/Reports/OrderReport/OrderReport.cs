using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.Reports;

namespace Galaktika.External.Module.Reports.OrderReport
{
	[XafDisplayName("Комплексный отчет по заказам"), ImageName("")]
	public class OrderReport : XafariReport<OrderReportData, OrderParameters, OrderDataMinerOperation>
	{
	}
}
