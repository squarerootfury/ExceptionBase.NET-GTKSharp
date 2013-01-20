using System;
using Gtk;
using GtkSharp;
using System.Diagnostics;
namespace ExceptionBase.NETGTKSharp
{
	public partial class UserDetails : Gtk.Window
	{
		public Language language = new Language ();
		public ResponseType Response;
		public String UserDescription;
		private ExceptionInfo ex;
		private Server sv;
		private Application appl;
		public UserDetails (bool showDetailed, ExceptionBase.NETGTKSharp.Application app, ExceptionInfo exinfo, Server server) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			//Set title and description
			this.Title = language.winTitle;
			this.lblDescription.Text = language.winDescription;
			//Name the tabs
			this.btnSkip.Label = language.bSkip;
			this.btnSend.Label = language.bSend;
			GtkLabel3.Text = language.appVersionCaption;
			GtkLabel4.Text = language.netVersionCaption;
			GtkLabel5.Text = language.osVersionCaption;
			GtkLabel.Text = language.errorDetailsCaption;
			label6.Text = app.Version;
			label7.Text = Environment.Version.ToString ();
			label8.Text = ReadSTDOutput ("lsb_release", "--d").Replace ("Description:", "").Trim () + " " + ReadSTDOutput ("arch", "");
			this.image26.Pixbuf = app.Icon;
			label4.Text = exinfo.Message;
			label5.Text = exinfo.Inner;
			ex = exinfo;
			sv = server;
			appl = app;
			if (showDetailed == false)
				notebook1.GetNthPage (1).HideAll ();
		}
		protected void OnBtnSkipClicked (object sender, EventArgs e)
		{
			this.Response = ResponseType.Cancel;		
			ex.UserDescription = ExceptionBase.NETGTKSharp.Base.NOTAVALABLE;
			this.HideAll ();
		}		
		protected void OnBtnSendClicked (object sender, EventArgs e)
		{
			Response = ResponseType.Accept;
			this.UserDescription = textview1.Buffer.Text;
			this.HideAll ();
			Send (ex, sv);
		}
		public static string ReadSTDOutput (string fileName, string arguments)
		{
			try {
				Process process = new Process ();
	
				process.StartInfo.FileName = fileName;
				process.StartInfo.Arguments = arguments;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
	
				process.Start ();
	
				string DefaultOutput = process.StandardOutput.ReadToEnd ();
	
				process.Close ();
	
				return DefaultOutput;
			} catch {
				return "";
			}
		}
		public void Send (ExceptionInfo exception, Server server)
		{
			string NETFramework = "0.0"; 
			string InstalledOS = "Other Linux";

			try {
				NETFramework = Environment.Version.ToString ();
				InstalledOS = ReadSTDOutput ("lsb_release", "--d").Replace ("Description:", "").Trim ();
			} catch {

			}
			String args = "em=" + exception.Message + "&ei=" + exception.Inner + "&st=" + exception.StackTrace + "&eme=" + exception.TargetSite + "&udesc=" + exception.UserDescription + "&appid=" + appl.ID + "&v=" + appl.Version + "&net=" + NETFramework + "&os=" + InstalledOS;
			//TODO: Changed the not existing namespace to C#
			if (true) { //new System.Net.NetworkInformation.Ping ().Send (server.PingIP).Status == System.Net.NetworkInformation.IPStatus.Success) {
				if (Functions.PostURL (server.server, args).Split (';') [0] == "1") {
					//TODO: Logging into the system logs
				} else {
					//FIXME: Hey leolabs, you have a bug there.
				}
			}
		}

	}
}

