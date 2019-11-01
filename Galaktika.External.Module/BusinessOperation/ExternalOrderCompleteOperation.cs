using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.BC.BusinessOperations;
using PromAktiv.Core.Module.BusinessOperations;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Utils;
using DevExpress.Xpo;
using System.ComponentModel;
using Xafari.BC.BusinessOperations.Attributes;
using PromAktiv.Core.Common;
using Xafari.BC;
using DevExpress.Persistent.Base;
using Galaktika.External.Module.BusinessObjects;

namespace Galaktika.External.Module.BusinessOperation
{
	[System.ComponentModel.DisplayName("Завершить все операции")]
	[Description("Заполнить дату окончания операций")]
	[ExecutionWay(ExecutionWays.Synchronous)]
	[BusinessOperationCategory]
	[DefaultOperationService(typeof(ExternalOrderCompleteOperationService))]
	class ExternalOrderCompleteOperation : PromAktiv.Core.Common.CoreBusinessOperationManagedBase, IObjectSelectionVariantSupport
	{
		/// <summary>
		/// контекст
		/// </summary>
		[ContextProperty]
		public ExternalOrder ExternalOrder { get; set; }

		/// <summary>
		/// входной параметр
		/// </summary>
		[System.ComponentModel.DisplayName("Дата завершения")]
		public DateTime Date { get; set; }

		/// <summary>
		/// Тип получения объектов (выделенные/по критерию)
		/// </summary>
		public ObjectSelectionVariant ObjectSelectionVariant { get; set; }

		/// <summary>
		/// Критерий.
		/// </summary>
		[Browsable(false)]
		public LightDictionary<string, CriteriaOperator> Criteria { get; set; }

		[VisibleInDetailView(false)]
		public bool IsShowObjectSelectionVariant { get; set; }

		#region Selection Criteria
		CriteriaOperator IObjectSelectionVariantSupport.GetCriteria(Session session)
		{
			return ObjectSelectionVariantSupportHelper.GetCriteria(session, Criteria);
		}

		CriteriaOperator IObjectSelectionVariantSupport.GetCriteria(IObjectSpace objectSpace)
		{
			return ObjectSelectionVariantSupportHelper.GetCriteria(objectSpace, Criteria);
		}

		void IObjectSelectionVariantSupport.SetCriteria(LightDictionary<string, CriteriaOperator> criteria)
		{
			Criteria = criteria;
		}
		#endregion
	}
}
