//
// FSpotTabbloExport.TabbloExportView
//
// Authors:
//	Wojciech Dzierzanowski (wojciech.dzierzanowski@gmail.com)
//
// (C) Copyright 2009 Wojciech Dzierzanowski
//

// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System.Reflection;

using Gtk;

using FSpot.Core;
using FSpot.Widgets;

namespace FSpot.Exporters.Tabblo
{
	class TabbloExportView : FSpot.UI.Dialog.BuilderDialog
	{
		const string DialogName = "tabblo_export_dialog";

		[Builder.Object] ScrolledWindow thumb_scrolled_window;
		[Builder.Object] internal Entry username_entry;
		[Builder.Object] internal Entry password_entry;
		[Builder.Object] internal CheckButton attach_tags_button;
		[Builder.Object] Alignment attached_tags_alignment;
		internal TagView attached_tags_view; 
		[Builder.Object] internal Button attached_tags_select_button;
		[Builder.Object] internal CheckButton remove_tags_button;
		[Builder.Object] Alignment removed_tags_alignment;
		internal TagView removed_tags_view; 
		[Builder.Object] internal Button removed_tags_select_button;
		[Builder.Object] Button export_button;


		internal TabbloExportView (IBrowsableCollection photos)
			: base (Assembly.GetExecutingAssembly (),
					"TabbloExport.ui", DialogName)
		{
			// Thumbnails
			var icon_view = new TrayView (photos);
			icon_view.DisplayDates = false;
			icon_view.DisplayTags = false;

			thumb_scrolled_window.Add (icon_view);
			icon_view.Show ();

			// Tags
			attached_tags_view = new TagView ();
			attached_tags_alignment.Add (attached_tags_view);
			attached_tags_view.Show ();

			removed_tags_view = new TagView ();
			removed_tags_alignment.Add (removed_tags_view);
			removed_tags_view.Show ();
		}


		internal void ResetFocus ()
		{
			export_button.HasFocus = true;
		}


		internal bool Validated {
			set {
				export_button.Sensitive = value;
			}
		}
	}
}
