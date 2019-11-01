using System;
using System.Linq;
using DevExpress.Xpo;
using PromAktiv.Core.Module;
using PromAktiv.Core.CD.Module.ITM;
using PromAktiv.Core.Module.Attributes;
using Xafari.SmartDesign;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;
using PromAktiv.Module.РемонтныеРаботы;
using DevExpress.Persistent.Base;

namespace Galaktika.External.Module.BusinessObjects
{	
	[SmartDesignStrategy(typeof(XafariSmartDesignStrategy))]
	[CreateListView(Layout = nameof(Номер) + ";" + nameof(OrderStatus) + ";" + nameof(OrderKind) + ";" + nameof(ДатаДокумента) + ";" + nameof(Наименование) + ";" + nameof(Product) + ";"
		+ nameof(Qty) + ";" + nameof(Sum) + ";" + nameof(DateBegin) + ";" + nameof(DateEnd))]
	[CreateListView(Layout = nameof(Номер) + ";" + nameof(OrderStatus) + ";" + nameof(OrderKind) + ";" + nameof(ДатаДокумента) + ";" + nameof(Наименование) + ";" + nameof(Product) + ";"
		+ nameof(Qty) + ";" + nameof(Sum) + ";" + nameof(DateBegin) + ";" + nameof(DateEnd), ListViewType = ListViewType.LookupListView)]
	[CreateDetailView(Layout = nameof(Номер) + ";" + nameof(OrderStatus) + ";" + nameof(Наименование) + ";" + nameof(Qty) + ";" + nameof(OrderKind) + ";" + nameof(Sum) + ";"
		+ nameof(ДатаДокумента) + ";" + nameof(DateBegin) + ";" + nameof(Product) + ";" + nameof(DateEnd) + ";" + nameof(Operations))]

	//[VisibleInReports]
	[Appearance("YellowProduct", AppearanceItemType = "ViewItem", TargetItems = "Product", Context = "ListView", Criteria = "Product == null", Enabled = true, BackColor = "Yellow")]
	[Persistent("eamExternalOrder")]
	public class ExternalOrder : Документ
	{
		public ExternalOrder(Session session)
			: base(session)
		{
		}

		#region BusinessLogic
		/// <summary>
		/// Класс бизнес-логики для персистентного объекта ExternalOrder
		/// </summary>
		public class Logic : LogicBase<ExternalOrder>
		{
			/// <summary>
			/// Статический метод для получения экземпляра класса бизнес логики
			/// </summary>
			/// <returns></returns>
			public static Logic CreateInstance()
			{
				return new Logic();
			}
		}

		/// <summary>
		/// Делегат метода для получения экземпляра класса бизнес логики объекта
		/// </summary>
		public delegate ExternalOrder.Logic GetExternalOrderLogic();

		/// <summary>
		/// Переменная в которую задается метод, который отвечает за создание экземпляра класса бизнес логики
		/// </summary>
		public static GetExternalOrderLogic ExternalOrderLogicHandler = ExternalOrder.Logic.CreateInstance;

		/// <summary>
		/// Свойство для хранения экземпляра объекта бизнес логики
		/// </summary>
		private ExternalOrder.Logic m_ExternalOrderLogic;

		/// <summary>
		/// Свойство для получения экземпляра класса бизнес логики
		/// </summary>
		[Browsable(false)]
		public ExternalOrder.Logic ExternalOrderLogic
		{
			get
			{
				if (m_ExternalOrderLogic != null)
					return m_ExternalOrderLogic;
				if (m_ExternalOrderLogic == null && ExternalOrderLogicHandler != null)
					m_ExternalOrderLogic = ExternalOrderLogicHandler();
				if (m_ExternalOrderLogic == null)
					m_ExternalOrderLogic = ExternalOrder.Logic.CreateInstance();
				return m_ExternalOrderLogic;
			}
		}
		#endregion

		#region Properties
		private НоменклатурнаяПозиция _product;
		/// <summary>
		/// Номенклатурная позиция для производства
		/// </summary>
		[RuleRequiredField(DefaultContexts.Save)]
		public НоменклатурнаяПозиция Product
		{
			get { return _product; }
			set { SetPropertyValue<НоменклатурнаяПозиция>(nameof(Product), ref _product, value); }
		}

		private decimal _sum;
		/// <summary>
		/// Общая стоимость по заказу
		/// </summary>
		[ModelDefault("DisplayFormat", "c2"), ModelDefault("EditMask", "c2")]
		[RuleRequiredField(DefaultContexts.Save)]
		public decimal Sum
		{
			get { return _sum; }
			set { SetPropertyValue<decimal>(nameof(Sum), ref _sum, value); }
		}

		/// <summary>
		/// Список операций
		/// </summary>
		[CollectionProperty(true, false)]
		[Association, Aggregated]
		public XPCollection<OrderOperation> Operations
		{
			get
			{
				return GetCollection<OrderOperation>("Operations");
			}
		}

		private OrderStatus _ordertStatus;
		/// <summary>
		/// Текущий статус заказа
		/// </summary>
		[RuleRequiredField(DefaultContexts.Save)]
		public OrderStatus OrderStatus
		{
			get { return _ordertStatus; }
			set { SetPropertyValue<OrderStatus>(nameof(OrderStatus), ref _ordertStatus, value); }
		}

