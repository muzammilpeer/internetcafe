﻿

#pragma checksum "C:\Users\MuzammilPeer\documents\visual studio 2012\Projects\InternetCafeApp\InternetCafeApp\View\AddPayment.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6AA7C7CFC566409DC4EA912C9FAF5741"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternetCafeApp.View
{
    partial class AddPayment : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 74 "..\..\View\AddPayment.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnSave_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 75 "..\..\View\AddPayment.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnCancel_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 80 "..\..\View\AddPayment.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.comboBoxRooms_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 37 "..\..\View\AddPayment.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


