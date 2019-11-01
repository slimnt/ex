using System;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using PromAktiv.Core.Module;
using Xafari.BC.HierarchicalData;
using Xafari.SmartDesign;

namespace Galaktika.External.Module.BusinessObjects
{
	[SmartDesignStrategy(typeof(XafariSmartDesignStrategy))]
	[CreateListView(Layout = nameof(Код) + ";" + nameof(Наименование))]
	[CreateListView(Layout = nameof(Код) + ";" + nameof(Наименование), ListViewType = ListViewType.LookupListView)]
	[CreateDetailView(Layout = nameof(Код) + ";" + nameof(Наименование) + ";" + nameof(Children))]

	[Persistent("eamOrderKind")]
	public class OrderKind : СправочникИерархическийШаблон<OrderKind>
	{
		public OrderKind(Session session) : base(session)
		{
		}

		#region Реализация иерархии
		/// <summary>
		/// Gets or sets the parent
		/// </summary>
		/// <value>The parent.</value>
		[Association("OrderKind_Hierarchy")]
		[VisibleInListView(false), VisibleInLookupListView(false)]
		[NoForeignKey, Indexed]
		[ImmediatePostData]
		[DataSourceCriteria("Oid != '@This.Oid'")]
		[ParentProperty]
		[XafDisplayName("Вышестоящий")]
		public OrderKind Parent
		{
			get { return GetPropertyValue<OrderKind>(nameof(this.Parent)); }
			set { SetPropertyValue<OrderKind>(nameof(this.Parent), value); }
		}
		/// <summary>
		/// Gets the children.
		/// </summary>
		/// <value>The children.</value>
		[Association("OrderKind_Hierarchy")]
		[ChildrenProperty(DeletingMode = DeletingMode.Cascade)]
		[XafDisplayName("Нижестоящие")]
		public XPCollection<OrderKind> Children
		{
			get
			{
				return GetCollection<OrderKind>(nameof(this.Children));
			}
		}
		#endregion Реализация иерархии

		#region BusinessLogic
		/// <summary>
		/// Класс бизнес-логики для персистентного объекта OrderKind
		/// </summary>
		public new class Logic : LogicBase<OrderKind>
		{
			/// <summary>
			/// Статический метод для получения экземпляра класса бизнес логики
			/// </summary>
			/// <returns></returns>
			public static Logic CreateInstance()
			{
				return new Logic();
			}

			public override void AfterConstruction(OrderKind instance)
			{
				base.AfterConstruction(instance);
			}

			public override void OnChanged(OrderKind instance, string propertyName, object oldValue, object newValue)
			{
				base.OnChanged(instance, propertyName, oldValue, newValue);
			}

			public override void OnSaving(OrderKind instance)
			{
				base.OnSaving(instance);
			}

			public override void OnDeleting(OrderKind instance)
			{
				base.OnDeleting(instance);
			}
		}
		/// <summary>
		/// Делегат метода для получения экземпляра класса бизнес логики объекта
		/// </summary>
		/// <returns></returns>
		public delegate OrderKind.Logic GetOrderKindLogic();

		/// <summary>
		/// Переменная в которую задается метод, который отвечает за создание экземпляра класса бизнес логики
		/// </summary>
		public static GetOrderKindLogic OrderKindLogicHandler = OrderKind.Logic.CreateInstance;

		/// <summary>
		/// Свойство для хранения экземпляра объекта бизнес логики
		/// </summary>
		private OrderKind.Logic m_OrderKindLogic;

		/// <summary>
		/// Свойство для получения экземпляра класса бизнес логики
		/// </summary>
		[Browsable(false)]
		public OrderKind.Logic OrderKindLogic
		{
			get
			{
				if (m_OrderKindLogic != null)
					return m_OrderKindLogic;
				if (m_OrderKindLogic == null && OrderKindLogicHandler != null)
					m_OrderKindLogic = OrderKindLogicHandler();
				if (m_OrderKindLogic == null)
					m_OrderKindLogic = OrderKind.Logic.CreateInstance();
				return m_OrderKindLogic;
			}
		}
		#endregion
	}
}