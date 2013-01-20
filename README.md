ExceptionBase.NET-GTKSharp
========================

This is an unofficial fork of leolabs' ExceptionBase.NET (https://github.com/leolabs/ExceptionBase.NET-VB.NET) module to use it on Linux, too ;)
The fork uses GTK# to display the dialog. 
At any other point, you can use it like the "original", but you have to use the Gdk.Pixbuf class instead of the Image class.

Differences
========================

At leolabs library you use it with following classes:
(VB) Public ExceptionBase As New ExceptionBase.ExceptionBase("yourdomain.tld/api/addException.php", 0, "2.0.1", My.Resources.icon) 
(C#) ExceptionBase Exceptionbase = new ExceptionBase("yourdomain.tld/api/addException.php", 0, "2.0.1", My.Resources.icon);

The linux fork is used as this:

(VB) Public Exceptionbase as new ExceptionBase.NETGTKSharp.Base("yourdomain.tld/api/addException.php" 0, "2.0.1",  new Gdk.Pixbuf ("imagepath"))) 
(C#)ExceptionBase.NETGTKSharp.Base Exceptionbase = new ExceptionBase.NETGTKSharp.Base ("yourdomain.tld/api/addException.php", 0, "1.0.0.0", new Gdk.Pixbuf ("imagepath"));

The paremeters are: (1) API - Path, (2) Application - ID, (3) App - version, (4) Path to read a Gdk.Pixbuf.

