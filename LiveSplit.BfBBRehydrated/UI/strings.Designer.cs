﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveSplit.BfBBRehydrated.UI {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LiveSplit.BfBBRehydrated.UI.strings", typeof(strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LiveSplit | BFBB Rehydrated.
        /// </summary>
        internal static string Component_Caption {
            get {
                return ResourceManager.GetString("Component_Caption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This game uses Time without Loads (Game Time) as the main timing method.
        ///LiveSplit is currently set to show Real Time (RTA).
        ///Would you like to set the timing method to Game Time?.
        /// </summary>
        internal static string GameTime_Warning {
            get {
                return ResourceManager.GetString("GameTime_Warning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The autosplitter has been updated, would you like to have your settings converted?.
        /// </summary>
        internal static string Settings_Conversion {
            get {
                return ResourceManager.GetString("Settings_Conversion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The conversion process has completed. You may want to check your settings to make sure everything is still correct.
        ///
        ///If you previously used the delay split option, you will need to manually setup Level Transition splits to achieve the same behavior.
        ///
        ///If you previously used a mixture of manual and automatic splits you will need to manually reorder your split settings..
        /// </summary>
        internal static string Settings_Conversion_Completed {
            get {
                return ResourceManager.GetString("Settings_Conversion_Completed", resourceCulture);
            }
        }
    }
}
