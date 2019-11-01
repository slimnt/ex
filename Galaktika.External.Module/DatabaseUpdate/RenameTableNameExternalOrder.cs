using DevExpress.ExpressApp;
using DevExpress.Xpo;
using PromAktiv.Core.Module.Converters;
using PromAktiv.Utils.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.External.Module.DatabaseUpdate
{
	[MultipleExecute(false)]
	[NonPersistent]
	[Description(@"Переименование таблицы eamExternalOrder в ExternalOrder")]
	[Number(7667)]
	class RenameTableNameExternalOrder : BaseConverter
	{
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="objectSpace">IObjectSpace.</param>
		/// <param name="currentDBVersion">Текущая версия БД.</param>
		/// <param name="moduleType">Type of the module.</param>
		public RenameTableNameExternalOrder (IObjectSpace objectSpace, Version currentDBVersion, Type moduleType) : base(objectSpace, currentDBVersion, moduleType)
		{

		}

		protected override void ExecuteCore()
		{
			var dbManager = EAMDBFactory.CreateDBManager(this.Session);
			if (dbManager != null)
			{
				//только если существует таблица eamExternalOrder и не существует таблица ExternalOrder
				if (dbManager.IsTableExists("eamExternalOrder") && !dbManager.IsTableExists("ExternalOrder"))
				{
					dbManager.RenameTable("eamExternalOrder", "ExternalOrder");
				}
			}

		}
	}
}
