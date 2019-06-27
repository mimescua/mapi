using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReadRepository
    {
        private readonly OracleDbContext _dbContext;
        private readonly SecurityDbContext _secContext;
        public ReadRepository(OracleDbContext dbContext, SecurityDbContext secContext)
        {
            _dbContext = dbContext;
            _secContext = secContext;
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

        //Retrieving batch type collection AS LIST TYPE by id
        public async Task<IDictionary<int, Lote>> GetSomeLotesByIdAsync(IEnumerable<int> loteIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOLOTE.Where(i => loteIds.Contains(i.Id)).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, Calle>> GetSomeCallessByIdAsync(IEnumerable<int> calleIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOCALLE.Where(i => calleIds.Contains(i.Id)).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, Manzana>> GetSomeManzanassByIdAsync(IEnumerable<int> manzanaIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOMANZANA.Where(i => manzanaIds.Contains(i.Id)).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, Parcela>> GetSomeParcelasByIdAsync(IEnumerable<int> parcelaIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOPARCELA.Where(i => parcelaIds.Contains(i.Id)).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, Pueblo>> GetSomePueblosByIdAsync(IEnumerable<int> puebloIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOPUEBLO.Where(i => puebloIds.Contains(i.Id)).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, UnidadT>> GetSomeUnidaTsByIdAsync(IEnumerable<int> unidadtIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOUNIDADT.Where(i => unidadtIds.Contains(i.Id)).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }

        //Retrieving batch type collection AS LIST(inside array) by id
        public async Task<ILookup<int, Lote>> GetForFeatures(IEnumerable<int> featureIds)
        {
            var lotes = await _dbContext.SFI_GEOLOTE.Where(
            lt => featureIds.Contains(lt.Id))
            .ToListAsync();
            return lotes.ToLookup(t => t.Id);
        }

        //Retrieving a SINGLE type by id
        public async Task<Lote> GetLoteGeomById(int id)
        {
            var result = _dbContext.SFI_GEOLOTE.Where(t => t.Id == id)
                .Select(t => new Lote { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Lote> GetLotePropsById(int id)
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
        public async Task<Calle> GetCalleGeomById(int id)
        {
            var result = _dbContext.SFI_GEOCALLE.Where(t => t.Id == id)
                .Select(t => new Calle { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Calle> GetCallePropsById(int id)
        {
            var result = _dbContext.SFI_GEOCALLE.Where(t => t.Id == id)
                .Select(t => new Calle
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Manzana> GetManzanaGeomById(int id)
        {
            var result = _dbContext.SFI_GEOMANZANA.Where(t => t.Id == id)
                .Select(t => new Manzana { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Manzana> GetManzanaPropsById(int id)
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
        public async Task<Parcela> GetParcelaGeomById(int id)
        {
            var result = _dbContext.SFI_GEOPARCELA.Where(t => t.Id == id)
                .Select(t => new Parcela { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Parcela> GetParcelaPropsById(int id)
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
        public async Task<Pueblo> GetPuebloGeomById(int id)
        {
            var result = _dbContext.SFI_GEOPUEBLO.Where(t => t.Id == id)
                .Select(t => new Pueblo { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Pueblo> GetPuebloPropsById(int id)
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
        public async Task<UnidadT> GetUnidadTGeomById(int id)
        {
            var result = _dbContext.SFI_GEOUNIDADT.Where(t => t.Id == id)
                .Select(t => new UnidadT { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<UnidadT> GetUnidadTPropsById(int id)
        {
            var result = _dbContext.SFI_GEOUNIDADT.Where(t => t.Id == id)
                .Select(t => new UnidadT
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                }).SingleOrDefaultAsync();
            return await result;
        }

        public Task<List<Formalizacion>> GetPuebloExistenteByUbigeo(string codpueblo)
        {
            return _dbContext.SFI_PUEBLOEXISTENTE.Where(t => t.Estado == 1).Where(t => t.Tipo == 1).Where(t => EF.Functions.Like(t.Id.ToString(), codpueblo + "%")).ToListAsync();
        }
        public Task<List<Centroide>> GetCentroidesByUbigeo(string centroide)
        {
            //return _secContext.SFI_CENTROIDE.Where(t => t.Id == id).ToListAsync();
            return _secContext.SFI_CENTROIDE.Where(t => EF.Functions.Like(t.Distrito.ToUpper(), centroide.ToUpper() + "%")).ToListAsync();
        }
    }
}