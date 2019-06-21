using DataAccess.Models;
using System.Collections.Generic;

namespace Common.Repository
{
    public interface ILoginRepository
    {
        Employee GetLogin(string email, string password);
        Employee Get(int id);

        List<Employee> Get();
    }


}
