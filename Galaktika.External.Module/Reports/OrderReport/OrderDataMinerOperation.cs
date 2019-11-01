using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.Reports;
using Xafari.Utils;

namespace Galaktika.External.Module.Reports.OrderReport
{
	public class OrderDataMinerOperation : DataMinerOperationBase<OrderReportData, OrderParameters>
	{

		public override void CollectData()
		{
			ReportData.Caption = Parameters.Name;
			base.CollectData();
		}

		protected override CriteriaOperator GetCriteria(string propertyName)
		{
			if (propertyName == MemberHelper.MemberName<OrderReportData>(m => m.ExternalOrder))
				return CriteriaOperator.Parse(Parameters.Filter);

			return base.GetCriteria(propertyName);
		}
	}
}
