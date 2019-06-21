using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface IParameterRepository
    {
        List<Parameter> Get();
        Parameter Get(int id);
        bool Insert(ParameterVM ParameterVM);
        bool Update(int id, ParameterVM ParameterVM);
        bool Delete(int id);
    }
}
