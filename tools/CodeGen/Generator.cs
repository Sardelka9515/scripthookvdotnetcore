namespace CodeGen
{
    abstract class Generator
    {
        public abstract string FileName { get; }

        public virtual bool NeedFormatting => false;
        public abstract string Generate(NativeData nativeData,GenOptions options);
    }
}
