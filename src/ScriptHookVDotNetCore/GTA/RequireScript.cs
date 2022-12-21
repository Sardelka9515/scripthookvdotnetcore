//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

namespace GTA
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RequireScript : Attribute
    {
        public RequireScript(Type dependency)
        {
        }
    }
}