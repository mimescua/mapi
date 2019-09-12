using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            _dbContext.SFI_GEOUNIDADT.Add(unidadT);
            await _dbContext.SaveChangesAsync();

            UnidadT _unidadt = new UnidadT()
            {
                Id = unidadT.Id,
                Type = unidadT.Type,
                Coordinates = JsonConvert.DeserializeObject<List<List<List<double>>>>(unidadT.CoordinateString),
                Nombre = unidadT.Nombre
            };
            return _unidadt;
        }
    }
}