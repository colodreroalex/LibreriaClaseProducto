using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClaseProducto
{
    public enum TipoUnidadVenta : byte { Kg, Bandeja }; //Publico --> Sea accesible desde mas clases
                                                        //: byte --> Sera por defecto INT , pero decimos que va a heredar en BYTE
                                                        //{Kg(byte N.0) , Bandeja(byte N.1)} --> Solo 2 bytes

    public class Carne : Producto
    {
        const float IVA = 0.1f; 


        private string _tipoCorte;
        //private string _unidadVenta;
        private TipoUnidadVenta _unidadVenta; //Inventamos un nuevo tipo de miembro de enumeracion
        private int _cantidad; 

        public Carne() : base()
        {
            _nombre = "Pollo";
            _tipoCorte = "Filetes";
            _unidadVenta = TipoUnidadVenta.Kg; //Asi no hay lugar a fallos 
            _cantidad = 0;
        }

        //  Parametros-->    (nombre      precio         tipo ):  --> Hereda de la Clase "Producto" : nombre y precio  
        public Carne(string nombre, float precio, string tipo) : base(nombre, precio)
        {
            TipoCorte = tipo;
            _unidadVenta = TipoUnidadVenta.Kg;
            _cantidad = 0;
        }

        public string TipoCorte
        {
            get { return _tipoCorte; }
            set 
            {
                
                try
                {
                    ChequearCadena(value);  //REF/OUT   
                                            //REF: Requiere que value , tenga un valor inicializado de antes, pero si es una cadena nula o vacia no nos sirve
                                            //OUT: Entonces usaremos OUT, que no necesitamos inicializacion

                                            //Metodo en vez de vacio--> Que devuelva la cadena con "value = value.ToLower().Trim();" en su interior 
                }
                catch (BanCharException banex)
                {
                    throw new BanCharException("Caracteres no permitidos para el Tipo de Corte");
                }
                catch(CadenaVaciaException cv)
                {
                    throw new CadenaVaciaException("El tipo de corte esta vacio o null");
                }

                //Preparacion de la permitidos para ser evaluada en caso que no este vacia o con caracteres no permitidos
                value = value.ToLower().Trim();

                //Asignar
                _tipoCorte = value; 
            }
        }


        public TipoUnidadVenta UnidadVenta //Dejamos la propiedad por si acaso alguien quiere heredar de la clase "Carne"
        {
            get { return _unidadVenta; }
            set { _unidadVenta = value;}
        }

        //public string UnidadVenta
        //{
        //    get { return _unidadVenta; }
        //    set { _unidadVenta = value; }
        //}

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public float PrecioKilo
        {
            get { return PrecioBase * Cantidad; }
        }

        public override float PrecioIva
        {
            get { return PrecioBase + (PrecioBase * IVA); }
        }

        public float PrecioTotalIva
        {
            get { return PrecioKilo + (PrecioKilo * IVA); }
        }


        public override string ToString()
        {
            string cadena; 

            cadena = $"{TipoCorte} de {Nombre} en {UnidadVenta}\t  {PrecioBase}\t\t{PrecioIva}\n\n";
            cadena += $"Cantidad: {Cantidad} \t PrecioTotal: {PrecioKilo} \t Precio Total+IVA:{PrecioTotalIva} ";
            return cadena;
        }

    }
}
