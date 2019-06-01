﻿using Data.Entities;
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
        public async Task<FeatureCollection> GetFeatureCollection()
        {
            //return _dbContext.FEATURECOLLECTION.SingleOrDefault();
            //FeatureCollection collection = _dbContext.FEATURECOLLECTION.SingleOrDefault();
            FeatureCollection collection = new FeatureCollection { Id=1, Type="FeatureCollection"};
            return collection;
        }
        //public async Task<ILookup<int, Features>> GetFeaturesForCollection(IEnumerable<int> _fkeys)
        //{
        //    var reviews = await _dbContext.FEATURES.Where(lt => _fkeys.Contains(lt.fkey)).ToListAsync();
        //    return reviews.ToLookup(t => t.fkey);
        //}
        public async Task<ILookup<int, Features>> GetFeaturesForCollection(IEnumerable<int> id)
        {
            var reviews = await _dbContext.FEATURES.Where(lt => id.Contains(lt.Id)).ToListAsync();
            return reviews.ToLookup(t => t.Id);
        }
        public async Task<Lote> GetAllLoteGeom(int id)
        {
            var result = _dbContext.LOTES.Where(t => t.Id == id)
                .Select(t => new Lote { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Lote> GetLoteGeomByUbigeo(int id, string ubigeo)
        {
            var result = _dbContext.LOTES.Where(t => t.Id == id).Where(t => t.Ubigeo == ubigeo)
                .Select(t => new Lote { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Lote> GetAllLoteProps(int id)
        {
            var result = _dbContext.LOTES.Where(t => t.Id == id)
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
            var result = _dbContext.LOTES.Where(t => t.Id == id).Where(t => t.Ubigeo == ubigeo)
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
            var result = _dbContext.CALLES.Where(t => t.Id == id)
                .Select(t => new Calle { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Calle> GetAllCalleProps(int id)
        {
            var result = _dbContext.CALLES.Where(t => t.Id == id)
                .Select(t => new Calle
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Manzana> GetAllManzanaGeom(int id)
        {
            var result = _dbContext.MANZANAS.Where(t => t.Id == id)
                .Select(t => new Manzana { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Manzana> GetAllManzanaProps(int id)
        {
            var result = _dbContext.MANZANAS.Where(t => t.Id == id)
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
            var result = _dbContext.PARCELAS.Where(t => t.Id == id)
                .Select(t => new Parcela { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Parcela> GetAllParcelaProps(int id)
        {
            var result = _dbContext.PARCELAS.Where(t => t.Id == id)
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
            var result = _dbContext.PUEBLOS.Where(t => t.Id == id)
                .Select(t => new Pueblo { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<Pueblo> GetAllPuebloProps(int id)
        {
            var result = _dbContext.PUEBLOS.Where(t => t.Id == id)
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
            var result = _dbContext.UNIDADTS.Where(t => t.Id == id)
                .Select(t => new UnidadT { Type = t.Type, Coordinates = t.Coordinates }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<UnidadT> GetAllUnidadTProps(int id)
        {
            var result = _dbContext.UNIDADTS.Where(t => t.Id == id)
                .Select(t => new UnidadT
                {
                    Nombre = t.Nombre,
                    Ubigeo = t.Ubigeo,
                }).SingleOrDefaultAsync();
            return await result;
        }
    }
}
