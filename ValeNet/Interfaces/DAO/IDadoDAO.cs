using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeNet.Models;

namespace ValeNet.Interfaces.DAO
{
    public interface IDadoDAO
    {
        Task<List<Dado>> GetAllAsync();
        Task<Dado> GetIdAsync(int Id);
        Task<List<Dado>> GetGuidAsync(string Guid);
        Task<Dado> InsertAsync(Dado dado);
        Task<List<Dado>> InsertListAsync(List<Dado> dados, string FilePath);
        Task<Dado> EditAsync(Dado dado);
        Task<Boolean> DelAsync(int Id);
    }
}
