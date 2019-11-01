﻿using System;
using DevExpress.Xpo;
using PromAktiv.Core.Module;
using PromAktiv.Core.CD.Module.RES;
using PromAktiv.Core.Module.Attributes;
using Xafari.SmartDesign;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace Galaktika.External.Module.BusinessObjects
{
	[SmartDesignStrategy(typeof(XafariSmartDesignStrategy))]
	[CreateListView(Layout = nameof(Number) + ";" + nameof(Наименование) + ";" + nameof(Place) + ";" + nameof(DateBegin) + ";" + nameof(DateEnd) + ";" + nameof(Duration) + ";" + nameof(Sum))]
	[CreateListView(Layout = nameof(Number) + ";" + nameof(Наименование) + ";" + nameof(Place) + ";" + nameof(DateBegin) + ";" + nameof(DateEnd) + ";" + nameof(Duration) + ";" + nameof(Sum), ListViewType = ListViewType.LookupListView)]
	[CreateDetailView(Layout = nameof(Number) + ";" + nameof(Наименование) + ";" + nameof(Place) + ";" + nameof(DateBegin) + ";" + nameof(DateEnd) + ";" + nameof(Duration) + ";" + nameof(Sum) + ";" + nameof(Materials))]

	[Appearance("RedTextOperaton", AppearanceItemType = "ViewItem", TargetItems = "Operation", Context = "ListView", Criteria = "DateBegin.Year > DateTime.Now.Year", Enabled = true, FontColor = "Red")]

	[Persistent("eamOrderOperation")]
	public class OrderOperation : PromAktiv.Core.Module.БазоваяСущность, INumerationSpecification
	{
		public OrderOperation(Session session) : base(session)
		{
		}

		/// <summary>
		/// </summary>
		/// <param name="session"></param>
		/// <param name="код"></param>
		/// <param name="наименование"></param>
		public OrderOperation(Session session, string код, string наименование) : base(session, код, наименование)
		{
		}

		#region BusinessLogic
		/// <summary>
		/// Класс бизнес-логики для персистентного объекта OrderOperation
		/// </summary>
		public class Logic : LogicBase<OrderOperation>
		{
			private CalculationLogic _сalculationLogic = new CalculationLogic();
			// Калькулятор пересчета связанных полей
			/// <summary>
			/// Gets the vat calculation logic.
			/// </summary>
			/// <value>The vat calculation logic.</value>
			/// <autogeneratedoc />
			public CalculationLogic CalculationLogic
			{
				get { return _сalculationLogic; }
			}

			/// <summary>
			/// Статический метод для получения экземпляра класса бизнес логики
			/// </summary>
			/// <returns></returns>
			public static Logic CreateInstance()
			{
				return new Logic();
			}

			public override void AfterConstruction(OrderOperation instance)
			{
				base.AfterConstruction(instance);
			}

			public override void OnChanged(OrderOperation instance, string propertyName, object oldValue, object newValue)
			{
				switch (propertyName)
				{
					case "DateBegin":
						CalculationLogic.OnChanged(instance, "DateBegin", oldValue, newValue);
						break;
					case "DateEnd":
						CalculationLogic.OnChanged(instance, "DateEnd", oldValue, newValue);
						break;
					case "Duration":
						CalculationLogic.OnChanged(instance, "Duration", oldValue, newValue);
						break;
				}
			}
		}
		/// <summary>
		/// Делегат метода для получения экземпляра класса бизнес логики объекта
		/// </summary>
		/// <returns></returns>
		public delegate OrderOperation.Logic GetOrderOperationLogic();

		/// <summary>
		/// Переменная в которую задается метод, который отвечает за создание экземпляра класса бизнес логики
		/// </summary>
		public static GetOrderOperationLogic OrderOperationLogicHandler = OrderOperation.Logic.CreateInstance;

		/// <summary>
		/// Свойство для хранения экземпляра объекта бизнес логики
		/// </summary>
		private OrderOperation.Logic m_OrderOperationLogic;

		/// <summary>
		/// Свойство для получения экземпляра класса бизнес логики
		/// </summary>
		[Browsable(false)]
		public OrderOperation.Logic OrderOperationLogic
		{
			get
			{
				if (m_OrderOperationLogic != null)
					return m_OrderOperationLogic;
				if (m_OrderOperationLogic == null && OrderOperationLogicHandler != null)
					m_OrderOperationLogic = OrderOperationLogicHandler();
				if (m_OrderOperationLogic == null)
					m_OrderOperationLogic = OrderOperation.Logic.CreateInstance();
				return m_OrderOperationLogic;
			}
		}
		#endregion

		#region Properties

		private int _number;
		/// <summary>
		/// Порядковый номер операции в заказе 
		/// </summary>
		[NonCopyPaste]
		[RuleRequiredField(DefaultContexts.Save)]
		public int Number
		{
			get { return _number; }
			set { SetPropertyValue<int>(nameof(Number), ref _number, value); }
		}

		private ПроизводственнаяЕдиница _place;
		/// <summary>
		/// Подразделение, где выполняется операция
		/// </summary>
		[RuleRequiredField(DefaultContexts.Save)]
		public ПроизводственнаяЕдиница Place
		{
			get { return _place; }
			set { SetPropertyValue<ПроизводственнаяЕдиница>(nameof(Place), ref _place, value); }
		}

		private decimal _sum;
		/// <summary>
		/// Общая стоимость по операции
		/// </summary>
		[ModelDefault("DisplayFormat", "c2"), ModelDefault("EditMask", "c2")]
		public decimal Sum
		{
			get { return _sum; }
			set { SetPropertyValue<decimal>(nameof(Sum), ref _sum, value); }
		}


		private TimeSpan _duration;
		/// <summary>
		/// Длительность операции
		/// </summary>
		public TimeSpan Duration
		{
			get { return _duration; }
			set { SetPropertyValue<TimeSpan>(nameof(Duration), ref _duration, value); }
		}

		private DateTime _dateBegin;
		/// <summary>
		/// Дата начала выполнения операции
		/// </summary>
		[ModelDefault("DisplayFormat", "dd.MM.yyyy"), ModelDefault("EditMask", "dd.MM.yyyy")]
		public DateTime DateBegin
		{
			get { return _dateBegin; }
			set { SetPropertyValue<DateTime>(nameof(DateBegin), ref _dateBegin, value); }
		}

		private DateTime _dateEnd;
		/// <summary>
		/// Дата окончания выполнения операции 
		/// </summary>
		[ModelDefault("DisplayFormat", "dd.MM.yyyy"), ModelDefault("EditMask", "dd.MM.yyyy")]
		public DateTime DateEnd
		{
			get { return _dateEnd; }
			set { SetPropertyValue<DateTime>(nameof(DateEnd), ref _dateEnd, value); }
		}

		private ExternalOrder _externalOrder;
		/// <summary>
		/// ссылка на ExternalOrder
		/// </summary>
		[Association]
		public ExternalOrder ExternalOrder
		{
			get { return _externalOrder; }
			set { SetPropertyValue<ExternalOrder>(nameof(ExternalOrder), ref _externalOrder, value); }
		}

		/// <summary>
		/// Список материалов, которые были использованы при выполнении операции
		/// </summary>
		[Association, Aggregated]
		[CollectionProperty(true, false)]
		public XPCollection<OrderMaterial> Materials
		{
			get
			{
				return GetCollection<OrderMaterial>("Materials");
			}
		}
		#endregion

		#region Пересчёт связанных полей
		/// <summary>
		/// Пересчёт связанных полей Sum и Qty
		/// </summary>
		public class CalculationLogic : DependentFieldsLogic<OrderOperation>
		{
			public override void Calculate(OrderOperation instance, string propertyName, object oldValue, object newValue)
			{
				if (instance == null)
					return;

				switch (propertyName)
				{
					case "DateBegin":
						{
							instance.DateEnd = instance.DateBegin + instance.Duration;
							instance.Duration = instance.DateEnd - instance.DateBegin;
						}
						break;
					case "DateEnd":
						{
							instance.Duration = instance.DateEnd - instance.DateBegin;
						}
						break;
					case "Duration":
						{
							instance.DateEnd = instance.DateBegin + instance.Duration;
						}
						break;
				}
			}

			public void AfterConstruction(OrderOperation instance)
			{
				if (instance == null)
					return;

				instance.DateBegin = instance.DateEnd - instance.Duration;
			}
		}
		#endregion

		#region Методы класса
		public override void AfterConstruction()
		{
			base.AfterConstruction();
			OrderOperationLogic.AfterConstruction(this);
		}

		protected override void OnChanged(string propertyName, object oldValue, object newValue)
		{
			base.OnChanged(propertyName, oldValue, newValue);
			OrderOperationLogic.OnChanged(this, propertyName, oldValue, newValue);
		}
		#endregion

		/// <summary>
		/// Метод для подсчёта суммы операции по сумме всех материалов
		/// </summary>
		public void CalculateOperationSum()
		{
			decimal sum = 0m;
			foreach (var item in Materials)
				sum += item.Sum;
			Sum = sum;
		}

		#region Обработка сигнала OnChanged
		/// <summary>
		/// Обработка сигнала OnChanged
		/// </summary>
		[SignalType(БазовыйОбъект.SIGNAL_ON_CHANGED)]
		public class OrderMaterial_OnChangedSignalHandler : SignalHandlerBase<OrderMaterial, OrderOperation>
		{
			private static OrderMaterial_OnChangedSignalHandler instance;
			/// <summary>
			/// Экземпляр обработчика.
			/// </summary>
			public static OrderMaterial_OnChangedSignalHandler Instance
			{
				get
				{
					if (instance == null) instance = new OrderMaterial_OnChangedSignalHandler();
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
				OrderMaterial operation = (OrderMaterial)sender;

				foreach (var receiver in GetReceivers(operation))
				{
					if (receiver != null)
					{
						if (args.PropertyName == "Sum")
							receiver.RunDelayed(receiver.CalculateOperationSum);
					}
				}
			}

			/// <summary>
			/// Возвращает получателей сигнала.
			/// </summary>
			/// <param name="sender">Объект, посылающий сигнал.</param>
			/// <returns>Объекты, принимающие сигнал.</returns>
			public override IEnumerable<OrderOperation> GetReceivers(OrderMaterial sender)
			{
				if (sender == null || sender.Operation == null)
				{
					return Enumerable.Empty<OrderOperation>();
				}
				else
				{
					return Enumerable.Repeat(sender.Operation, 1);
				}
			}
		}
		#endregion

		#region INumerationSpecification
		public int GetNextNumber()
		{
			if (this.ExternalOrder != null)
				return NumerationSpecificationService.GetLastNumber(this.ExternalOrder.Operations);
			return 0;
		}
		#endregion
	}
}