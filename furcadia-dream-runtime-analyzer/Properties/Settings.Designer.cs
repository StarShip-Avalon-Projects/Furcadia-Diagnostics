﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dream_Runtime_Analyzer.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dream Runtime Analyzer")]
        public string PROGRAM_NAME {
            get {
                return ((string)(this["PROGRAM_NAME"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.0.2")]
        public string PROGRAM_VERSION {
            get {
                return ((string)(this["PROGRAM_VERSION"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Artex // IceDragon <icedragon@quickfox.org>")]
        public string PROGRAM_AUTHOR {
            get {
                return ((string)(this["PROGRAM_AUTHOR"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://www.icerealm.org/")]
        public string PROGRAM_URL {
            get {
                return ((string)(this["PROGRAM_URL"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("lightbringer.furcadia.com")]
        public string DEFAULT_FURC_ADDRESS {
            get {
                return ((string)(this["DEFAULT_FURC_ADDRESS"]));
            }
            set {
                this["DEFAULT_FURC_ADDRESS"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6500")]
        public ushort DEFAULT_FURC_PORT {
            get {
                return ((ushort)(this["DEFAULT_FURC_PORT"]));
            }
            set {
                this["DEFAULT_FURC_PORT"] = value;
            }
        }
    }
}
