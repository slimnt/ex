using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using Galaktika.External.Module.BusinessObjects;
using PromAktiv.Core.Module.LogicControllers;

namespace Galaktika.External.LogicController
{
	class ExternalOrderLogicController : LogicControllerBase<ExternalOrder>
	{
		/// <summary>
		/// Создание экземпляра контроллера
		/// </summary>
		public static ExternalOrderLogicController CreateInstance()
		{
			return new ExternalOrderLogicController();
		}

		public override void OnActivated(ViewController controller, IObjectSpace viewObjectSpace)
		{
			if (controller != null && CheckViewType(controller.View) && viewObjectSpace != null)
			{
				viewObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(viewObjectSpace_ObjectChanged);
			}
		}

		public override void OnDeactivated(ViewController controller, IObjectSpace viewObjectSpace)
		{
			if (controller != null && CheckViewType(controller.View) && viewObjectSpace != null)
			{
				viewObjectSpace.ObjectChanged -= viewObjectSpace_ObjectChanged;
			}
		}

		protected virtual void viewObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
		{
			if (e.NewValue == e.OldValue) return;
			ExternalOrder instance = e.Object as ExternalOrder;
			if (instance == null) return;
		}

		public override void PropertyValueChanged(object entity, string propertyName, object newValue)
		{
			base.PropertyValueChanged(entity, propertyName, newValue);

			var ExternalOrder = entity as ExternalOrder;
			if (ExternalOrder == null) return;

			switch (propertyName)
			{
				case "Product":
					ExternalOrder.SetDefaultProperty();
					break;
				default:
					break;
			}
		}
	}
}
