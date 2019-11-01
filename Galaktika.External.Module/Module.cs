using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using Galaktika.External.Module.LogicController;
using Xafari;
using Xafari.BC.BusinessOperations;
using Galaktika.External.Module.BusinessOperation;
using Galaktika.External.Module.BusinessObjects;
using DevExpress.Xpo;
using Galaktika.External.Module.Reports.OrderReport;

namespace Galaktika.External.Module {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class ExternalModule : ModuleBase, ITypesProvider<IBusinessOperation>, ITypesProvider<IOperationService>
	{
        public ExternalModule() {
            InitializeComponent();
			AdditionalExportedTypes.Add(typeof(PromAktiv.Module.РемонтныеРаботы.НарядЗаказ));
			AdditionalExportedTypes.Add(typeof(Galaktika.External.Module.Reports.OrderReport.OrderParameters));
			AdditionalExportedTypes.Add(typeof(Galaktika.External.Module.Reports.OrderReport.OrderReport));
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }

        public override void Setup(XafApplication application)
		{
            base.Setup(application);
			// Manage various aspects of the application UI and behavior at the module level.
			LogicControllerRegistrator.Register();
			//Регистрация доменного компонента OrderParameters
			XafTypesInfo.Instance.RegisterEntity("OrderParameters", typeof(OrderParameters));

			//подмена бизнес-логики класса НарядЗаказ
			PromAktiv.Module.РемонтныеРаботы.НарядЗаказ.НарядЗаказLogicHandler = BusinessLogic.НарядЗаказLogic.Logic.CreateInstance;
		}

		public override void CustomizeTypesInfo(ITypesInfo typesInfo)
		{
			base.CustomizeTypesInfo(typesInfo);
			CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
			ExternalCalcMemberInfo.CreateMember();

			if (typesInfo == null) return;

			ITypeInfo typeInfoНарядЗаказ = typesInfo.FindTypeInfo(typeof(PromAktiv.Module.РемонтныеРаботы.НарядЗаказ));
			ITypeInfo typeInfoExternalOrder = typesInfo.FindTypeInfo(typeof(ExternalOrder));

			if(typeInfoНарядЗаказ != null)
			{
				var externalOrdersProperty = typeInfoНарядЗаказ.CreateMember("ExternalOrders", typeof(XPCollection<ExternalOrder>));
				externalOrdersProperty.AddAttribute(new DevExpress.Xpo.AssociationAttribute("A", typeof(ExternalOrder)), true);
				externalOrdersProperty.AddAttribute(new DevExpress.Xpo.AggregatedAttribute(), true);

				var externalFactorProperty = typeInfoНарядЗаказ.CreateMember("ExternalFactor", typeof(decimal));
				externalFactorProperty.AddAttribute(new ModelDefaultAttribute("Caption", "Внешний коэффициент"));
			}

			if(typeInfoExternalOrder != null)
			{
				var externalНарядЗаказProperty = typeInfoExternalOrder.CreateMember("НарядЗаказ", typeof(PromAktiv.Module.РемонтныеРаботы.НарядЗаказ));
				externalНарядЗаказProperty.AddAttribute(new DevExpress.Xpo.AssociationAttribute("A", typeof(PromAktiv.Module.РемонтныеРаботы.НарядЗаказ)));
			}

			XafTypesInfo.Instance.RefreshInfo(typeof(PromAktiv.Module.РемонтныеРаботы.НарядЗаказ));
			XafTypesInfo.Instance.RefreshInfo(typeof(ExternalOrder));
		}

		#region Register business operations
		IEnumerable<Type> ITypesProvider<IOperationService>.GetTypes()
		{
			return new[]
			{
				typeof(ExternalOrderCompleteOperationService)
			};
		}

		IEnumerable<Type> ITypesProvider<IBusinessOperation>.GetTypes()
		{
			return new[]
			{
				typeof(ExternalOrderCompleteOperation)
			};
		}
		#endregion Register business operations
	}
}
