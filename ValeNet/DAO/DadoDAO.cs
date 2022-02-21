using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeNet.Data;
using ValeNet.Interfaces.DAO;
using ValeNet.Models;

namespace ValeNet.DAO
{
    public class DadoDAO : BaseDAO<Dado>, IDadoDAO
    {
        private readonly ApplicationDbContext context;

        public DadoDAO(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<bool> DelAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Dado> EditAsync(Dado dado)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dado>> GetAllAsync()
        {
            var dadosDB = await context.Dados.ToListAsync();
            return dadosDB;
        }

        public async Task<List<Dado>> GetGuidAsync(string Guid)
        {
            var dadosDB = await context.Dados.Where(x => x.Guid == Guid).ToListAsync();
            return dadosDB;
        }

        public async Task<List<Dado>> InsertListAsync(List<Dado> dados, string FilePath)
        {
            var vGuid = Guid.NewGuid().ToString();
            List<Dado> DadosRetorno = new List<Dado>();
            Dado DadoTemp;
            try
            {
                foreach (var dado in dados)
                {
                    DadoTemp = new Dado();
                    dado.Guid = vGuid;
                    dado.NomeArquivo = FilePath;
                    DadoTemp = await InsertAsync(dado);
                    if (DadoTemp != null && DadoTemp.Id > 0)
                    {
                        DadosRetorno.Add(DadoTemp);
                    }
                }
            }
            catch (Exception e)
            {
                if (DadosRetorno != null && DadosRetorno.Count <= 0)
                {
                    DadosRetorno = new List<Dado>();
                }
            }
            return DadosRetorno;
        }

        public Task<Dado> GetIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dado> InsertAsync(Dado dado)
        {
            try
            {
                if (dado.Guid.Trim().Length <= 0)
                {
                    dado.Guid = Guid.NewGuid().ToString();
                }
                await context.AddAsync(dado);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                dado = new Dado();
            }
            return dado;
        }
    }
}
