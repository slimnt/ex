using PromAktiv.Core.Module.LogicControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromAktiv.Core.Module;
using Galaktika.External.Module.BusinessObjects;
using Galaktika.External.LogicController;

namespace Galaktika.External.Module.LogicController
{
	class LogicControllerRegistrator
	{
		public static void Register()
		{
			LogicControllerService.Register<ExternalOrder>(typeof(ExternalOrderLogicController), ExternalOrderLogicController.CreateInstance);
		}
	}
}
