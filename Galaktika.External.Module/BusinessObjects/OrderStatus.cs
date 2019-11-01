using System;
using System.ComponentModel;
using DevExpress.Xpo;
using PromAktiv.Core.Module;
using Xafari.SmartDesign;

namespace Galaktika.External.Module.BusinessObjects
{
	[SmartDesignStrategy(typeof(XafariSmartDesignStrategy))]
	[CreateListView(Layout = nameof(Код) + ";" + nameof(Наименование))]
	[CreateListView(Layout = nameof(Код) + ";" + nameof(Наименование), ListViewType = ListViewType.LookupListView)]
	[CreateDetailView(Layout = nameof(Код) + ";" + nameof(Наименование))]

	[Persistent("eamOrderStatus")]
	public class OrderStatus : Справочник
	{
		public OrderStatus(Session session) : base(session)
		{
		}

		public OrderStatus(Session session, string Код, string Наименование) : base(session, Код, Наименование)
		{
		}

		#region BusinessLogic
		/// <summary>
		/// Класс бизнес-логики для персистентного объекта OrderStatus
		/// </summary>
		public class Logic : LogicBase<OrderStatus>
		{
			/// <summary>
			/// Статический метод для получения экземпляра класса бизнес логики
			/// </summary>
			/// <returns></returns>
			public static Logic CreateInstance()
			{
				return new Logic();
			}

			public override void AfterConstruction(OrderStatus instance)
			{
				base.AfterConstruction(instance);
			}

			public override void OnChanged(OrderStatus instance, string propertyName, object oldValue, object newValue)
			{
				base.OnChanged(instance, propertyName, oldValue, newValue);
			}

			public override void OnSaving(OrderStatus instance)
			{
				base.OnSaving(instance);
			}

			public override void OnDeleting(OrderStatus instance)
			{
				base.OnDeleting(instance);
			}
		}
		/// <summary>
		/// Делегат метода для получения экземпляра класса бизнес логики объекта
		/// </summary>
		/// <returns></returns>
		public delegate OrderStatus.Logic GetOrderStatusLogic();

		/// <summary>
		/// Переменная в которую задается метод, который отвечает за создание экземпляра класса бизнес логики
		/// </summary>
		public static GetOrderStatusLogic OrderStatusLogicHandler = OrderStatus.Logic.CreateInstance;

		/// <summary>
		/// Свойство для хранения экземпляра объекта бизнес логики
		/// </summary>
		private OrderStatus.Logic m_OrderStatusLogic;

		/// <summary>
		/// Свойство для получения экземпляра класса бизнес логики
		/// </summary>
		[Browsable(false)]
		private OrderStatus.Logic OrderStatusLogic
		{
			get
			{
				if (m_OrderStatusLogic != null)
					return m_OrderStatusLogic;
				if (m_OrderStatusLogic == null && OrderStatusLogicHandler != null)
					m_OrderStatusLogic = OrderStatusLogicHandler();
				if (m_OrderStatusLogic == null)
					m_OrderStatusLogic = OrderStatus.Logic.CreateInstance();
				return m_OrderStatusLogic;
			}
		}
		#endregion
	}
}