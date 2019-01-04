// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@Libra.net"/>
//     <version>$Revision: 915 $</version>
// </file>

//
// Used and Modified and Recommented BY Jingwei.WU
// 2009.03.25
//


using System;

namespace Libra.Core
{
	public delegate void FileNameEventHandler(object sender, FileNameEventArgs e);
	
	/// <summary>
	/// Description of FileEventHandler.
	/// </summary>
	public class FileNameEventArgs : System.EventArgs
	{
		string fileName;
		
		public string FileName {
			get {
				return fileName;
			}
		}
		
		public FileNameEventArgs(string fileName)
		{
			this.fileName = fileName;
		}
	}
}
