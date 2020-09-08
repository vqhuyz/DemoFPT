using OracleFPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleFPT.DI.Interface
{
    public interface IDapperRepository
    {
        List<Employees> GetAll();
        void Create(Employees employees);
        void Update(Employees employees);
        void Delete(int id);
        Employees GetById(int id);
    }
}
