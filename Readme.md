<!-- default file list -->
*Files to look at*:

* [WebShowCustomFormWindowController.cs](./CS/E911.Module.Web/Controllers/WebShowCustomFormWindowController.cs) (VB: [WebShowCustomFormWindowController.vb](./VB/E911.Module.Web/Controllers/WebShowCustomFormWindowController.vb))
* [WebCustomUserControlViewItem.cs](./CS/E911.Module.Web/Editors/WebCustomUserControlViewItem.cs) (VB: [WebCustomUserControlViewItem.vb](./VB/E911.Module.Web/Editors/WebCustomUserControlViewItem.vb))
* [WebModuleEx.cs](./CS/E911.Module.Web/WebModuleEx.cs) (VB: [WebModuleEx.vb](./VB/E911.Module.Web/WebModuleEx.vb))
* [WinShowCustomFormWindowController.cs](./CS/E911.Module.Win/Controllers/WinShowCustomFormWindowController.cs) (VB: [WinShowCustomFormWindowController.vb](./VB/E911.Module.Win/Controllers/WinShowCustomFormWindowController.vb))
* [WinCustomUserControlViewItem.cs](./CS/E911.Module.Win/Editors/WinCustomUserControlViewItem.cs) (VB: [WinCustomUserControlViewItem.vb](./VB/E911.Module.Win/Editors/WinCustomUserControlViewItem.vb))
* [WinModuleEx.cs](./CS/E911.Module.Win/WinModuleEx.cs) (VB: [WinModuleEx.vb](./VB/E911.Module.Win/WinModuleEx.vb))
* **[ShowCustomFormWindowController.cs](./CS/E911.Module/Controllers/ShowCustomFormWindowController.cs) (VB: [ShowCustomFormWindowController.vb](./VB/E911.Module/Controllers/ShowCustomFormWindowController.vb))**
* [CustomUserControlViewItem.cs](./CS/E911.Module/Editors/CustomUserControlViewItem.cs) (VB: [CustomUserControlViewItem.vb](./VB/E911.Module/Editors/CustomUserControlViewItem.vb))
* [Model.DesignedDiffs.xafml](./CS/E911.Module/Model.DesignedDiffs.xafml) (VB: [Model.DesignedDiffs.xafml](./VB/E911.Module/Model.DesignedDiffs.xafml))
* [WebCustomForm.aspx.cs](./CS/E911.Web/Controls/WebCustomForm.aspx.cs) (VB: [WebCustomForm.aspx.vb](./VB/E911.Web/Controls/WebCustomForm.aspx.vb))
* [WebCustomUserControl.ascx.cs](./CS/E911.Web/Controls/WebCustomUserControl.ascx.cs) (VB: [WebCustomUserControl.ascx.vb](./VB/E911.Web/Controls/WebCustomUserControl.ascx.vb))
* [Model.xafml](./CS/E911.Web/Model.xafml) (VB: [Model.xafml](./VB/E911.Web/Model.xafml))
* [WinCustomForm.cs](./CS/E911.Win/Controls/WinCustomForm.cs) (VB: [WinCustomForm.vb](./VB/E911.Win/Controls/WinCustomForm.vb))
* [WinCustomUserControl.cs](./CS/E911.Win/Controls/WinCustomUserControl.cs) (VB: [WinCustomUserControl.vb](./VB/E911.Win/Controls/WinCustomUserControl.vb))
* [Model.xafml](./CS/E911.Win/Model.xafml) (VB: [Model.xafml](./VB/E911.Win/Model.xafml))
<!-- default file list end -->
# OBSOLETE - How to show custom forms and controls in XAF (Example)


