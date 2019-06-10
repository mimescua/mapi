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
        //public Task<List<FeatureCollection>> GetFeatureCollection()
        //{
        //    return _dbContext.FEATURECOLLECTION.ToListAsync();
        //}
        public async Task<FeatureCollection> GetFeatureCollection(string tipo)
        {
            //return _dbContext.FEATURECOLLECTION.SingleOrDefault();
            //FeatureCollection collection = _dbContext.FEATURECOLLECTION.SingleOrDefault();
            FeatureCollection collection;
            switch (tipo.ToLower())
            {
                case "calle": collection = new FeatureCollection { Id = 1, Name = tipo, Type = "FeatureCollection" }; break;
                case "lote": collection = new FeatureCollection { Id = 2, Name = tipo, Type = "FeatureCollection" }; break;
                case "manzana": collection = new FeatureCollection { Id = 3, Name = tipo, Type = "FeatureCollection" }; break;
                case "parcela": collection = new FeatureCollection { Id = 4, Name = tipo, Type = "FeatureCollection" }; break;
                case "pueblo": collection = new FeatureCollection { Id = 5, Name = tipo, Type = "FeatureCollection" }; break;
                case "unidadt": collection = new FeatureCollection { Id = 6, Name = tipo, Type = "FeatureCollection" }; break;
                default: collection = new FeatureCollection { Id = 0, Name = tipo, Type = "FeatureCollection" }; break;
            }
            
            return collection;
        }
        //public async Task<ILookup<int, Features>> GetFeaturesForCollection(IEnumerable<int> id)
        //{
        //    var result = await _dbContext.SFI_GEOFEATURES.Where(t => id.Contains(t.FeatureCollectionId)).ToListAsync();
        //    return result.ToLookup(t => t.FeatureCollectionId);
        //}
        //public async Task<ILookup<int, Features>> GetFeaturesForCollection(IEnumerable<int> id)
        public async Task<ILookup<int, Features>> GetFeaturesForCollection(IEnumerable<int> tipo)
        {
            var contadorRegistros = 0;
            switch (tipo.ElementAt(0))
            {
                case 1: contadorRegistros = _dbContext.SFI_GEOCALLES.Count(); break;
                case 2: contadorRegistros = _dbContext.SFI_GEOLOTES.Count(); break;
                case 3: contadorRegistros = _dbContext.SFI_GEOMANZANAS.Count(); break;
                case 4: contadorRegistros = _dbContext.SFI_GEOPARCELAS.Count(); break;
                case 5: contadorRegistros = _dbContext.SFI_GEOPUEBLOS.Count(); break;
                case 6: contadorRegistros = _dbContext.SFI_GEOUNIDADTS.Count(); break;
                default: contadorRegistros = 1; break;
            }

            var result = new List<Features>(contadorRegistros);
            for (int i = 0; i < contadorRegistros; i++)
            {
                result.Add(new Features { Id = i + 1, Type = "Feature", FeatureCollectionId = tipo.ElementAt(0) });
            }
            return result.ToLookup(t => t.FeatureCollectionId);
        }
        public async Task<Lote> GetAllLoteGeom(int id)
        {
            var result = _dbContext.SFI_GEOLOTES.Where(t => t.Id == id)
                .Select(t => new Lote { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Lote> GetLoteGeomByUbigeo(int id, string ubigeo)
        {
            var result = _dbContext.SFI_GEOLOTES.Where(t => t.Id == id).Where(t => t.Ubigeo == ubigeo)
                .Select(t => new Lote { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Lote> GetAllLoteProps(int id)
        {
            var result = _dbContext.SFI_GEOLOTES.Where(t => t.Id == id)
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
        public async Task<Lote> GetLotePropsByUbigeo(int id, string ubigeo)
        {
            var result = _dbContext.SFI_GEOLOTES.Where(t => t.Id == id).Where(t => t.Ubigeo == ubigeo)
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
            var result = _dbContext.SFI_GEOCALLES.Where(t => t.Id == id)
                .Select(t => new Calle { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Calle> GetAllCalleProps(int id)
        {
            var result = _dbContext.SFI_GEOCALLES.Where(t => t.Id == id)
                .Select(t => new Calle
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Manzana> GetAllManzanaGeom(int id)
        {
            var result = _dbContext.SFI_GEOMANZANAS.Where(t => t.Id == id)
                .Select(t => new Manzana { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Manzana> GetAllManzanaProps(int id)
        {
            var result = _dbContext.SFI_GEOMANZANAS.Where(t => t.Id == id)
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
            var result = _dbContext.SFI_GEOPARCELAS.Where(t => t.Id == id)
                .Select(t => new Parcela { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Parcela> GetAllParcelaProps(int id)
        {
            var result = _dbContext.SFI_GEOPARCELAS.Where(t => t.Id == id)
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
            var result = _dbContext.SFI_GEOPUEBLOS.Where(t => t.Id == id)
                .Select(t => new Pueblo { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Pueblo> GetAllPuebloProps(int id)
        {
            var result = _dbContext.SFI_GEOPUEBLOS.Where(t => t.Id == id)
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
            var result = _dbContext.SFI_GEOUNIDADTS.Where(t => t.Id == id)
                .Select(t => new UnidadT { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<UnidadT> GetAllUnidadTProps(int id)
        {
            var result = _dbContext.SFI_GEOUNIDADTS.Where(t => t.Id == id)
                .Select(t => new UnidadT
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                }).SingleOrDefaultAsync();
            return await result;
        }
    }
}
