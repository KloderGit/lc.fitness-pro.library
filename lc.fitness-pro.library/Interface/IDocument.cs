namespace lc.fitnesspro.library.Interface
{
    public interface IDocument
    {
        //ICollection<IRegisterUnit> Registry { get; }

        void AddRegisterUnit(IRegisterUnit item);
        void RemoveRegisterUnit(IRegisterUnit item);
    }
}
