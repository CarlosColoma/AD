using System;
using Gtk;
	
namespace Pgeestion
{
	public class categorialistview
	{
		public categorialistview ()
		{
			TreeViewHelper treeViewHelper = new TreeViewHelper(TreeView, AppDomain.Instance.DbConnection, "select id, nombre from categoria");
			
			Gtk.Action refreshAction = new Gtk.Action("refreshAction",null,null, Stock.Refresh);
			refreshAction.Activated += delegate {
				treeViewHelper.Refresh();
			};
			actionGroup.Add (refreshAction);
		}
	}
}

