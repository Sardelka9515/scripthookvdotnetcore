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
        public bool NoDefaultInstance;
    }
}