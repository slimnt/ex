using Galaktika.External.Module.BusinessObjects;
using PromAktiv.Core.Module;
using PromAktiv.Core.Module.BusinessOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.BC.BusinessOperations;
using Xafari.BC.BusinessOperations.Attributes;

namespace Galaktika.External.Module.BusinessOperation
{
	[BusinessOperation(typeof(ExternalOrderCompleteOperation))]
	[DisplayName("Реализация по умолчанию")]
	class ExternalOrderCompleteOperationService : RecoverableOperationServiceBase
	{
		public override void Execute(IBusinessOperation businessOperation)
		{
			var bo = (ExternalOrderCompleteOperation)businessOperation;
			using (var objectSpace = BusinessOperationManager.Instance.Application.CreateObjectSpace())
			{
				ExternalOrder _ExternalOrder = objectSpace.GetObject(bo.ExternalOrder);
				var _operations = _ExternalOrder.Operations.ToList();
				foreach (var operation in _operations)
				{
					if (operation.DateEnd == DateTime.MinValue)
						operation.DateEnd = bo.Date;
				}
				objectSpace.CommitChanges();
			}

		}
	}
}
