using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;

namespace WpfApplication3
{
	/// <summary>
	/// Interface matching the MySampleView view
	/// </summary>
	public interface InterfazGUI : IView,IMin
	{
		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>The model.</value>
		interfaceModeloPresentacionGUI Model { get; set; }
	}
}
