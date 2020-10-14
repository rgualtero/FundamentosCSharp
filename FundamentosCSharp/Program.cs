using System;
using System.IO;
using System.Text.Json;
using FundamentosCSharp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace FundamentosCSharp
{
    class Program
    {
        #region Metodo Main 
        
        static void Main(string[] args)
        {
            #region EXCEPTION
            try
            {
                var ObjCantidad = new ClassException();
                var cantidad = ObjCantidad.GetCantidad("NombreCerveza");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally, siempre ejecuta cierra Recursos");
            }
            #endregion

            #region LINQ BASICO Consultas
            //Consulta datos
            List<int> numbers = new List<int> { 1, 5, 3, 4, 2, 6, 7, 0, 9, 8 };
            var num2 = numbers.Where(d => d == 7).FirstOrDefault();
            //Console.WriteLine("Consulta " + num2);

            //Ordena datos
            var NumOrden = numbers.OrderBy(d => d);
            for(int i = 0; i<numbers.Max(); i++)
            {
                //Console.WriteLine(i);
            }

            //Suma Datos
            var NumSuma = numbers.Sum(d => d);
            //Console.WriteLine("Suma: " + NumSuma);

            //Suma Promedio
            var NumProm = numbers.Average(d => d);
            //Console.WriteLine("Suma: " + NumProm);

            //Manejo Listas de Objetos
            List<Cervezas> Objcervezas = new List<Cervezas>()
            {
                new Cervezas(){Alcohol=10, Cantidad=100, Marca="Club", Nombre="Negra"},
                new Cervezas(){Alcohol=20, Cantidad=200, Marca="Poker", Nombre="October"},
                new Cervezas(){Alcohol=30, Cantidad=300, Marca="Heineken", Nombre="Michelada"},
                new Cervezas(){Alcohol=40, Cantidad=400, Marca="Corona", Nombre="White"}
            };

            var OrdCervezas = from d in Objcervezas
                              orderby d.Marca
                              select d;
            foreach(var a in OrdCervezas)
            {
              //  Console.WriteLine($"{a.Marca} {a.Nombre}");
            }
            #endregion

            #region LINQ COMPLEJO Subconsultas

            List<Bares> bar = new List<Bares>()
            {
                new Bares("RockBar")
                {
                    BarCerveza  = new List<Cervezas>()
                    {
                        new Cervezas(){Alcohol=10, Cantidad=100, Marca="Club", Nombre="Negra"},
                        new Cervezas(){Alcohol=20, Cantidad=200, Marca="Poker", Nombre="October"},
                        new Cervezas(){Alcohol=30, Cantidad=300, Marca="Heineken", Nombre="Michelada"}
                    }
                },
                new Bares("Rockheavy")
                {
                    BarCerveza  = new List<Cervezas>()
                    {
                        new Cervezas(){Alcohol=40, Cantidad=400, Marca="Corona", Nombre="White"},
                        new Cervezas(){Alcohol=20, Cantidad=200, Marca="Poker", Nombre="October"},
                        new Cervezas(){Alcohol=30, Cantidad=300, Marca="Heineken", Nombre="Michelada"}
                    }
                },
                new Bares("RockSoft")
            };

            var Bar = (from d in bar
                       where d.BarCerveza.Where(a => a.Nombre == "October").Count() > 0
                       select d).ToList();


            var DataBar = (from d in bar
                           where d.BarCerveza.Where(a => a.Nombre == "October").Count() > 0
                           select new BaresData(d.Nombre)
                           {
                               bebidas = (from b in d.BarCerveza
                                          select new Bebidas(b.Nombre, b.Cantidad)
                                          ).ToList()
                       }).ToList();


            #endregion

            #region SERIALIZACION Objetos DESERIALIZACION Json
            {
                //Serializa objeto a Json
                Cervezas cervezas = new Cervezas(2000, "SerializaJson");
                cervezas.Marca = "Objeto a Json";
                cervezas.Alcohol = 10;                
                string MiJsonSerialize = JsonSerializer.Serialize(cervezas);

                // Crea un archivo con el objeto en formato Json en la ruta FundamentosCSharp\bin\Debug\netcoreapp2.1
                //File.WriteAllText("NombreArchivo.txt", MiJsonSerialize);
            }

            {
                //Deserializa Json a Objeto
                string MiJsonDeserialize = File.ReadAllText("NombreArchivo.txt");
                Cervezas cervezas = JsonSerializer.Deserialize<Cervezas>(MiJsonDeserialize);                
            }
            #endregion

            #region CRUD SQLConnection
            DBCerveza db = new DBCerveza();

            #region METODO POST
            {
                Cervezas cervezas = new Cervezas(25, "Cerveza POST");
                cervezas.Marca = "Cerveza Objeto cerveza";
                cervezas.Alcohol = 35;
                //db.Add(cervezas);
            }
            #endregion

            #region METODO PUT
            {
                Cervezas cervezas = new Cervezas(250, "Cerveza Edit");
                cervezas.Marca = "Cerveza Put";
                cervezas.Alcohol = 25;                
                //db.Edit(cervezas, 4);
            }
            #endregion

            #region METODO DELETE
            {
                //db.Delete(4);
            }
            #endregion

            #region METODO GET           
            var Cervezas = db.Get();
            
            foreach(var result in Cervezas)
            {
                //Console.WriteLine(result.Nombre + " " + result.Marca + " " + result.Cantidad + " " + result.Alcohol);
            }
            #endregion

            #endregion

            #region TIPOS DE DATOS

            byte bnumero = 255;             //Va desde 0 a 255 no permite negativos  1 byte
            sbyte snumero = 127;            //Va desde -128 a 127 si permite negativos 
            int inumero = -10;              //Permite numeros positivos y negativos 4 bytes
            uint unumero = 1;               //No permite numeros negativos  
            long lnumero = 100;             //Permite numeros positivos y negativos muy largos 8 bytes
            ulong ulnumero = 100;           //No permite numeros negativos muy largos 
            float fnumero = 13.8f;          //4 bytes
            double dnumero = 13.8d;         //8 bytes
            decimal denumero = 13.8m;       //16 bytes
            char cletra = 'A';              //una letra 2 byte
            string sletra = "Cadena";       //cadena de caracteres
            DateTime date = DateTime.Now;   //Tipos de fecha
            bool SioNO = true;              //Tipo Booleano
            var persona = "Ronald";         //Tipo var Toma el valor que se define a la derecha

            //Por defecto tiene un cero
            int numero = new int();
            //Console.WriteLine(numero.ToString());

            //Agregar el ? para hacerlo null
            int? NumeroVacio = null;
            //Console.WriteLine(numero.ToString());

            //Tipo Objeto            
            object Animales = 
                new { Nombre = "Animal", Tipo="Salvaje" };

            //Console.WriteLine(Animales);

            //Tipo Objeto Atributo
            var AnimalesAtributos =
                new { Nombre = "Animal", Tipo = "Salvaje" };

            //Console.WriteLine(AnimalesAtributos.Nombre);
            #endregion
            
            #region OBJETOS CLASES Y CONSTRUCTORES

            //Objeto sin Constructor eliminar el Constructor en la clase
            //Bebidas ObjBebida = new Bebidas();
            //ObjBebida.Nombre = "Agua";
            //ObjBebida.Cantidad = 5000;


            //Objeto con Constructor
            Bebidas ObjConstBebida = new Bebidas("Agua", 5000);
            ObjConstBebida.Beber(1000);
            //Console.WriteLine(ObjConstBebida.Cantidad);


            Cervezas ObjCerveza = new Cervezas(3000);
            ObjCerveza.Beber(200);
            #endregion

            #region ARREGLOS
            int[] Anumeros = new int[10] { 1,2,3,4,5,6,7,8,9,0 };
            int array = Anumeros[0];

            for(int i = 0; i < Anumeros.Length; i++)
            {
                //Console.WriteLine("Iteracion: " + i + "Valor: " + Anumeros[i]);
            }

            foreach(var num in Anumeros)
            {
                //Console.WriteLine(num);
            }
            #endregion

            #region LISTAS
            List<int> lst = new List<int>() { 1,2,3,4,5,6,7,8};
            lst.Add(9);
            lst.Add(0);
            lst.Remove(1);
            
            foreach(var num in lst)
            {
               // Console.WriteLine(num);
            }


            List<Cervezas> ObjCervezas = new List<Cervezas>() { new Cervezas(200, "Corona")};
            ObjCervezas.Add(new Cervezas(100, "Poker"));
            Cervezas ClubColombia = new Cervezas(1000, "Club Trigo");
            ObjCervezas.Add(ClubColombia);

            foreach (var cerveza in ObjCervezas)
            {
                //Console.WriteLine(cerveza.Nombre);
            }
            #endregion

            #region INTERFACES
            //Contrato que deben cumplir las clases que impementen la inteface
            //Organizar codigo, resolver multiple herencia, Base de los patrones de diseño
            var bebidaAlcoholica = new Vino(100);
            MostrarInterface(bebidaAlcoholica);
            #endregion

        }
        
        #endregion

        #region CONSUMIR SOLICITUDES SERVICIOS WEB ASYNCRONAS
        /*
    static async Task Main(string[] args)
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        HttpClient cliente = new HttpClient();


        #region Solicitud GET
        var httpResponse = await cliente.GetAsync(url);
        ServicioWEB servicio = new ServicioWEB();

        if (httpResponse.IsSuccessStatusCode)//Si codigo es 200 es exitosa la respuesta
        {
            //await nos permite hacer una espera hasta recibir todos los datos de forma completa o sino no continua.
            var resultado = await httpResponse.Content.ReadAsStringAsync();

            //En el servicio la primera letra del atributo esta minusculas id
            //Por convencion se utilizan mayusculas en los atributos de la clase (ServicioWEB) Id
            //Pero esto genera valores nulos ya que no son iguales id != Id
            //Para solucionar esto se agrega este codigo despues de la variable resultado
            var lista = JsonSerializer.Deserialize<List<ServicioWEB>>(resultado,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }
        #endregion

        #region Solicitud POST
        ServicioWEB servicioPOST = new ServicioWEB()
        {
            UserId = 1012,
            Body = "Cuerpo Post",
            Title = "Titulo Post"
        };

        var data = JsonSerializer.Serialize<ServicioWEB>(servicioPOST);
        HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var httpResponsePost = await cliente.PostAsync(url, content);

        if (httpResponsePost.IsSuccessStatusCode)
        {
            var result = await httpResponsePost.Content.ReadAsStringAsync();  //Json
            var Postresult = JsonSerializer.Deserialize<ServicioWEB>(result); //Objeto
        }
        #endregion

        #region Solicitud PUT
        string urlPut = "https://jsonplaceholder.typicode.com/posts/99";
        ServicioWEB servicioPUT = new ServicioWEB()
        {
            UserId = 1012,
            Body = "Cuerpo Post",
            Title = "Titulo Post"
        };

        var dato = JsonSerializer.Serialize<ServicioWEB>(servicioPUT);
        HttpContent contenido = new StringContent(dato, System.Text.Encoding.UTF8, "application/json");
        var httpResponsePut = await cliente.PutAsync(urlPut, contenido);

        if (httpResponsePost.IsSuccessStatusCode)
        {
            var result = await httpResponsePut.Content.ReadAsStringAsync();  //Json
            var Postresult = JsonSerializer.Deserialize<ServicioWEB>(result,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }); //Objeto
        }            
        #endregion

        #region Solicitud DELETE
        string urlDelete = "https://jsonplaceholder.typicode.com/posts/99";
        ServicioWEB servicioDelete = new ServicioWEB()
        {
            UserId = 1012,
            Body = "Cuerpo Post",
            Title = "Titulo Post"
        };

        var httpResponseDel = await cliente.DeleteAsync(urlDelete);

        if (httpResponsePost.IsSuccessStatusCode)
        {
            var result = await httpResponseDel.Content.ReadAsStringAsync();  //Json
            var Postresult = JsonSerializer.Deserialize<ServicioWEB>(result,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }); //Objeto
        }
        #endregion
    }
    */
        #endregion

        #region METODO PARA INTERFACE
        static void MostrarInterface(IBebidaAlcoholica bebida)
        {
            bebida.ConsumoMax();
        }
        #endregion
    }
}
