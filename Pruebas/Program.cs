using LibreriaClaseProducto;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //PRUEBA 1 -- Prueba sobre objetos de la clase Producto
            Console.WriteLine("PRUEBAS CON LA CLASE PRODUCTO\n");
            Producto producto1;
            producto1 = new Producto();

            try
            {
                //Establecer cadena vacia
                //producto1.Nombre = "";
                //Establecer Nombre Correcto y observar precio
                producto1.Nombre = "Iphone 14";
                //Nombre caracteres no validos
                //producto1.Nombre = "Iphoneç";
                ////Establecer precio valor incorrecto
                //producto1.PrecioBase = -1;
                //Precio Correcto
                producto1.PrecioBase = 2.5f;
                //Mostrar Objeto con valores por defecto
                MostrarProducto(producto1);
            }
            catch (BanCharException ban)
            {
                Console.WriteLine(ban.Message);
            }
            catch (CadenaVaciaException cvacia)
            {
                Console.WriteLine(cvacia.Message);
            }
            catch (NombreNoEstablecidoException noEs)
            {
                Console.WriteLine(noEs.Message);
            }
            catch (PrecioNoEstablecidoException pNo)
            {
                Console.WriteLine(pNo.Message);
            }
            catch (NumeroNegativoException negativo)
            {
                Console.WriteLine(negativo.Message);
            }
            catch (Exception final)
            {
                Console.WriteLine(final.Message);
            }
            finally
            {
                
            }

            //PRUEBA 2 -- CARNE
            Console.WriteLine("PRUEBAS CON LA CLASE CARNE\n");
            Carne carne1 = new Carne();

            try
            {

                //Establecer cadena vacia
                //carne1.Nombre = "";
                //Establecer Nombre Correcto y observar precio
                carne1.Nombre = "Ternera";
                //Nombre caracteres no validos
                //carne1.Nombre = "Terneraç";
                ////Establecer precio valor incorrecto
                //carne1.PrecioBase = -1;
                //Precio Correcto
                carne1.PrecioBase = 2.5f;
                carne1.Cantidad = 2;
                carne1.UnidadVenta = TipoUnidadVenta.Bandeja;



                MostrarProducto(carne1);
            }
            catch (BanCharException ban)
            {
                Console.WriteLine(ban.Message);
            }
            catch (CadenaVaciaException cvacia)
            {
                Console.WriteLine(cvacia.Message);
            }
            catch (NombreNoEstablecidoException noEs)
            {
                Console.WriteLine(noEs.Message);
            }
            catch (PrecioNoEstablecidoException pNo)
            {
                Console.WriteLine(pNo.Message);
            }
            catch (NumeroNegativoException negativo)
            {
                Console.WriteLine(negativo.Message);
            }
            catch (Exception final)
            {
                Console.WriteLine(final.Message);
            }

            //PRUEBA 3 -- Bebida
            Console.WriteLine("PRUEBAS CON LA CLASE BEBIDA\n");
            Bebida bebida1; 
            bebida1 = new Bebida();

            try
            {
                //Establecer cadena vacia
                //bebida1.Nombre = "";
                //Nombre Correcto
                bebida1.Nombre = "Pepsi";
                //Precio Incorrecto
                //bebida1.PrecioBase = -1;
                //Precio correcto
                bebida1.PrecioBase = 1.2f;
                //Precio default

                //Tipo de venta
                bebida1.Formatoventa = TipoDeVenta.Botella;
                //Denominacion default

                //Denominacion correcta
                bebida1.Denominacion ="rioja";
                //Cantidad negativa
                //bebida1.Cantidad = -1;
                //Cantidad Mayor a 10
                //bebida1.Cantidad = 11;
                //Cantidad correcta
                bebida1.Cantidad = 5;

                MostrarProducto(bebida1);
            }
            catch (BanCharException ban)
            {
                Console.WriteLine(ban.Message);
            }
            catch (CadenaVaciaException cvacia)
            {
                Console.WriteLine(cvacia.Message);
            }
            catch (NombreNoEstablecidoException noEs)
            {
                Console.WriteLine(noEs.Message);
            }
            catch (PrecioNoEstablecidoException pNo)
            {
                Console.WriteLine(pNo.Message);
            }
            catch (NumeroNegativoException negativo)
            {
                Console.WriteLine(negativo.Message);
            }
            catch (Exception final)
            {
                Console.WriteLine(final.Message);
            }

        }

        private static void MostrarProducto(Producto articulo)
        {
            Console.WriteLine(articulo.ToString());
        }
    }
}