		private OrderKind _ordertKind;
		/// <summary>
		/// Вид, к которому относится заказ
		/// </summary>
		[RuleRequiredField(DefaultContexts.Save)]
		public OrderKind OrderKind
		{
			get { return _ordertKind; }
			set { SetPropertyValue<OrderKind>(nameof(OrderKind), ref _ordertKind, value); }
		}

		private DateTime _dateBegin;
		/// <summary>
		/// Дата начала проведения работ
		/// </summary>
		[ModelDefault("DisplayFormat", "{dd.MM.yyyy}"), ModelDefault("EditMask", "dd.MM.yyyy")]
		public DateTime DateBegin
		{
			get { return _dateBegin; }
			set { SetPropertyValue<DateTime>(nameof(DateBegin), ref _dateBegin, value); }
		}

		private DateTime _dateEnd;
		/// <summary>
		/// Дата окончания проведения работ
		/// </summary>
		[ModelDefault("DisplayFormat", "{dd.MM.yyyy}"), ModelDefault("EditMask", "dd.MM.yyyy")]
		public DateTime DateEnd
		{
			get { return _dateEnd; }
			set { SetPropertyValue<DateTime>(nameof(DateEnd), ref _dateEnd, value); }
		}

		private decimal _qty;
		/// <summary>
		/// Количество изготавливаемой НП
		/// </summary>
		[RuleRange("", DefaultContexts.Save, 0, 100)]
		[ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
		public decimal Qty
		{
			get { return _qty; }
			set { SetPropertyValue<decimal>(nameof(Qty), ref _qty, value); }
		}
		#endregion

		#region Методы пересчёта хранимо-вычисляемых полей
		/// <summary>
		/// Метод для подсчёта суммы заказа по сумме всех операций
		/// </summary>
		private void CalculateOrderSum()
		{
			decimal sum = 0m;
			foreach (var item in Operations)
				sum += item.Sum;
			Sum = sum;
		}

		/// <summary>
		/// Поиск минимальной даты во всех операциях
		/// </summary>
		private void FindDateBegin()
		{
			DateBegin = Operations.Min(o => o.DateBegin);
		}

		/// <summary>
		/// Поиск максимальной даты во всех операциях
		/// </summary>
		private void FindDateEnd()
		{
			DateEnd = Operations.Max(o => o.DateEnd);
		}
		#endregion

		#region Обработка сигнала OnChanged
		/// <summary>
		/// Обработка сигнала OnChanged
		/// </summary>
		[SignalType(БазовыйОбъект.SIGNAL_ON_CHANGED)]
		public class OrderOperation_OnChangedSignalHandler : SignalHandlerBase<OrderOperation, ExternalOrder>
		{
			private static OrderOperation_OnChangedSignalHandler instance;
			/// <summary>
			/// Экземпляр обработчика.
			/// </summary>
			public static OrderOperation_OnChangedSignalHandler Instance
			{
				get
				{
					if (instance == null) instance = new OrderOperation_OnChangedSignalHandler();
					return instance;
				}
			}

			/// <summary>
			/// Метод выполнения обработчика.
			/// </summary>
			/// <param name="sender">Объект, посылающий сигнал.</param>
			/// <param name="args">Параметры сигнала.</param>
			public override void Execute(object sender, SignalEventArgs args)
			{
				OrderOperation operation = (OrderOperation)sender;
				foreach (var receiver in GetReceivers(operation))
				{
					if (receiver != null)
					{
						if (args.PropertyName == "Sum")
							receiver.RunDelayed(receiver.CalculateOrderSum);
						if (args.PropertyName == "DateBegin")
							receiver.RunDelayed(receiver.FindDateBegin);
						if (args.PropertyName == "DateEnd")
							receiver.RunDelayed(receiver.FindDateEnd);
					}
				}
			}

			/// <summary>
			/// Возвращает получателей сигнала.
			/// </summary>
			/// <param name="sender">Объект, посылающий сигнал.</param>
			/// <returns>Объекты, принимающие сигнал.</returns>
			public override IEnumerable<ExternalOrder> GetReceivers(OrderOperation sender)
			{
				if (sender == null || sender.ExternalOrder == null)
				{
					return Enumerable.Empty<ExternalOrder>();
				}
				else
				{
					return Enumerable.Repeat(sender.ExternalOrder, 1);
				}
			}
		}
		#endregion

		public void SetDefaultProperty()
		{
			this.DateBegin = DateTime.MinValue;
			this.DateEnd = DateTime.MinValue;
			this.OrderKind = null;
			this.Sum = 1;
			this.ДатаДокумента = DateTime.MinValue;

			var newOrderStatus = new OrderStatus(this.Session) { Код = "01", Наименование = "Новый" };
			//Dictionary<string, Object> propertyValueStore = new Dictionary<string, object>();
			//propertyValueStore.Add("Код", "01");
			//propertyValueStore.Add("Наименование", "В работе");
			//XpoBatch.Insert<OrderStatus>(this.Session, propertyValueStore, newOrderStatus);
			newOrderStatus.Save();
			this.OrderStatus = newOrderStatus;

			Session session = this.Session;
			session.Delete(this.Operations);
			session.Save(this.Operations);
		}

		protected override void OnSaving()
		{
			base.OnSaving();
			ExternalOrderLogic.OnSaving(this);
		}
	}
}