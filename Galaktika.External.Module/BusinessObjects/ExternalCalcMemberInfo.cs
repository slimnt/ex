using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo.Metadata;
using PromAktiv.Module.РемонтныеРаботы;
using System;


namespace Galaktika.External.Module.BusinessObjects
{
	class ExternalCalcMemberInfo : XPCustomMemberInfo
	{
		public ExternalCalcMemberInfo(XPClassInfo owner, string propertyName, Type propertyType, XPClassInfo referenceType, bool nonPersistent, bool nonPublic) : base(owner, propertyName, propertyType, referenceType, nonPersistent, nonPublic)
		{
		}

		/// <summary>
		/// Добавление нового свойства ExternalCalc к классу НарядЗаказ
		/// </summary>
		/// <returns></returns>
		public static ExternalCalcMemberInfo CreateMember()
		{
			var classInfo = XpoTypesInfoHelper.GetXpoTypeInfoSource().XPDictionary.GetClassInfo(typeof(НарядЗаказ));

			var propertyClassInfo = XpoTypesInfoHelper.GetXpoTypeInfoSource().GetEntityClassInfo(typeof(Decimal));
			var member = new ExternalCalcMemberInfo(classInfo, "ExternalCalc", typeof(decimal), propertyClassInfo, true, false);
			if (member != null)
			{
				member.AddAttribute(new ModelDefaultAttribute("Caption", "Вычисляемый атрибут"));
			}
			XafTypesInfo.Instance.RefreshInfo(typeof(НарядЗаказ));
			return member;
		}

		/// <summary>
		///  Получение значения свойства (get)
		/// </summary>
		/// <returns></returns>
		public override object GetValue(object theObject)
		{
			var value = base.GetValue(theObject);

			var asset = theObject as НарядЗаказ;
			if (value == null && asset != null)
			{
				var externalCalc = asset.GetMemberValue("ExternalCalc");
				return externalCalc;
			}
			return 0m;
		}

		/// <summary>
		/// Установка значения свойства
		/// </summary>
		/// <returns></returns>
		public override void SetValue(object theObject, object theValue)
		{
			base.SetValue(theObject, theValue);
		}
	}
}