﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasWorker.Domain.Models
{
    public class EntregaDetalle
    {

        public string Producto { get; set; }
        public int Cantidad { get; set; }

    }
}
