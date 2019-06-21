using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GeoRepository
    {
        private readonly OracleDbContext _dbContext;
        public GeoRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Features>> GetFeaturesBy(string tipo, string nombre, string ubigeo)
        {
            var ids = new int[] { };
            if (tipo != "" && nombre != "" && ubigeo != "")
            {
                switch (tipo.ToLower())
                {
                    case "calle": ids = _dbContext.SFI_GEOCALLE.AsQueryable().Where(r => r.Nombre == nombre).Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    case "lote": ids = _dbContext.SFI_GEOLOTE.AsQueryable().Where(r => r.Nombre == nombre).Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); ; break;
                    case "manzana": ids = _dbContext.SFI_GEOMANZANA.AsQueryable().Where(r => r.Nombre == nombre).Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    case "parcela": ids = _dbContext.SFI_GEOPARCELA.AsQueryable().Where(r => r.Nombre == nombre).Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    case "pueblo": ids = _dbContext.SFI_GEOPUEBLO.AsQueryable().Where(r => r.Nombre == nombre).Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    case "unidadt": ids = _dbContext.SFI_GEOUNIDADT.AsQueryable().Where(r => r.Nombre == nombre).Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    default: ids = new int[] { 1 }; break;
                }
            }
            else if (tipo != "" && ubigeo != "")
            {
                switch (tipo.ToLower())
                {
                    case "calle": ids = _dbContext.SFI_GEOCALLE.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    case "lote": ids = _dbContext.SFI_GEOLOTE.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); ; break;
                    case "manzana": ids = _dbContext.SFI_GEOMANZANA.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    case "parcela": ids = _dbContext.SFI_GEOPARCELA.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    case "pueblo": ids = _dbContext.SFI_GEOPUEBLO.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    case "unidadt": ids = _dbContext.SFI_GEOUNIDADT.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).ToArray(); break;
                    default: ids = new int[] { 1 }; break;
                }
            }
            else if (tipo != "" && nombre != "")
            {
                switch (tipo.ToLower())
                {
                    case "calle": ids = _dbContext.SFI_GEOCALLE.AsQueryable().Where(r => r.Nombre == nombre).Select(r => r.Id).ToArray(); break;
                    case "lote": ids = _dbContext.SFI_GEOLOTE.AsQueryable().Where(r => r.Nombre == nombre).Select(r => r.Id).ToArray(); ; break;
                    case "manzana": ids = _dbContext.SFI_GEOMANZANA.AsQueryable().Where(r => r.Nombre == nombre).Select(r => r.Id).ToArray(); break;
                    case "parcela": ids = _dbContext.SFI_GEOPARCELA.AsQueryable().Where(r => r.Nombre == nombre).Select(r => r.Id).ToArray(); break;
                    case "pueblo": ids = _dbContext.SFI_GEOPUEBLO.AsQueryable().Where(r => r.Nombre == nombre).Select(r => r.Id).ToArray(); break;
                    case "unidadt": ids = _dbContext.SFI_GEOUNIDADT.AsQueryable().Where(r => r.Nombre == nombre).Select(r => r.Id).ToArray(); break;
                    default: ids = new int[] { 1 }; break;
                }
            }
            else
            {
                switch (tipo.ToLower())
                {
                    case "calle": ids = _dbContext.SFI_GEOCALLE.AsQueryable().Select(r => r.Id).ToArray(); break;
                    case "lote": ids = _dbContext.SFI_GEOLOTE.AsQueryable().Select(r => r.Id).ToArray(); ; break;
                    case "manzana": ids = _dbContext.SFI_GEOMANZANA.AsQueryable().Select(r => r.Id).ToArray(); break;
                    case "parcela": ids = _dbContext.SFI_GEOPARCELA.AsQueryable().Select(r => r.Id).ToArray(); break;
                    case "pueblo": ids = _dbContext.SFI_GEOPUEBLO.AsQueryable().Select(r => r.Id).ToArray(); break;
                    case "unidadt": ids = _dbContext.SFI_GEOUNIDADT.AsQueryable().Select(r => r.Id).ToArray(); break;
                    default: ids = new int[] { 1 }; break;
                }
            }
            var result = new List<Features>(ids.Length);
            for (int i = 0; i < ids.Length; i++)
            {
                result.Add(new Features { Id = ids[i], Type = "Feature" });
            }
            
            return result.ToList();
        }

        public async Task<Lote> GetAllLoteGeom(int id)
        {
            var result = _dbContext.SFI_GEOLOTE.Where(t => t.Id == id)
                .Select(t => new Lote { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }

        public async Task<Lote> GetAllLoteProps(int id)
        {
            var result = _dbContext.SFI_GEOLOTE.Where(t => t.Id == id)
                .Select(t => new Lote
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                    Area = t.Area,
                    TipoUso = t.TipoUso,
                    MedidFrnt = t.MedidFrnt,
                    MedidIzq = t.MedidIzq,
                    MedidPost = t.MedidPost,
                    MedidDer = t.MedidDer,
                    ColinFrnt = t.ColinFrnt,
                    ColinIzq = t.ColinIzq,
                    ColinPost = t.ColinPost,
                    ColinDer = t.ColinDer,
                }).SingleOrDefaultAsync();
            return await result;
        }

        public async Task<Calle> GetAllCalleGeom(int id)
        {
            var result = _dbContext.SFI_GEOCALLE.Where(t => t.Id == id)
                .Select(t => new Calle { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Calle> GetAllCalleProps(int id)
        {
            var result = _dbContext.SFI_GEOCALLE.Where(t => t.Id == id)
                .Select(t => new Calle
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Manzana> GetAllManzanaGeom(int id)
        {
            var result = _dbContext.SFI_GEOMANZANA.Where(t => t.Id == id)
                .Select(t => new Manzana { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Manzana> GetAllManzanaProps(int id)
        {
            var result = _dbContext.SFI_GEOMANZANA.Where(t => t.Id == id)
                .Select(t => new Manzana
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                    CantLotes = t.CantLotes,
                    Area = t.Area,
                }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Parcela> GetAllParcelaGeom(int id)
        {
            var result = _dbContext.SFI_GEOPARCELA.Where(t => t.Id == id)
                .Select(t => new Parcela { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Parcela> GetAllParcelaProps(int id)
        {
            var result = _dbContext.SFI_GEOPARCELA.Where(t => t.Id == id)
                .Select(t => new Parcela
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                    Area = t.Area,
                }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Pueblo> GetAllPuebloGeom(int id)
        {
            var result = _dbContext.SFI_GEOPUEBLO.Where(t => t.Id == id)
                .Select(t => new Pueblo { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Pueblo> GetAllPuebloProps(int id)
        {
            var result = _dbContext.SFI_GEOPUEBLO.Where(t => t.Id == id)
                .Select(t => new Pueblo
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                    CantParcelas = t.CantParcelas,
                    Area = t.Area,
                    AreaVivienda = t.AreaVivienda,
                    AreaComunal = t.AreaComunal,
                    AreaEducacion = t.AreaEducacion,
                }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<UnidadT> GetAllUnidadTGeom(int id)
        {
            var result = _dbContext.SFI_GEOUNIDADT.Where(t => t.Id == id)
                .Select(t => new UnidadT { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<UnidadT> GetAllUnidadTProps(int id)
        {
            var result = _dbContext.SFI_GEOUNIDADT.Where(t => t.Id == id)
                .Select(t => new UnidadT
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                }).SingleOrDefaultAsync();
            return await result;
        }
    }
}
