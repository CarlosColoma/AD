using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		UiManMagerHelper uiManagerHelper = new UiManagerHelper(UIManager);
		
		categorialistview categoriaListView = new categorialistview();
		
		notebook.AppendPage (categoriaListView, new Label ("Categorias"));
                
        uiManagerHelper.SetActionGroup(categoriaListView.ActionGroup);
                
        notebook.SwitchPage += delegate {
            IEntityListView entityListView = (IEntityListView) notebook.CurrentPageWidget;
            uiManagerHelper.SetActionGroup(entityListView.ActionGroup);
                
                
                
                
                };
	
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
