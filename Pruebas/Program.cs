using LibreriaClaseProducto;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //PRUEBA 1 -- Prueba sobre objetos de la clase Producto
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

            //PRUEBA 2 --
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
            finally
            {

            }
            //PRUEBA 3 -- Bebida



        }

        private static void MostrarProducto(Producto articulo)
        {
            Console.WriteLine(articulo.ToString());
        }
    }
}