
using Hotel.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreateAsync(TEntity obj);

    public Task<int> UpdateAsync(long id , TEntity obj);

    public Task<int> DeleteAsync(long id);

    public Task<IList<TViewModel>> GetAllAsync(PagenationParams @params);

    public Task<IList<TViewModel>> GetAllAsync(long id);

}
