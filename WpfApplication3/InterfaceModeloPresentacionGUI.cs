using System;
using System.Windows.Input;
using Genesyslab.Desktop.Modules.Core.Model.Interactions;

namespace WpfApplication3
{
	/// <summary>
	/// The behabior of the MySampleView class
	/// </summary>
	public interface interfaceModeloPresentacionGUI
	{
		/// <summary>
		/// Gets or sets the header to set in the parent view.
		/// </summary>
		/// <value>The header.</value>
		string Header { get; set; }

		/// <summary>
		/// Gets or sets the counter.
		/// </summary>
		/// <value>The counter.</value>
	

		/// <summary>
		/// Gets or sets the case.
		/// </summary>
		/// <value>The case.</value>
		ICase Case { get; set; }

		/// <summary>
		/// Reset the counter.
		/// </summary>
	
	}
}
