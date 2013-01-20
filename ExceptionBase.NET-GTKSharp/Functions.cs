using System;
using System.Net;
using System.Text;
using System.Reflection;
namespace ExceptionBase.NETGTKSharp
{
	public static class  Functions
	{
		public static string  PostURL (string url, string arguments)
		{
			try {
				WebClient oWeb = new WebClient ();
				//DEBUG ONLY:libTerminus.MessageBox.Show (arguments.Replace ("&", "&amp;"), "ff", Gtk.ButtonsType.Cancel, Gtk.MessageType.Error, null);
				oWeb.Headers.Add ("Content-Type", "application/x-ww-form-urlencoded");
				string ua = @"WebClient (" + UserDetails.ReadSTDOutput ("lsb_release", "--d").Replace ("Description:", "").Trim () + ") ExceptionBase.NET " + Assembly.GetCallingAssembly ().GetName ().Version.ToString ();
				libTerminus.MessageBox.Show (ua, "ff", Gtk.ButtonsType.Cancel, Gtk.MessageType.Error, null);
				oWeb.Headers.Add (HttpRequestHeader.UserAgent, ua);
				Byte[] bytArguments = Encoding.UTF8.GetBytes (arguments);
				Byte[] bytRetData = oWeb.UploadData (url, "POST", bytArguments);
				return Encoding.UTF8.GetString (bytRetData);
			} catch {				
				return "0";
			}
		}
	}
}

