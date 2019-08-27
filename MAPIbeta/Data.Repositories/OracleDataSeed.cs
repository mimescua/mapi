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
            if (!dbContext.SFI_GEOUNIDADT.Any())
            {
                dbContext.SFI_GEOUNIDADT.Add(new UnidadT
                {
                    Id = 1,
                    Type = "Polygon",
                    CoordinateString = "[[[-77.12722063064575,-12.059759855123742],[-77.11666345596313,-12.067188125719579],[-77.10968971252441,-12.070377602464728],[-77.10758686065674,-12.055688907680587],[-77.12722063064575,-12.059759855123742]]]",
                    Nombre = "Asentamiento Humano",
                    Ubigeo = "01",
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.SFI_GEOPUEBLO.Any())
            {
                dbContext.SFI_GEOPUEBLO.Add(new Pueblo
                {
                    Id = 1,
                    Type = "MultiPolygon",
                    CoordinateString = "[[[[-77.12698459625244,-12.059738871016993],[-77.11921691894531,-12.065551405810487],[-77.11305856704712,-12.056738126848984],[-77.12698459625244,-12.059738871016993]]]]",
                    Nombre = "XR1",
                    Ubigeo = "01",
                    NomParcela = "1",
                    Area = 2.1,
                    AreaVivienda = 2.1,
                    AreaComunal = 2.1,
                    AreaEducacion = 2.1,
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.SFI_GEOMANZANA.Any())
            {
                dbContext.SFI_GEOMANZANA.Add(new Manzana
                {
                    Id = 1,
                    PuebloId = 1,//xtra
                    Type = "Polygon",
                    CoordinateString = "[[[[-77.12724208831787,-12.064670090950587],[-77.12634086608887,-12.064670090950587],[-77.12634086608887,-12.063935659687319],[-77.12724208831787,-12.063935659687319],[-77.12724208831787,-12.064670090950587]]]]",
                    Nombre = "A",
                    Ubigeo = "01",
                    CantLotes = 1,
                    Area = 2.1,
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.SFI_GEOLOTE.Any())
            {
                dbContext.SFI_GEOLOTE.Add(new Lote
                {
                    Id = 1,
                    PuebloId = 1,//xtra
                    ManzanaId = 1,//xtra
                    Type = "Polygon",
                    CoordinateString = "[[[[-77.1212875843048,-12.059560506043402],[-77.12060093879698,-12.060305441322697],[-77.11945295333861,-12.059382140951179],[-77.1212875843048,-12.059560506043402]]]]",
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
            if (!dbContext.SFI_GEOCALLE.Any())
            {
                dbContext.SFI_GEOCALLE.Add(new Calle
                {
                    Id = 1,
                    PuebloId = 1,//xtra
                    Type = "Point",
                    CoordinateString = "[-77.12094426155089,-12.06418746491854]",
                    Nombre = "Calle 1",
                    Ubigeo = "01",
                });
                dbContext.SaveChanges();
            }
        }
    }
}