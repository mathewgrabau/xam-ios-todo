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
	[Register ("UpdateItemViewController")]
	partial class UpdateItemViewController
	{
		[Outlet]
		UIKit.UILabel nameLabel { get; set; }

		[Action ("completeClicked:")]
		partial void completeClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}
		}
	}
}
