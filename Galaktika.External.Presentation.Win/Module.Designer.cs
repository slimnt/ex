namespace Galaktika.External.Presentation.Win {
	partial class WinModule {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			// 
			// WinModule
			// 
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));

			//this.RequiredModuleTypes.Add(typeof(Xafari.

			this.RequiredModuleTypes.Add(typeof(Galaktika.External.Module.ExternalModule));
			this.RequiredModuleTypes.Add(typeof(Galaktika.External.Module.Win.WinModule));
			this.RequiredModuleTypes.Add(typeof(PromAktiv.Presentation.Win.PromAktivPresentationWinModule));

			
			
			this.RequiredModuleTypes.Add(typeof(Xafari.Arms.Win.XafariArmsWinModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Analysis.Win.XafariReportsAnalysisWinModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Win.XafariReportsWinModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Xaf.Win.XafariReportsXafWinModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Cfg.XafariReportsCfgModule));


		}

		#endregion
	}
}
