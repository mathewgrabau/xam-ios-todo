// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ToDoList
{
	[Register ("NewItemViewController")]
	partial class NewItemViewController
	{
		[Outlet]
		UIKit.UIButton addButton { get; set; }

		[Outlet]
		UIKit.UISwitch importantSwitch { get; set; }

		[Outlet]
		UIKit.UITextField nameTextField { get; set; }

		[Action ("addButtonClicked:")]
		partial void addButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (nameTextField != null) {
				nameTextField.Dispose ();
				nameTextField = null;
			}

			if (importantSwitch != null) {
				importantSwitch.Dispose ();
				importantSwitch = null;
			}

			if (addButton != null) {
				addButton.Dispose ();
				addButton = null;
			}
		}
	}
}