<p><strong>==============================</strong><br /><strong>This article is now obsolete. Instead, refer to the <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112670.aspx">eXpressApp Framework</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112683.aspx">Concepts</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112638.aspx">UI Construction</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113610.aspx">Using a Custom Control that is not Integrated by Default</a> overview article and the following two help topics in particular:</strong><br /><strong>    <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112670.aspx">eXpressApp Framework</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112682.aspx">Task-Based Help</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument114159.aspx">How to: Show a Custom Data-Bound Control in an XAF View (WinForms)</a> </strong><br /><strong>    <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112670.aspx">eXpressApp Framework</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112682.aspx">Task-Based Help</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument114160.aspx">How to: Show a Custom Data-Bound Control in an XAF View (ASP.NET)</a> </strong><br /><strong>==============================</strong><br />This example implements the following scenarios when an end-user clicks on a custom item in the navigation control:</p>
<p>- a custom non-XAF form is opened as a result;</p>
<p>- a standard XAF View containing a custom user control is opened as a result.</p>
<p><br /> <img src="https://raw.githubusercontent.com/DevExpress-Examples/obsolete-how-to-show-custom-forms-and-controls-in-xaf-example-e911/13.1.4+/media/0360bd9e-0393-4462-8898-c67f1918bc2a.png"></p>
<p>Both custom forms and user controls display persistent data from the XAF application database. For that purpose, this example solution provides a set of reusable elements (custom ViewItem and Application Model extensions) organized in a way that you can once implement them in an XAF module and reuse to display custom user controls in various forms.</p>
<p><br /><strong>IMPORTANT NOTES</strong><br />If you do not require a complex and reusable solution for this task, it is recommended to use a much simpler and built-in XAF solution - <u><a href="http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppLayoutControlDetailItemtopic">ControlDetailItem</a> </u>placed within a <a href="http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppDashboardViewtopic"><u>DashboardView</u></a>. This item can be added and customized as described at <a href="https://documentation.devexpress.com/#Xaf/CustomDocument3652">eXpressApp Framework > Task-Based Help > How to: Create a Custom Control Detail Item</a>. See also the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3610">Using a Control that is not Integrated by Default</a> article for other integration options.</p>
<p>If this is NOT your case, proceed to the instructions below.<br /><br /><strong>STEPS TO IMPLEMENT</strong><br /> <strong><br /> 1.</strong> Define a base <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3198"><u>structure of the navigation control</u></a> in your XAF application, as shown in the <em>E911.Module\Model.DesignedDiffs.xafml</em> file.</p>
<p>You can simply copy and paste the contents of the <em>NavigationItems </em>element into the corresponding file (pre-opened via the text editor) of your platform-agnostic module.</p>
<p>The same customizations can be achieved via the Model Editor visually. <br />Take special note that you can <strong>set the View parameter to any View</strong> from the list, e.g. <em>AboutInfo_DetailView, BaseObject_ListView</em>, etc.</p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/obsolete-how-to-show-custom-forms-and-controls-in-xaf-example-e911/13.1.4+/media/3ef163ca-c7e5-4783-ab25-78fa5d405f75.png"></p>
<p>This navigation structure will be further customized in the WinForms and ASP.NET executable projects later.</p>
<br />
<p><strong>2.</strong> Intercept events of the navigation control to display a custom form when a custom navigation item is clicked.</p>
<p>To do this, implement a WindowController into your platform-agnostic module and handle events of the <a href="http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppSystemModuleShowNavigationItemControllertopic"><u>ShowNavigationItemController</u></a> class as per the <em>E911.Module\Controllers\ShowCustomFormWindowController.xx</em> file. This controller will be abstract and be overridden in WinForms and ASP.NET modules.</p>
<br />
<p><strong>3.</strong> Declare a <a href="http://documentation.devexpress.com/#Xaf/CustomDocument2695"><u>custom ViewItem class</u></a> that is supposed to host a custom user control in the standard XAF View. To do this, implement a custom ViewItem descendant and related types in the platform-agnostic module as shown in the <em>E911.Module\Editors\CustomUserControlViewItem.xx </em>file.</p>
<p>This ViewItem will also be abstract and platform-agnostic as it will not create platform-dependent controls, and will just provide a common customization code for both platforms. For instance, the <em>OnControlCreated</em> method will be overridden to bind the created control to data. To access persistent data from the database used by an XAF application, the ViewItem will implement the <em>IComplexViewItem</em> interface that consists of a single <em>Setup</em> method, receiving the <em>IObjectSpace</em> and <em>XafApplication</em> objects as parameters.</p>
<p>To unify our data binding code for both platforms, the <em>IXpoSessionAwareControl</em> interface and an auxiliary <em>XpoSessionAwareControlInitializer</em> class are introduced.</p>
<p>The interface provides a single <em>UpdateDataSource</em> method that is implemented by custom forms and user controls to bind them to data received by means of XPO.</p>
<p>You can use a similar mechanism and modify these auxiliary types to pass other custom data into your custom forms and controls.</p>
<br />
<p><strong>4.</strong> Define a base <a href="http://documentation.devexpress.com/#Xaf/CustomDocument2612"><u>structure of the standard XAF View</u></a> with a custom ViewItem as shown in the <em>E911.Module\Model.DesignedDiffs.xafml</em> file.</p>
<p>You can simply copy and paste the contents of the <em>Views</em> element into the corresponding file (pre-opened via the text editor) of your platform-agnostic module.</p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/obsolete-how-to-show-custom-forms-and-controls-in-xaf-example-e911/13.1.4+/media/e50a660c-a14b-44cc-8199-6fce62e89e90.png"></p>
<br />
<p><strong>5.</strong> Create custom forms and user controls in WinForms and ASP.NET executable projects analogous with what is shown in the example. The easiest way to do this is to copy the contents of the <em>E911.Win\Controls </em>and <em>E911.Web\Controls</em> folders and then include the necessary files into your solution. Take special note that these custom forms and controls implement the <em>IXpoSessionAwareControl</em> interface to automatically receive persistent data and other parameters when they are created.</p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/obsolete-how-to-show-custom-forms-and-controls-in-xaf-example-e911/13.1.4+/media/cd4756c0-dca8-4b20-9fb0-f97cd52d860f.png"></p>
<br />
<p><strong>6.</strong> Implement platform-dependent behavior to open and customize custom forms and controls. To do this, copy the following files into your WinForms and ASP.NET module projects:</p>
<p><u>WinForms</u>:</p>
<p><em>E911.Module.Win\Controllers\WinShowCustomFormWindowController.xx</em> - contains an WinForms version of the WindowController, which is inherited from the platform-agnostic</p>
<p><em>E911.Module.Win\Editors\WinCustomUserControlViewItem.xx</em> - contains an WinForms version of the ViewItem, which is inherited from the platform-agnostic one;</p>
<p><em>E911.Module.Win\WinModuleEx.xx</em> - contains a registration code for WinForms version of the ViewItem;</p>
<p><u><br /> </u><u>ASP.NET</u>:</p>
<p><em>E911.Module.Web\Editors\WebCustomUserControlViewItem.xx</em> - contains an ASP.NET version of the ViewItem, which is inherited from the platform-agnostic one;</p>
<p><em>E911.Module.Web\WebModuleEx.xx</em> - contains a registration code for ASP.NET version of the ViewItem;</p>
<p><em>E911.Module.Web\Controllers\WebShowCustomFormWindowController.xx</em> - contains an ASP.NET version of the WindowController, which is inherited from the platform-agnostic one;</p>
<br />
<p>These platform-dependent versions of the WindowController and ViewItem are required to implement the creation and display of custom forms and controls using the means specific for each platform. They are also designed to provide the capability to be able to set custom forms and control settings via the Model Editor. For that purpose, custom Application Model extensions are implemented for the Navigation Item and View Item model elements.</p>
<br />
<p><strong>7.</strong> Set the custom forms and controls settings for each platform.</p>
<p>To do this, copy the contents of the <em>E911.Win\Model.xafml</em> and <em>E911.Web\Model.xafml</em> files into the <em>Model.xafml</em> file in the executable WinForms and ASP.NET projects:</p>
<p><u>WinForms:</u></p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/obsolete-how-to-show-custom-forms-and-controls-in-xaf-example-e911/13.1.4+/media/67bfcb89-6e06-459d-b0b1-72d665584440.png"></p>
<p><u>ASP.NET:<br /> </u><br /> <img src="https://raw.githubusercontent.com/DevExpress-Examples/obsolete-how-to-show-custom-forms-and-controls-in-xaf-example-e911/13.1.4+/media/9aeb94b4-a311-4c29-8f2b-b78dd8d5f7a8.png"></p>
<p> </p>
<p><strong>OTHER IMPLEMENTATION CONSIDERATIONS</strong></p>
<p><strong>1.</strong> It is also possible to mix the traditional and XAF development approaches (consult our Support Team if you are not sure how to integrate your standard non-XAF solution into XAF), because an XAF application is a regular .NET application <a href="http://documentation.devexpress.com/#Xaf/CustomDocument2638"><u>built of reusable blocks like View, ViewItem, Property and List Editors, etc.</u></a> that eventually create and customize platform-dependent controls exactly the same way you do this without XAF. So, using XAF does not mean something absolutely new and allows you to reuse your existing development skills and practices. Of course, it is possible to create your own reusable blocks if the standard ones do not meet your needs. For instance, the example of a custom View class designed to show a custom form can be <a href="http://www.codeproject.com/Tips/464188/How-to-Show-Usual-Winform-as-View-in-XAF"><u>found on CodeProject here</u></a>.</p>
<br />
<p><strong>2.</strong> This solution contains some generic code (e.g., base WindowController and ViewItem) that is mainly required because our XAF application is for both Windows and the Web. You may avoid this generic code and make a simpler implementation if you are developing for only one platform.</p>
<br />
<p><strong>3.</strong> You can display custom forms not only when interacting with the navigation control, but from any other place. To do this, intercept the events of a required entity, e.g., an XAF Controller, Action or a View. Refer to the product documentation or consult with our Support Team in case of any difficulties.</p>
<br />
<p><strong>4.</strong> By default controls layout and user customizations are preserved only for built-in XAF ListEditors, because they have special code for that. If you embed a custom user control into XAF, you need to preserve its settings yourself as well, exactly like you would do when implementing this task in the "old way" in a non-XAF application. Refer to the control's documentation to learn more on how to accomplish this task.</p>
<p>Feel free to contact the respective product team if you experience any difficulties customizing this control.</p>
<p><strong><br />See also:<br /></strong><a href="https://www.devexpress.com/Support/Center/p/KA18606">How to create controls dynamically</a><br /> <a href="https://www.devexpress.com/Support/Center/p/K18118">How much of XAF's default UI is customizable.</a><br /> <a href="https://www.devexpress.com/Support/Center/p/E244">How to Show a Window via an Action</a><br /> <a href="https://www.devexpress.com/Support/Center/p/E980">How to: Display a List of Non-Persistent Objects</a><br /> <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3471"><u>How to: Display a Non-Persistent Object's Detail View from the Navigation</u></a><br /> <a href="http://documentation.devexpress.com/#Xaf/DevExpressExpressAppSystemModuleShowNavigationItemController_CustomShowNavigationItemtopic"><u>ShowNavigationItemController.CustomShowNavigationItem Event</u></a><br /> <a href="http://documentation.devexpress.com/#Xaf/DevExpressExpressAppXafApplication_CustomProcessShortcuttopic"><u>XafApplication.CustomProcessShortcut Event</u></a></p>

<br/>


