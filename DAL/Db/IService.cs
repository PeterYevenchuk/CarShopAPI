using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Db;

public interface IService<T>
{
    List<T> Get();
    T? GetById(Guid id);
    bool Insert(T entity);
    bool Update(T entity);
    bool Delete(Guid id);
}
