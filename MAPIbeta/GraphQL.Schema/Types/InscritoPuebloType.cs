﻿using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class InscritoPuebloGeometryType : ObjectGraphType<InscritoPueblo>
    {
        public InscritoPuebloGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría del pueblo");
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());

//            Field<StringGraphType>("coordinates",
//              resolve: context => ((InscritoPueblo)context.Source).Coordinates.ToArray());
//            Field<ListGraphType<ListGraphType<FloatGraphType>>>()
//                .Name("coors")
//                .ResolveAsync(async context => context.Source.Coords);//

//            Field(x => x.Coords, type: typeof(ListGraphType<ListGraphType<FloatGraphType>>))
//                .Name("coors")
//                .ResolveAsync(async context => context.Source.Coords);//
        }
    }
    public class InscritoPuebloPropertyType : ObjectGraphType<InscritoPueblo>
    {
        public InscritoPuebloPropertyType()
        {
            Name = "Pueblo_Inscrito_Properties";
            Field(x => x.Id).Description("Ubigeo del pueblo");
            Field(x => x.Nombre, nullable: true).Description("Nombre del pueblo");
            Field(x => x.Ubigeo, nullable:true).Description("Ubigeo del pueblo");

            Field(x => x.CodPueblo, nullable: true).Description("código del pueblo");
            Field(x => x.NroPlano, nullable: true).Description("Número de plano de procedencia");
            Field(x => x.Fecha, nullable: true).Description("Fecha de registro");
            Field(x => x.Fuente, nullable: true).Description("Origen del registro geométrico");
        }
    }
}