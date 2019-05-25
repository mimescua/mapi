using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public static class OracleDataSeed
    {
        public static void Seed(this OracleDbContext dbContext)
        {
            if (!dbContext.FEATURECOLLECTION.Any())
            {
                dbContext.FEATURECOLLECTION.Add(new FeatureCollection
                {
                    Id = 1,
                    Type = "FeatureCollection",
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.FEATURES.Any())
            {
                dbContext.FEATURES.Add(new Features
                {
                    Id = 1,
                    fkey = 1,
                    Type = "Feature",
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.UNIDADTS.Any())
            {
                dbContext.UNIDADTS.Add(new UnidadT
                {
                    Id = 1,
                    Type = "MultiPolygon",
                    Coordinates = "[[[[-77.12722063064575,-12.059759855123742],[-77.11666345596313,-12.067188125719579],[-77.10968971252441,-12.070377602464728],[-77.10758686065674,-12.055688907680587],[-77.12722063064575,-12.059759855123742]]]]",
                    Nombre = "Asentamiento Humano",
                    Ubigeo = "01",
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.PUEBLOS.Any())
            {
                dbContext.PUEBLOS.Add(new Pueblo
                {
                    Id = 1,
                    Type = "MultiPolygon",
                    Coordinates = "[[[[-77.12698459625244,-12.059738871016993],[-77.11921691894531,-12.065551405810487],[-77.11305856704712,-12.056738126848984],[-77.12698459625244,-12.059738871016993]]]]",
                    Nombre = "XR1",
                    Ubigeo = "01",
                    CantParcelas = 1,
                    Area = 2.1,
                    AreaVivienda = 2.1,
                    AreaComunal = 2.1,
                    AreaEducacion = 2.1,
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.MANZANAS.Any())
            {
                dbContext.MANZANAS.Add(new Manzana
                {
                    Id = 1,
                    Type = "MultiPolygon",
                    Coordinates = "[[[[-77.12724208831787,-12.064670090950587],[-77.12634086608887,-12.064670090950587],[-77.12634086608887,-12.063935659687319],[-77.12724208831787,-12.063935659687319],[-77.12724208831787,-12.064670090950587]]]]",
                    Nombre = "A",
                    Ubigeo = "01",
                    CantLotes = 1,
                    Area = 2.1,
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.LOTES.Any())
            {
                dbContext.LOTES.Add(new Lote
                {
                    Id = 1,
                    Type = "MultiPolygon",
                    Coordinates = "[[[[-77.1212875843048,-12.059560506043402],[-77.12060093879698,-12.060305441322697],[-77.11945295333861,-12.059382140951179],[-77.1212875843048,-12.059560506043402]]]]",
                    Nombre = "10",
                    Ubigeo = "01",
                    Area = 2.1,
                    TipoUso = "vivienda",
                    MedidFrnt = "10",
                    MedidIzq = "10",
                    MedidPost = "10",
                    MedidDer = "10",
                    ColinFrnt = "calle",
                    ColinIzq = "calle",
                    ColinPost = "calle",
                    ColinDer = "calle",
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.CALLES.Any())
            {
                dbContext.CALLES.Add(new Calle
                {
                    Id = 1,
                    Type = "LineString",
                    Coordinates = "[[-77.12094426155089,-12.06418746491854],[-77.11989283561707,-12.062949420254483]]",
                    Nombre = "Calle 1",
                    Ubigeo = "01",
                });
                dbContext.SaveChanges();
            }
            /*if (!dbContext.FEATURECOLLECTION.Any())
            {
                dbContext.FEATURECOLLECTION.Add(new FeatureCollection
                {
                    Id = 1,
                    Type = "FeatureCollection",
                    Features = new List<Features>
                    {
                        new Features
                        {
                            Type = "Feature",
                            UnidadTGeom = new UnidadT {
                                Id = 1,
                                Pueblos = new List<Pueblo> {
                                    new Pueblo
                                    {
                                        Id = 1,
                                        Parcelas = new List<Parcela> {
                                            new Parcela
                                            {
                                                Id = 1,
                                                Manzanas = new List<Manzana> {
                                                    new Manzana
                                                    {
                                                        Id = 1,
                                                        Lotes = new List<Lote> {
                                                            new Lote
                                                            {
                                                                Id = 1,
                                                                Type = "MultiPolygon",
                                                                Coordinates = "[[[[-77.1212875843048,-12.059560506043402],[-77.12060093879698,-12.060305441322697],[-77.11945295333861,-12.059382140951179],[-77.1212875843048,-12.059560506043402]]]]",
                                                                Nombre = "10",
                                                                Ubigeo ="01",
                                                                Area = 2.1,
                                                                TipoUso = "vivienda",
                                                                MedidFrnt = "10",
                                                                MedidIzq = "10",
                                                                MedidPost = "10",
                                                                MedidDer = "10",
                                                                ColinFrnt = "calle",
                                                                ColinIzq = "calle",
                                                                ColinPost = "calle",
                                                                ColinDer = "calle",
                                                            },
                                                        },
                                                        Calles = new List<Calle> {
                                                            new Calle
                                                            {
                                                                Id = 1,
                                                                Type = "LineString",
                                                                Coordinates = "[[-77.12094426155089,-12.06418746491854],[-77.11989283561707,-12.062949420254483]]",
                                                                Nombre = "Calle 1",
                                                                Ubigeo = "01",
                                                            },
                                                        },
                                                        Type = "MultiPolygon",
                                                        Coordinates = "[[[[-77.12724208831787,-12.064670090950587],[-77.12634086608887,-12.064670090950587],[-77.12634086608887,-12.063935659687319],[-77.12724208831787,-12.063935659687319],[-77.12724208831787,-12.064670090950587]]]]",
                                                        Nombre = "A",
                                                        Ubigeo = "01",
                                                        CantLotes = 1,
                                                        Area = 2.1,
                                                    },
                                                },
                                            }
                                        },
                                        Type = "MultiPolygon",
                                        Coordinates = "[[[[-77.12698459625244,-12.059738871016993],[-77.11921691894531,-12.065551405810487],[-77.11305856704712,-12.056738126848984],[-77.12698459625244,-12.059738871016993]]]]",
                                        Nombre = "XR1",
                                        Ubigeo = "01",
                                        CantParcelas = 1,
                                        Area = 2.1,
                                        AreaVivienda = 2.1,
                                        AreaComunal = 2.1,
                                        AreaEducacion = 2.1,
                                    }
                                },
                                Type = "MultiPolygon",
                                Coordinates = "[[[[-77.12722063064575,-12.059759855123742],[-77.11666345596313,-12.067188125719579],[-77.10968971252441,-12.070377602464728],[-77.10758686065674,-12.055688907680587],[-77.12722063064575,-12.059759855123742]]]]",
                                Nombre = "Asentamiento Humano",
                                Ubigeo= "01",
                            },
                        },
                    }
                });
                dbContext.SaveChanges();
            };*/
        }
    }
}