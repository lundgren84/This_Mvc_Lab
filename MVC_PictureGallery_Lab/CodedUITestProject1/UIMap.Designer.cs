﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 14.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace CodedUITestProject1
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// logginAnd add ALbum
        /// </summary>
        public void RecordedMethod1()
        {
            #region Variable Declarations
            WinEdit uIAdressochsökfältEdit = this.UILocalhostGoogleChromWindow.UIItemGroup.UIAdressochsökfältEdit;
            WinGroup uIItemGroup = this.UILocalhostGoogleChromWindow.UIHuvudToolBar.UIItemGroup;
            WinWindow uIMyASPNETApplicationGWindow1 = this.UIMyASPNETApplicationGWindow.UIMyASPNETApplicationGWindow1;
            WinControl uIChromeLegacyWindowDocument = this.UIMyASPNETApplicationGWindow.UIChromeLegacyWindowWindow.UIChromeLegacyWindowDocument;
            WinWindow uIItemWindow1 = this.UIItemWindow.UIItemWindow1;
            #endregion

            // Move 'Adress- och sökfält' text box to group
            uIItemGroup.EnsureClickable(new Point(292, 27));
            Mouse.StartDragging(uIAdressochsökfältEdit, new Point(322, 23));
            Mouse.StopDragging(uIItemGroup, new Point(292, 27));

            // Click '- My ASP.NET Application - Google Chrome' window
            Mouse.Click(uIMyASPNETApplicationGWindow1, new Point(603, 398));

            // Click '- My ASP.NET Application - Google Chrome' window
            Mouse.Click(uIMyASPNETApplicationGWindow1, new Point(338, 209));

            // Click '- My ASP.NET Application - Google Chrome' window
            Mouse.Click(uIMyASPNETApplicationGWindow1, new Point(550, 321));

            // Type 'pelle111' in 'Chrome Legacy Window' document
            Keyboard.SendKeys(uIChromeLegacyWindowDocument, this.RecordedMethod1Params.UIChromeLegacyWindowDocumentSendKeys, ModifierKeys.None);

            // Click '- My ASP.NET Application - Google Chrome' window
            Mouse.Click(uIMyASPNETApplicationGWindow1, new Point(560, 382));

            // Click window
            Mouse.Click(uIItemWindow1, new Point(180, 132));

            // Click '- My ASP.NET Application - Google Chrome' window
            Mouse.Click(uIMyASPNETApplicationGWindow1, new Point(537, 431));
        }
        
        #region Properties
        public virtual RecordedMethod1Params RecordedMethod1Params
        {
            get
            {
                if ((this.mRecordedMethod1Params == null))
                {
                    this.mRecordedMethod1Params = new RecordedMethod1Params();
                }
                return this.mRecordedMethod1Params;
            }
        }
        
        public UILocalhostGoogleChromWindow UILocalhostGoogleChromWindow
        {
            get
            {
                if ((this.mUILocalhostGoogleChromWindow == null))
                {
                    this.mUILocalhostGoogleChromWindow = new UILocalhostGoogleChromWindow();
                }
                return this.mUILocalhostGoogleChromWindow;
            }
        }
        
        public UIMyASPNETApplicationGWindow UIMyASPNETApplicationGWindow
        {
            get
            {
                if ((this.mUIMyASPNETApplicationGWindow == null))
                {
                    this.mUIMyASPNETApplicationGWindow = new UIMyASPNETApplicationGWindow();
                }
                return this.mUIMyASPNETApplicationGWindow;
            }
        }
        
        public UIItemWindow UIItemWindow
        {
            get
            {
                if ((this.mUIItemWindow == null))
                {
                    this.mUIItemWindow = new UIItemWindow();
                }
                return this.mUIItemWindow;
            }
        }
        #endregion
        
        #region Fields
        private RecordedMethod1Params mRecordedMethod1Params;
        
        private UILocalhostGoogleChromWindow mUILocalhostGoogleChromWindow;
        
        private UIMyASPNETApplicationGWindow mUIMyASPNETApplicationGWindow;
        
        private UIItemWindow mUIItemWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'RecordedMethod1'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class RecordedMethod1Params
    {
        
        #region Fields
        /// <summary>
        /// Type 'pelle111' in 'Chrome Legacy Window' document
        /// </summary>
        public string UIChromeLegacyWindowDocumentSendKeys = "pelle111";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UILocalhostGoogleChromWindow : WinWindow
    {
        
        public UILocalhostGoogleChromWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "localhost - Google Chrome";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "Chrome_WidgetWin_1";
            this.WindowTitles.Add("localhost - Google Chrome");
            #endregion
        }
        
        #region Properties
        public UIItemGroup UIItemGroup
        {
            get
            {
                if ((this.mUIItemGroup == null))
                {
                    this.mUIItemGroup = new UIItemGroup(this);
                }
                return this.mUIItemGroup;
            }
        }
        
        public UIHuvudToolBar UIHuvudToolBar
        {
            get
            {
                if ((this.mUIHuvudToolBar == null))
                {
                    this.mUIHuvudToolBar = new UIHuvudToolBar(this);
                }
                return this.mUIHuvudToolBar;
            }
        }
        #endregion
        
        #region Fields
        private UIItemGroup mUIItemGroup;
        
        private UIHuvudToolBar mUIHuvudToolBar;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIItemGroup : WinGroup
    {
        
        public UIItemGroup(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("localhost - Google Chrome");
            #endregion
        }
        
        #region Properties
        public WinEdit UIAdressochsökfältEdit
        {
            get
            {
                if ((this.mUIAdressochsökfältEdit == null))
                {
                    this.mUIAdressochsökfältEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIAdressochsökfältEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Adress- och sökfält";
                    this.mUIAdressochsökfältEdit.WindowTitles.Add("localhost - Google Chrome");
                    #endregion
                }
                return this.mUIAdressochsökfältEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUIAdressochsökfältEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIHuvudToolBar : WinToolBar
    {
        
        public UIHuvudToolBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinToolBar.PropertyNames.Name] = "huvud";
            this.WindowTitles.Add("localhost - Google Chrome");
            #endregion
        }
        
        #region Properties
        public WinGroup UIItemGroup
        {
            get
            {
                if ((this.mUIItemGroup == null))
                {
                    this.mUIItemGroup = new WinGroup(this);
                    #region Search Criteria
                    this.mUIItemGroup.WindowTitles.Add("localhost - Google Chrome");
                    #endregion
                }
                return this.mUIItemGroup;
            }
        }
        #endregion
        
        #region Fields
        private WinGroup mUIItemGroup;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIMyASPNETApplicationGWindow : WinWindow
    {
        
        public UIMyASPNETApplicationGWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "- My ASP.NET Application - Google Chrome";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "Chrome_WidgetWin_1";
            this.WindowTitles.Add("- My ASP.NET Application - Google Chrome");
            #endregion
        }
        
        #region Properties
        public WinWindow UIMyASPNETApplicationGWindow1
        {
            get
            {
                if ((this.mUIMyASPNETApplicationGWindow1 == null))
                {
                    this.mUIMyASPNETApplicationGWindow1 = new WinWindow(this);
                    #region Search Criteria
                    this.mUIMyASPNETApplicationGWindow1.SearchProperties[WinWindow.PropertyNames.Name] = "- My ASP.NET Application";
                    this.mUIMyASPNETApplicationGWindow1.WindowTitles.Add("- My ASP.NET Application - Google Chrome");
                    #endregion
                }
                return this.mUIMyASPNETApplicationGWindow1;
            }
        }
        
        public UIChromeLegacyWindowWindow UIChromeLegacyWindowWindow
        {
            get
            {
                if ((this.mUIChromeLegacyWindowWindow == null))
                {
                    this.mUIChromeLegacyWindowWindow = new UIChromeLegacyWindowWindow(this);
                }
                return this.mUIChromeLegacyWindowWindow;
            }
        }
        #endregion
        
        #region Fields
        private WinWindow mUIMyASPNETApplicationGWindow1;
        
        private UIChromeLegacyWindowWindow mUIChromeLegacyWindowWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIChromeLegacyWindowWindow : WinWindow
    {
        
        public UIChromeLegacyWindowWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "222810256";
            this.WindowTitles.Add("- My ASP.NET Application - Google Chrome");
            #endregion
        }
        
        #region Properties
        public WinControl UIChromeLegacyWindowDocument
        {
            get
            {
                if ((this.mUIChromeLegacyWindowDocument == null))
                {
                    this.mUIChromeLegacyWindowDocument = new WinControl(this);
                    #region Search Criteria
                    this.mUIChromeLegacyWindowDocument.SearchProperties[UITestControl.PropertyNames.ControlType] = "Document";
                    this.mUIChromeLegacyWindowDocument.WindowTitles.Add("- My ASP.NET Application - Google Chrome");
                    #endregion
                }
                return this.mUIChromeLegacyWindowDocument;
            }
        }
        #endregion
        
        #region Fields
        private WinControl mUIChromeLegacyWindowDocument;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIItemWindow : WinWindow
    {
        
        public UIItemWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.AccessibleName] = "Skrivbord";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32769";
            #endregion
        }
        
        #region Properties
        public WinWindow UIItemWindow1
        {
            get
            {
                if ((this.mUIItemWindow1 == null))
                {
                    this.mUIItemWindow1 = new WinWindow(this);
                }
                return this.mUIItemWindow1;
            }
        }
        #endregion
        
        #region Fields
        private WinWindow mUIItemWindow1;
        #endregion
    }
}
