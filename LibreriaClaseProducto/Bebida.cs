using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibreriaClaseProducto
{

    #region EXCEPCIONES PERSONALIZADAS
    public class DenominacionNoEstablecidaException : Exception
    {
        public DenominacionNoEstablecidaException() : base("Denominacion No establecida")
        {

        }

        public DenominacionNoEstablecidaException(string msj) : base(msj)
        {

        }
    }
    #endregion

    public enum TipoDeVenta : byte { Botella, Caja3, Caja6, Caja12 }


    public class Bebida : Producto
    {
        //CONSTANTES
        const float IVA = 0.21f; 
        //MIEMBROS

        private string _denominacion;
        private TipoDeVenta _formatoVenta;
        private int _cantidad;


        #region  CONSTRUCTORES
        public Bebida() : base()
        {
            _nombre = "Fino Baena";
            _denominacion = "Montilla Moriles";
            _formatoVenta = TipoDeVenta.Botella;
            _precioBase = -1;
            _cantidad = 0;
        }

        public Bebida(string nombre, float precio, string denominacionOrigen) : this()
        {
            
            Denominacion = denominacionOrigen;
        }
        #endregion


        #region PROPIEDADES
        public string Denominacion
        {
            get 
            {
                if (_denominacion == "Montilla Moriles")
                    throw new DenominacionNoEstablecidaException();

                return _denominacion; 
            }
            set 
            {

                ChequearCadena(value);

                value = value.ToLower().Trim();

                _denominacion = value; 
            }
        }

        public TipoDeVenta Formatoventa
        {
            get { return _formatoVenta; }
            set { _formatoVenta = value; }
        }

        public int Cantidad
        {
            get 
            {
                if (_cantidad == 0) throw new InvalidCuantityException("Valor no establecido para la cantidad de Bebida");
                return _cantidad; 
            }
            set
            {
                if (value > 10) throw new Exception("Has pasado el limite permitido(10)");
                if (value < 0) throw new NumeroNegativoException("La cantidad no puede ser negativa");

                _cantidad = value;
            }
        }

        public override float PrecioIva
        {
            get { return PrecioBase + (PrecioBase * IVA); }
        }

        #endregion


    }
}