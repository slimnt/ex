using System;
using PromAktiv.Module.РемонтныеРаботы;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.External.BusinessLogic
{
	public class НарядЗаказLogic
	{
		//Подмена класса бизнес логики 
		public class Logic : НарядЗаказ.Logic
		{
			/// <summary>
			/// Статический метод для получения экземпляра класса бизнес логики
			/// </summary>
			/// <returns></returns>
			public static new Logic CreateInstance()
			{
				return new Logic();
			}

			public override void AfterConstruction(НарядЗаказ instance)
			{
				base.AfterConstruction(instance);

				instance.SetMemberValue("ExternalFactor", 1m);
			}
		}
	}
}