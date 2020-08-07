using System;
namespace lc.fitness_pro.library.Interface
{
    public interface IAccount
    {
        string GetLogin();
        string GetPassword();
        string GetEndPoint(Type key);
    }
}
