using System;
namespace lc.fitnesspro.library.Interface
{
    public interface IAccount
    {
        string GetLogin();
        string GetPassword();
        string GetEndPoint(Type key);
    }
}
