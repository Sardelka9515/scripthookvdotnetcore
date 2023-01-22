//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

namespace GTA
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ScriptAttributes : Attribute
    {
        public string Author;
        public string SupportURL;

        /// <summary>
        /// Set this to true to prevent a default instances from being created and registered during module init
        /// </summary>
        public bool NoDefaultInstance = false;

        /// <summary>
        /// Disallow multiple instance of the script object with same type to be registered, default is true
        /// </summary>
        public bool SingleInstance = true;
    }
}