using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.Reports;

namespace Galaktika.External.Module.Reports.OrderReport
{
	/// <summary>
	/// Параметры для комплексного отчета
	/// </summary>
	[DomainComponent, XafDisplayName("Параметры отчета о заказе")]
	//[VisibleInReports(true)]
	//[DeferredDeletion(false)]
	public interface OrderParameters : XafariReportParametersBase
	{
		string Filter { get; set; }
	}
}
