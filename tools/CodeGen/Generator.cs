using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen
{
    abstract class Generator
    {
        public abstract string FileName { get; }

        public virtual bool NeedFormatting => false;
        public abstract string Generate(NativeData nativeData,GenOptions options);
    }
}
