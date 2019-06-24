﻿using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FormalizacionType : ObjectGraphType<Formalizacion>
    {
        public FormalizacionType()
        {
            Name = "puebloExistente";
            Field(x => x.Id).Description("Identificador de pueblo existente");
            Field(x => x.Coordenadas).Description("Coordenadas de pueblo existente");
            Field(x => x.Nombre).Description("Nombre de pueblo existente");
        }
    }
}