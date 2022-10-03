using intcomexapp.Datos;
using intcomexapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace intcomexapp.Controllers
{
    public class ContactosController : Controller
    {
        private readonly appDbContext context;

        public ContactosController(appDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            Contacto contacto = new Contacto();
            List<itemList> tipos = new List<itemList>();

            tipos = buildSelect();
            ViewBag.tipos = tipos;

            contacto.codigoCliente = generarCodigo();                          

            return View(contacto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if(ModelState.IsValid){

                contacto.contraseña = generarContraseña(); 

                context.contactos.Add(contacto);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            // todo: vista Error.cshtml para retornar cualquier excepcion
            return RedirectToAction("Index");
        }

        private string generarCodigo(){
            return "xmxwebdemo2";
        }

        private List<itemList> buildSelect(){
            List<itemList> tipos = new List<itemList>();

            var zero = new itemList();
            zero.value = "0";
            zero.text = "-Seleccione Tipo de Contacto-";
            tipos.Add(zero);

            var primero = new itemList();
            primero.value = "1";
            primero.text = "Contacto Comercial";
            tipos.Add(primero);

            var segundo = new itemList();
            segundo.value = "2";
            segundo.text = "Pago de factura";
            tipos.Add(segundo);

            var tercero = new itemList();
            tercero.value = "3";
            tercero.text = "Representante legal";
            tipos.Add(tercero);

            var cuarto = new itemList();
            cuarto.value = "4";
            cuarto.text = "Retiro de mercadería";
            tipos.Add(cuarto);

            return tipos;
        }
    
        private string generarContraseña(){
            string respuesta = string.Empty;

            // de donde vamos a tomar los caracteres
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // donde se va a capturar el valor
            var Charsarr = new char[4];

            // para tomar valores ramdom
            var random = new Random();

            // creando el valor ramdom de texto
            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            // resultado del randon en texto
            var resultString = new String(Charsarr);

            // segundo objeto randon
            Random rnd = new Random();

            // tomar un vamor numerico del rango estipulado
            double secondPart = rnd.Next(9999);

            // concatenamos
            respuesta = resultString + Convert.ToString(secondPart);

            return respuesta;
        }
    }
}