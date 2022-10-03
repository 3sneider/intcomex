using System.ComponentModel.DataAnnotations;

namespace intcomexapp.Models
{
    public class Contacto
    {        
        [Display(Name = "Código de cliente")] 
        public string codigoCliente { get; set; }

        [Required]
        [Display(Name = "Usuario")]         
        public string usuario { get; set; }

        [Required]
        [Display(Name = "Nombre", Prompt = "Nombre: *")] 
        [StringLength(maximumLength:6, ErrorMessage = "el campo {0} debe tener un tamaño maximo de {1}")]        
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Cargo", Prompt = "Cargo: *")] 
        public string cargo { get; set; }

        [Required]
        [Display(Name = "Teléfono", Prompt = "Teléfono: *")] 
        public string telefono { get; set; }
                
        [Required]
        [Display(Name = "Correo Electrónico", Prompt = "Correo Electrónico: *")] 
        [EmailAddress]
        public string email { get; set;}

        [Required]
        [Display(Name = "Número celular", Prompt = "Número celular: *")] 
        public string celular {get; set;}

        [Required]
        [Display(Name = "Tipo de contacto")] 
        public int tipoContacto { get; set; }
        
        public string contraseña { get; set; }

        [Display(Name = "Autorizado para accedes a WebStore")] 
        public bool autorizaWebStore { get; set; }

        [Display(Name = "Autorizado para crear ordenes")] 
        public bool autorizaCrearOrdenes { get; set; }

        [Display(Name = "¿ Desea que se envie la informacion de acceso al usuario ?")] 
        public bool envioInformacion { get; set; }
    }

    public class itemList {
        public string value { get; set; }

        public string text { get; set; }
    }
}