namespace Galaktika.External.Module {
	partial class ExternalModule {
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
			// ExternalModule
			// 
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));

			this.RequiredModuleTypes.Add(typeof(Xafari.XafariModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Arms.XafariArmsModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Arm.XafariReportsArmModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.XafariReportsModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Xaf.XafariReportsXafModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Analysis.XafariReportsAnalysisModule));
			this.RequiredModuleTypes.Add(typeof(Xafari.Reports.Xaf.XafariReportsXafModule));
		}

		#endregion
	}
}
