using System;

namespace ExceptionBase.NETGTKSharp
{
	public class Language
	{
		public String winTitle { get; set; }
		public String winDescription { get; set; }
		public String tabInputCaption { get; set; }
		public String tabDetailedInfoCaption { get; set; }
		public String appVersionCaption { get; set; }
		public String netVersionCaption { get; set; }
		public String osVersionCaption { get; set; }
		public String errorDetailsCaption { get; set; }
		public String bSkip { get; set; }
		public String bSend { get; set; }
		public Language ()
		{
			winTitle = "Benutzerdetails zu dem Fehler";
			winDescription = "Es ist ein schwerwiegender Fehler aufgetreten. Bitte beschreiben Sie die Schritte, die zu dem Fehler geführt haben könnten, damit wir ihn so schnell wie möglich beheben können.";
			tabInputCaption = "Beschreibung des Fehlers";
			tabDetailedInfoCaption = "Weitere Informationen";
			appVersionCaption = "Programmversion";
			netVersionCaption = "CLI Version";
			osVersionCaption = "Betriebssystem";
			errorDetailsCaption = "Fehler - Details";
			bSkip = "Überspringen";
			bSend = "OK";
		}
	}
	public class Server
	{
		public String server { get; set; }
		public String PingIP { get; set; }
		public Server ()
		{
			PingIP = "8.8.8.8";
		}
	}
	public class Application
	{
		public String Version { get; set; }
		public int ID { get; set; }
		public Gdk.Pixbuf Icon { get; set; }
		public Boolean ShowErrorDetails { get; set; }
		public Application ()
		{
			Version = "";
			ShowErrorDetails = true;
		}
	}
	public class ExceptionInfo
	{
		public String Message { get; set; }
		public String Inner { get; set; }
		public String StackTrace { get; set; }
		public String TargetSite { get; set; }
		public String UserDescription { get; set; }
	}
}

