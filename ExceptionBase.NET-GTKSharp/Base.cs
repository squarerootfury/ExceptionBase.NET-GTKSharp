using System;

namespace ExceptionBase.NETGTKSharp
{
	public class Base
	{
		#region "Variables"
		//Initalise Form
		private UserDetails userDetails;
		//Set class variables for usage as error details
		String NETFramework = "";
		String InstalledOS = "";
		public  const string NOTAVALABLE = "Nicht verfügbar";
		public const string DESCKIPPED = "Beschreibung übersprungen";
		#endregion
		#region "Properties"
		Language language { get; set; }
		Server server { get; set; }
		Application application { get; set; }
		ExceptionInfo exception { get; set; }
		#endregion
		#region "Methods"
		//TODO: Change The Drawing.Image to Pixbuf!
		public Base (String Server, int AppID, String Version, Gdk.Pixbuf AppIcon)
		{
			this.language = new Language ();
			this.server = new ExceptionBase.NETGTKSharp.Server ();
			this.application = new Application ();
			this.exception = new ExceptionInfo ();
			this.application.Version = Version;
			this.application.ID = AppID;
			this.server.server = Server;
			this.application.Icon = AppIcon;
			application.ShowErrorDetails = true;
		}
		public void Track (Exception ex, bool AskUser = true, bool ThrowException = false)
		{
			try {
				//Read the informations
				GatherInformation (ex);
				//Track the error
				TrackCustom (AskUser);
			} catch {
				if (ThrowException)
					throw new Exception ();
			}
		}
		public void GatherInformation (Exception ex = null)
		{
			//Get the .NET Framework (MONO)
			//FIXME: Why String and not Version??
			NETFramework = System.Environment.Version.ToString ();
			//FIXME: Maybe here is an Linux bug. Use lsb_release .
			InstalledOS = System.Environment.OSVersion.ToString ();
			if (ex != null) {
				if (ex.Message != null) {
					exception.Message = ex.Message;
				} else {
					exception.Message = NOTAVALABLE;
				}
			
				//Get the inner exception
				if (ex.InnerException != null) {
					exception.Inner = ex.InnerException.ToString ();
				} else {
					exception.Inner = NOTAVALABLE;
				}
				//Get the stack trace
				if (ex.StackTrace != null) {
					exception.StackTrace = ex.StackTrace;
				} else {
					exception.StackTrace = NOTAVALABLE;
				}
				if (ex.TargetSite != null) {
					exception.TargetSite = ex.TargetSite.ToString ();
				} else {
					exception.TargetSite = NOTAVALABLE;
				}
			}
		}

		public void TrackCustom (bool AskUser = true)
		{
			if (AskUser) {

				if (application.ShowErrorDetails) {
					userDetails = new UserDetails (true, this.application, exception, server);
				} else {
					userDetails = new UserDetails (false, this.application, exception, server);
				}
				//TODO: Translate the winform commands
				userDetails.language = this.language;
				userDetails.Show ();
				//FIXME: Needed to move the send call into the dialog

			} else {
				exception.UserDescription = NOTAVALABLE;
			}

		}
		#endregion
	}
}

