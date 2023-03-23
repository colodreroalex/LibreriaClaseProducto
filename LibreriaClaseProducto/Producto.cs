namespace LibreriaClaseProducto
{

    #region EXCEPCIONES PERSONALIZADAS
    public class NombreNoEstablecidoException : Exception
    {
        public NombreNoEstablecidoException() : base("Nombre no establecido")   //Mensaje q tendra por defecto
        {

        }
        public NombreNoEstablecidoException(string msj) : base(msj) 
        { 

        }
    }

    public class PrecioNoEstablecidoException : Exception
    {
        public PrecioNoEstablecidoException() : base("No has establecido un precio")
        {

        }

        public PrecioNoEstablecidoException(string mensaje) : base(mensaje)
        {

        }

    }

    public class CadenaVaciaException : Exception
    {
        public CadenaVaciaException() : base("Cadena nula o vacia")   //Mensaje q tendra por defecto
        {

        }
        public CadenaVaciaException(string msj) : base(msj)
        {

        }
    }

    public class NumeroNegativoException : Exception
    {
        public NumeroNegativoException()
        {
        }

        public NumeroNegativoException(string mensaje) : base(mensaje)
        {
        }

    }

    public class BanCharException : Exception
    {
        public BanCharException() : base("Caracteres no permitidos")
        {
        }

        public BanCharException(string mensaje) : base(mensaje)
        {
        }

    }

    public class EmptyStringException : Exception
    {
        public EmptyStringException()
        {

        }

        public EmptyStringException(string mensaje) : base(mensaje)
        {

        }

    }

    public class InvalidCuantityException : Exception
    {
        public InvalidCuantityException()
        {

        }

        public InvalidCuantityException(string msg) : base(msg)
        {

        }
    }
    #endregion

    public class Producto
    {
        //CONSTANTES

        private const float IVA = 0.21f;
        const string INI_NOMBRE = "ne";
        const int INI_PRECIO = -1; 
        const int MIN_PRECIO = 0; 
        //MIEMBROS 
        protected string _nombre;
        protected float _precioBase;

        #region CONSTRUCTORES

        public Producto()
        {
            _nombre = INI_NOMBRE;
            _precioBase = INI_PRECIO; 
        }

        public Producto(string nombre, float precio) : this() //Llamar al constructor por defecto para que la string no sea null y sea "ne" y el float no sea 0 y sea -1 
                                                                //Ya que por defecto los strings son nulls y los float/int son 0
        {
            Nombre = nombre;
            PrecioBase = precio; 
        }

        #endregion


        #region PROPIEDADES
        public string Nombre
        {
            get 
            {
                if (_nombre == INI_NOMBRE) throw new NombreNoEstablecidoException();

                return _nombre; 
            }
            set 
            {

                //Preparacion de la permitidos para ser evaluada en caso que no este vacia o con caracteres no permitidos
                value = value.ToLower().Trim();

                //Chequear Cadena
                try
                {
                    ChequearCadena(value);
                }
                catch (CadenaVaciaException vacia)
                {
                    throw new CadenaVaciaException("El nombre del producto esta vacio o es nulo");
                }
                catch(BanCharException charex)
                {
                    throw new BanCharException("En el nombre se han introducido caracteres no permitidos");
                }

                

                //Asignacion
                _nombre = value; 
                
                

            }
        }

        public virtual float PrecioIva //Virtual --> Para que se pueda sobreescribir en otras clases derivadas
        {
            get { return PrecioBase + (PrecioBase * IVA); } //PrecioBase + (PrecioBase * IVA)
        }

        //public abstract float PrecioIva //Abstract --> Obligatorio que se tenga que sobreescribir en las clases derivadas
        //{
        //    get { return CalcularIva(IVA); } //PrecioBase + (PrecioBase * IVA)
        //}

        public float PrecioBase
        {
            get 
            {
                if(_precioBase == INI_PRECIO) throw new PrecioNoEstablecidoException(); //Constructor por defecto
                return _precioBase; 
            }
            set 
            {
                

                if (value < MIN_PRECIO) throw new NumeroNegativoException("ERROR: El precio no puede ser menor a 0"); //Constructor por parametro "string msj"

                //Asignacion
                _precioBase = value; 
            }
        }
        #endregion


        #region METODOS

        //PRIVADO
        protected void ChequearCadena(string valor) 
        {

            //Cadena vacia
            if (String.IsNullOrEmpty(valor))
                throw new CadenaVaciaException();

            valor = valor.ToLower().Trim();

            //Caracteres no permitidos
            string permitidos = "áéíóúqwertyuiopasdfghjklñzxcvbnm1234567890 "; //--> Hay un espacio en blanco ya que se permiten nombres compuestos
            bool esCorrecto = true; 

            for(int i = 0; i < valor.Length && esCorrecto; i++)
            {
                esCorrecto = permitidos.Contains(valor[i]);
            }

            if(!esCorrecto) 
                throw new BanCharException();

            

        }

        

        //PUBLICO
        public override string ToString()
        {
            string cadena;

            cadena = "PRODUCTO\tPRECIO/UD\tPRECIO+IVA\n\n";
            cadena += $"{Nombre}\t\t{PrecioBase}\t\t{PrecioIva}\n\n\n";


            return cadena;
        }

        #endregion



    }
}