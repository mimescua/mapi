using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AddRepository
    {
        private readonly OracleDbContext _dbContext;
        public AddRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UnidadT> AddUnidadT(UnidadT unidadT)
        {
            _dbContext.SFI_GEOUNIDADTS.Add(unidadT);
            await _dbContext.SaveChangesAsync();
            return unidadT;
        }
    }
}