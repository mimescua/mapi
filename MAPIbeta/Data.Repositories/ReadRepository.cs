using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using Newtonsoft.Json;

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
        public async Task<List<Features>> GetFormalizacion(string tipo, List<double> extent, string plano)
        {
            var ids = new int[] { };

            if (plano == "")
            {
                switch (tipo.ToLower())
                {
                    case "calle": ids = _dbContext.SFI_GEOCALLE.FromSql($"Select t.CALLEID from SFI_GEOCALLE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE'").Select(x => x.Id).Take(1000).ToArray(); break;
                    case "lote": ids = _dbContext.SFI_GEOLOTE.FromSql($"Select t.LOTEID from SFI_GEOLOTE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE'").Select(x => x.Id).Take(1000).ToArray(); break;
                    case "manzana": ids = _dbContext.SFI_GEOMANZANA.FromSql($"Select t.MANZANAID from SFI_GEOMANZANA t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE'").Select(x => x.Id).Take(1000).ToArray(); break;
                    case "pueblo": ids = _dbContext.SFI_GEOPUEBLO.FromSql($"Select t.PUEBLOID from SFI_GEOPUEBLO t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE'").Select(x => x.Id).Take(1000).ToArray(); break;
                    case "unidadt": ids = _dbContext.SFI_GEOUNIDADT.FromSql($"Select t.UNIDADTID from SFI_GEOUNIDADT t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE'").Select(x => x.Id).Take(1000).ToArray(); break;
                    default: ids = new int[] { 1 }; break;
                }
            }
            else if (extent.Count() == 0)
            {
                switch (tipo.ToLower())
                {
                    case "calle": ids = (from o in _dbContext.SFI_GEOCALLE join p in _dbContext.SFI_GEOPUEBLO on o.PuebloId equals p.Id where p.PlanoId == Convert.ToInt32(plano) select o.Id ).Take(1000).ToArray(); break;
                    case "lote": ids = (from o in _dbContext.SFI_GEOLOTE join p in _dbContext.SFI_GEOPUEBLO on o.PuebloId equals p.Id where p.PlanoId == Convert.ToInt32(plano) select o.Id ).Take(1000).ToArray(); break;
                    case "manzana": ids = (from o in _dbContext.SFI_GEOMANZANA join p in _dbContext.SFI_GEOPUEBLO on o.PuebloId equals p.Id where p.PlanoId == Convert.ToInt32(plano) select o.Id ).Take(1000).ToArray(); break;
                    case "pueblo": ids = _dbContext.SFI_GEOPUEBLO.AsQueryable().Where(r => r.PlanoId == Convert.ToInt32(plano)).Select(r => r.Id).Take(1000).ToArray(); break;
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

        public async Task<List<FeaturesInscrito>> GetInscritosPSAD56(string tipo, double[] extent)
        {
            var ids = new string[] { };
            //using (SqlConnection sql = new SqlConnection(_dbContext))
            if (tipo != "" && extent != null)
            {
                switch (tipo.ToLower())
                {
                    //case "calle": ids = _dbContext.BMAP_CALLE.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).Take(1000).ToArray(); break;
                    //case "lote": ids = _dbContext.BMAP_LOTE.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).Take(1000).ToArray(); ; break;
                    //case "manzana": ids = _dbContext.BMAP_MANZANA.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).Take(1000).ToArray(); break;
                    //case "pueblo": ids = _dbContext.BMAP_PUEBLO.AsQueryable().Where(r => r.Ubigeo == ubigeo).Select(r => r.Id).Take(1000).ToArray(); break;
                    case "calle":
                        {
                            ids = _dbContext.BMAP_CALLE.FromSql($"Select t.OID from BMAP_CALLE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='CALLES'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "lote":
                        {
                            ids = _dbContext.BMAP_LOTE.FromSql($"Select t.OID from BMAP_LOTE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='LOTES'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "manzana":
                        {
                            ids = _dbContext.BMAP_MANZANA.FromSql($"Select t.OID from BMAP_MANZANA t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='MANZANAS'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "pueblo":
                        {
                            ids = _dbContext.BMAP_PUEBLO.FromSql($"Select t.OID from BMAP_PUEBLO t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='PUEBLOS'").Select(X=>X.Id).Take(1000).ToArray();
                        }; break;
                    default: ids = new string[] { "1" }; break;
                }
            }
            else if (tipo != "")
            {
                switch (tipo.ToLower())
                {
                    case "calle":
                        {
                            ids = _dbContext.BMAP_CALLE.FromSql($"Select t.OID from BMAP_CALLE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='CALLES'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "lote":
                        {
                            ids = _dbContext.BMAP_LOTE.FromSql($"Select t.OID from BMAP_LOTE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='LOTES'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "manzana":
                        {
                            ids = _dbContext.BMAP_MANZANA.FromSql($"Select t.OID from BMAP_MANZANA t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='MANZANAS'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "pueblo":
                        {
                            ids = _dbContext.BMAP_PUEBLO.FromSql($"Select t.OID from BMAP_PUEBLO t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='PUEBLOS'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    default: ids = new string[] { "1" }; break;
                }
            }
            var result = new List<FeaturesInscrito>(ids.Length);
            for (int i = 0; i < ids.Length; i++)
            {
                result.Add(new FeaturesInscrito { Id = ids[i], Type = "Feature" });
            }

            return result.ToList();
        }
        public async Task<List<FeaturesInscrito>> GetInscritosWGS84(string tipo, double[] extent)
        {
            var ids = new string[] { };
            if (tipo != "" && extent != null)
            {
                switch (tipo.ToLower())
                {
                    case "calle":
                        {
                            ids = _dbContext.BMAP_CALLE.FromSql($"Select t.OID from BMAP_CALLE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='W_CALLES'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "lote":
                        {
                            ids = _dbContext.BMAP_LOTE.FromSql($"Select t.OID from BMAP_LOTE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='W_LOTES'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "manzana":
                        {
                            ids = _dbContext.BMAP_MANZANA.FromSql($"Select t.OID from BMAP_MANZANA t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='W_MANZANAS'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "pueblo":
                        {
                            ids = _dbContext.BMAP_PUEBLO.FromSql($"Select t.OID from BMAP_PUEBLO t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='W_PUEBLOS'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    default: ids = new string[] { "1" }; break;
                }
            }
            else if (tipo != "")
            {
                switch (tipo.ToLower())
                {
                    case "calle":
                        {
                            ids = _dbContext.BMAP_CALLE.FromSql($"Select t.OID from BMAP_CALLE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='W_CALLES'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "lote":
                        {
                            ids = _dbContext.BMAP_LOTE.FromSql($"Select t.OID from BMAP_LOTE t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='W_LOTES'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "manzana":
                        {
                            ids = _dbContext.BMAP_MANZANA.FromSql($"Select t.OID from BMAP_MANZANA t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='W_MANZANAS'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    case "pueblo":
                        {
                            ids = _dbContext.BMAP_PUEBLO.FromSql($"Select t.OID from BMAP_PUEBLO t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE' and TABLE_SRC='W_PUEBLOS'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    default: ids = new string[] { "1" }; break;
                }
            }
            var result = new List<FeaturesInscrito>(ids.Length);
            for (int i = 0; i < ids.Length; i++)
            {
                result.Add(new FeaturesInscrito { Id = ids[i], Type = "Feature" });
            }

            return result.ToList();
        }

        public async Task<List<FeaturesMatriz>> GetMatrices(string tipo, double[] extent)
        {
            var ids = new string[] { };
            if (tipo != "" && extent != null)
            {
                switch (tipo.ToLower())
                {
                    case "pueblo":
                        {
                            ids = _dbContext.BMAP_MATRIZ.FromSql($"Select t.OID from BMAP_CP_PBL t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    default: ids = new string[] { "1" }; break;
                }
            }
            else if (tipo != "")
            {
                switch (tipo.ToLower())
                {
                    case "pueblo":
                        {
                            ids = _dbContext.BMAP_MATRIZ.FromSql($"Select t.OID from BMAP_CP_PBL t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY(-81.3282304899999531,-18.3509277359999601, -68.6522791029999553,-0.0386059679999562)), 'mask = anyinteract') = 'TRUE'").Select(X => X.Id).Take(1000).ToArray();
                        }; break;
                    default: ids = new string[] { "1" }; break;
                }
            }
            var result = new List<FeaturesMatriz>(ids.Length);
            for (int i = 0; i < ids.Length; i++)
            {
                result.Add(new FeaturesMatriz { Id = ids[i], Type = "Feature" });
            }

            return result.ToList();
        }

        public async Task<List<FeaturesTematico>> GetTematico(string tipo, string anio, double[] extent)
        {
            var ids = new string[] { };

            switch (tipo.ToLower())
            {
                case "inscrito":
                    {
                        ids = _dbContext.BMAP_MATRIZ.FromSql($"Select t.OID from BMAP_PUEBLO t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and extract(YEAR from FECH_TRAN) = {anio}").Select(X => X.Id).Take(1000).ToArray();
                    }; break;
                case "formalizacion":
                    {
                        ids = _dbContext.BMAP_MATRIZ.FromSql($"Select t.OID from BMAP_PUEBLO t where MDSYS.SDO_RELATE(t.GEOMLL, MDSYS.SDO_GEOMETRY(2003, 4326, NULL, SDO_ELEM_INFO_ARRAY(1, 1003, 3), SDO_ORDINATE_ARRAY({extent[0]}, {extent[1]}, {extent[2]}, {extent[3]})), 'mask = anyinteract') = 'TRUE' and extract(YEAR from FECH_TRAN) = {anio}").Select(X => X.Id).Take(1000).ToArray();
                    }; break;
                default: ids = new string[] { "1" }; break;
            }
            var result = new List<FeaturesTematico>(ids.Length);
            for (int i = 0; i < ids.Length; i++)
            {
                result.Add(new FeaturesTematico { Id = ids[i], Type = "Feature" });
            }

            return result.ToList();
        }

        //Retrieving batch type collection AS LIST TYPE by id lists
        //public async Task<IDictionary<int, Lote>> GetSomeLotesByIdAsync(IEnumerable<int> loteIds, CancellationToken token)
        //{
        //    return await _dbContext.SFI_GEOLOTE.Where(i => loteIds.Contains(i.Id)).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        //}
        public async Task<IDictionary<int, Lote>> GetGeomLotesByIdList(IEnumerable<int> loteIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOLOTE.Where(i => loteIds.Contains(i.Id)).Select(t => new Lote
            {
                Id = t.Id,
                Type = t.Type,
                Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, Lote>> GetPropsLotesByIdList(IEnumerable<int> loteIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOLOTE.Where(i => loteIds.Contains(i.Id)).Select(t => new Lote
            {
                Id = t.Id,
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
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }

        public async Task<IDictionary<int, Calle>> GetGeomCallesByIdList(IEnumerable<int> calleIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOCALLE.Where(i => calleIds.Contains(i.Id)).Select(t => new Calle
            {
                Id = t.Id,
                Type = t.Type,
                Coordinates = JsonConvert.DeserializeObject<List<double>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, Calle>> GetPropsCallesByIdList(IEnumerable<int> calleIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOCALLE.Where(i => calleIds.Contains(i.Id)).Select(t => new Calle
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Ubigeo = t.Ubigeo
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }

        public async Task<IDictionary<int, Manzana>> GetGeomManzanasByIdList(IEnumerable<int> manzanaIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOMANZANA.Where(i => manzanaIds.Contains(i.Id)).Select(t => new Manzana
            {
                Id = t.Id,
                Type = t.Type,
                Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, Manzana>> GetPropsManzanasByIdList(IEnumerable<int> manzanaIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOMANZANA.Where(i => manzanaIds.Contains(i.Id)).Select(t => new Manzana
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Ubigeo = t.Ubigeo,
                CantLotes = t.CantLotes,
                Area = t.Area
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }

        public async Task<IDictionary<int, Pueblo>> GetGeomPueblosByIdList(IEnumerable<int> puebloIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOPUEBLO.Where(i => puebloIds.Contains(i.Id)).Select(t => new Pueblo
            {
                Id = t.Id,
                Type = t.Type,
                Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, Pueblo>> GetPropsPueblosByIdList(IEnumerable<int> puebloIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOPUEBLO.Where(i => puebloIds.Contains(i.Id)).Select(t => new Pueblo
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Ubigeo = t.Ubigeo,
                NomParcela = t.NomParcela,
                Area = t.Area,
                AreaVivienda = t.AreaVivienda,
                AreaComunal = t.AreaComunal,
                AreaEducacion = t.AreaEducacion
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }

        public async Task<IDictionary<int, UnidadT>> GetGeomUnidadtByIdList(IEnumerable<int> unidadtIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOPUEBLO.Where(i => unidadtIds.Contains(i.Id)).Select(t => new UnidadT
            {
                Id = t.Id,
                Type = t.Type,
                Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<int, UnidadT>> GetPropsUnidadtByIdList(IEnumerable<int> unidadtIds, CancellationToken token)
        {
            return await _dbContext.SFI_GEOPUEBLO.Where(i => unidadtIds.Contains(i.Id)).Select(t => new UnidadT
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Ubigeo = t.Ubigeo
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }


        public async Task<IDictionary<string, InscritoLote>> GetGeomLotesInscritoByIdList(IEnumerable<string> loteIds, CancellationToken token)
        {
            return await _dbContext.BMAP_LOTE.Where(i => loteIds.Contains(i.Id)).Select(t => new InscritoLote
            {
                Id = t.Id,
                Type = "MultiPolygon",
                Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<string, InscritoLote>> GetPropsLotesInscritoByIdList(IEnumerable<string> loteIds, CancellationToken token)
        {
            return await _dbContext.BMAP_LOTE.Where(i => loteIds.Contains(i.Id)).Select(t => new InscritoLote
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Ubigeo = t.Ubigeo,
                CodPueblo = t.CodPueblo,
                NroPlano = t.NroPlano,
                Fecha = Convert.ToString(t.Fecha),
                Fuente = t.Fuente
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }

        public async Task<IDictionary<string, InscritoCalle>> GetGeomCallesInscritoByIdList(IEnumerable<string> calleIds, CancellationToken token)
        {
            return await _dbContext.BMAP_CALLE.Where(i => calleIds.Contains(i.Id)).Select(t => new InscritoCalle
            {
                Id = t.Id,
                Type = "Point",
                Coordinates = JsonConvert.DeserializeObject<List<double>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<string, InscritoCalle>> GetPropsCallesInscritoByIdList(IEnumerable<string> calleIds, CancellationToken token)
        {
            return await _dbContext.BMAP_CALLE.Where(i => calleIds.Contains(i.Id)).Select(t => new InscritoCalle
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Ubigeo = t.Ubigeo,
                CodPueblo = t.CodPueblo,
                NroPlano = t.NroPlano,
                Fecha = Convert.ToString(t.Fecha),
                Fuente = t.Fuente
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }

        public async Task<IDictionary<string, InscritoManzana>> GetGeomManzanasInscritoByIdList(IEnumerable<string> manzanaIds, CancellationToken token)
        {
            return await _dbContext.BMAP_MANZANA.Where(i => manzanaIds.Contains(i.Id)).Select(t => new InscritoManzana
            {
                Id = t.Id,
                Type = "MultiPolygon",
                Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<string, InscritoManzana>> GetPropsManzanasInscritoByIdList(IEnumerable<string> manzanaIds, CancellationToken token)
        {
            return await _dbContext.BMAP_MANZANA.Where(i => manzanaIds.Contains(i.Id)).Select(t => new InscritoManzana
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Ubigeo = t.Ubigeo,
                CodPueblo = t.CodPueblo,
                NroPlano = t.NroPlano,
                Fecha = Convert.ToString(t.Fecha),
                Fuente = t.Fuente
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }

        public async Task<IDictionary<string, InscritoPueblo>> GetGeomPueblosInscritoByIdList(IEnumerable<string> puebloIds, CancellationToken token)
        {
            //var f = JsonConvert.DeserializeObject<List<List<List<List<double?>>>>>(a);
            //var r = System.Text.Json.JsonSerializer.Deserialize<List<List<List<List<double?>>>>>(a);
            return await _dbContext.BMAP_PUEBLO.Where(i => puebloIds.Contains(i.Id)).Select(t => new InscritoPueblo
            {
                Id = t.Id,
                Type = "MultiPolygon",
                Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<string, InscritoPueblo>> GetPropsPueblosInscritoByIdList(IEnumerable<string> puebloIds, CancellationToken token)
        {
            return await _dbContext.BMAP_PUEBLO.Where(i => puebloIds.Contains(i.Id)).Select(t => new InscritoPueblo
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Ubigeo = t.Ubigeo,
                CodPueblo = t.CodPueblo,
                NroPlano = t.NroPlano,
                Fecha = Convert.ToString(t.Fecha),
                Fuente = t.Fuente
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }


        public async Task<IDictionary<string, MatrizPueblo>> GetGeomPuebloMatrizByIdList(IEnumerable<string> matrizIds, CancellationToken token)
        {
            return await _dbContext.BMAP_MATRIZ.Where(i => matrizIds.Contains(i.Id)).Select(t => new MatrizPueblo
            {
                Id = t.Id,
                Type = "MultiPolygon",
                Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<string, MatrizPueblo>> GetPropsPuebloMatrizByIdList(IEnumerable<string> matrizIds, CancellationToken token)
        {
            return await _dbContext.BMAP_MATRIZ.Where(i => matrizIds.Contains(i.Id)).Select(t => new MatrizPueblo
            {
                Id = t.Id,
                Nombre = t.Nombre,
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }


        public async Task<IDictionary<string, InscritoPueblo>> GetGeomCenPueblosInscritoByIdList(IEnumerable<string> matrizIds, CancellationToken token)
        {
            return await _dbContext.BMAP_PUEBLO.Where(i => matrizIds.Contains(i.Id)).Select(t => new InscritoPueblo
            {
                Id = t.Id,
                Type = "Point",
                Centroide = JsonConvert.DeserializeObject<List<double>>(t.CentroideString)
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
        }
        public async Task<IDictionary<string, InscritoPueblo>> GetPropsCenPueblosInscritoByIdList(IEnumerable<string> matrizIds, CancellationToken token)
        {
            return await _dbContext.BMAP_PUEBLO.Where(i => matrizIds.Contains(i.Id)).Select(t => new InscritoPueblo
            {
                Id = t.Id,
                Nombre = t.Nombre,
            }).ToDictionaryAsync(x => x.Id, cancellationToken: token);
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
                    NomParcela = t.NomParcela,
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

        //Centroide de pueblo en formalización - tabla SFI_PUEBLOS
        public Task<List<PuebloInforme>> GetPuebloInformeByCodPueblo(string codpueblo)
        {
            //return _dbContext.SFI_PUEBLO_INFORME.Where(t => t.Estado == 1).Where(t => t.Tipo == 1).Where(t => EF.Functions.Like(t.Id.ToString(), codpueblo + "%")).ToListAsync();
            return _dbContext.SFI_PUEBLO_INFORME.Where(t => t.Estado == 1).Where(t => t.Tipo == 1).Where(t => t.Id.ToString() == codpueblo).ToListAsync();  //EXACT MATCH
        }
        public Task<List<PuebloInforme>> GetPuebloInformeByNombre(string nombre)
        {
            return _dbContext.SFI_PUEBLO_INFORME.Where(t => t.Estado == 1).Where(t => t.Tipo == 1).Where(t => EF.Functions.Like(t.Nombre, nombre + "%")).ToListAsync(); //MATCH LIST
            //return _dbContext.SFI_PUEBLO_INFORME.Where(t => t.Estado == 1).Where(t => t.Tipo == 1).Where(t => t.Nombre == nombre).ToListAsync();
        }
        public Task<List<PuebloInforme>> GetPuebloInformeByCodCofopri(string codcofopri)
        {
            return _dbContext.SFI_PUEBLO_INFORME.Where(t => t.Estado == 1).Where(t => t.Tipo == 1).Where(t => EF.Functions.Like(t.CodCofopri, codcofopri + "%")).ToListAsync();  //MATCH LIST
            //return _dbContext.SFI_PUEBLO_INFORME.Where(t => t.Estado == 1).Where(t => t.Tipo == 1).Where(t => t.CodCofopri == codcofopri).ToListAsync();
        }

        //Centroide localidades - tabla SEGURIDAD.SFI_UBIGEO
        public Task<List<baseCentroide>> GetDistritoCentroideComo(string nombre)
        {
            //return _secContext.SFI_CENTROIDE.Where(t => t.Id == id).ToListAsync();
            //return _secContext.SFI_CENTROIDE.Where(t => EF.Functions.Like(t.Distrito.ToUpper(), centroide.ToUpper() + "%")).ToListAsync();
            //return _secContext.SFI_CENTROIDE.Where(t => EF.Functions.Like(t.Distrito.ToUpper(), centroide.ToUpper() + "%")).Where(u => !u.Id.EndsWith("00")).ToListAsync();
            return _secContext.SFI_CENTROIDE.Where(t => EF.Functions.Like(t.Distrito.ToUpper(), nombre.ToUpper() + "%")).Where(u => !u.Id.EndsWith("00")).Take(10).ToListAsync();
        }
        public Task<List<baseCentroide>> GetProvinciaCentroideComo(string nombre)
        {
            return _secContext.SFI_CENTROIDE.Where(t => EF.Functions.Like(t.Provincia.ToUpper(), nombre.ToUpper() + "%")).Where(u => u.Id.EndsWith("100")).Take(10).ToListAsync();
        }
        public Task<List<baseCentroide>> GetRegionCentroideComo(string nombre)
        {
            return _secContext.SFI_CENTROIDE.Where(t => EF.Functions.Like(t.Region.ToUpper(), nombre.ToUpper() + "%")).Where(u => u.Id.EndsWith("0000")).Take(10).ToListAsync();
        }

        public async Task<baseDistrito> GetBaseDistritoPor(string ubigeo)
        {
            var result = _dbContext.BMAP_DISTRITO.Where(t => t.Id == ubigeo)
                .Select(t => new baseDistrito
                {
                    Type = "MultiPolygon",
                    Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString),
                }).SingleOrDefaultAsync();
            return await result;
        }   
        public async Task<baseProvincia> GetBaseProvinciaPor(string ubigeo)
        {
            var result = _dbContext.BMAP_PROVINCIA.Where(t => t.Id == ubigeo)
                .Select(t => new baseProvincia
                {
                    Type = "MultiPolygon",
                    Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString),
                }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task<baseRegion> GetBaseRegionPor(string ubigeo)
        {
            var result = _dbContext.BMAP_DEPARTAMENTO.Where(t => t.Id == ubigeo)
                .Select(t => new baseRegion
                {
                    Type = "MultiPolygon",
                    Id = t.Id,
                    Coordinates = JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(t.CoordinateString),
                }).SingleOrDefaultAsync();
            return await result;
        }
    }
}