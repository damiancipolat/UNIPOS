using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BE {
	public class Articulo{

        public int id;
        public Color color;
		public Categoria categoria;
		public Marca marca;
		public Proveedor proveedor;
		public float precioVenta;
		public string descrip;
		public string lote;
		public int stock;
		private List<Imagen> imagenes;
		public string estado;

		public Articulo(){

		}

	}

}