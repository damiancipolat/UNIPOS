using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BE {
	public class ArticuloBE{

        public int id;
        public ColorBE color;
		public CategoriaBE categoria;
		public MarcaBE marca;
		public ProveedorBE proveedor;
		public float precioVenta;
		public string descrip;
		public string lote;
		public int stock;
		private List<ImagenBE> imagenes;
		public string estado;

		public ArticuloBE(){

		}

	}

}