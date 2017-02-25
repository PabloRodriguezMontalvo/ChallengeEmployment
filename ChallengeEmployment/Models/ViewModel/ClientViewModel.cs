using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ChallengeEmployment.CustomValidations;
using Newtonsoft.Json;

namespace ChallengeEmployment.Models.ViewModel
{
    public class ClientViewModel: IViewModel<Clients>

    {
        public int id { get; set; }
    
        [Required]
        [DNIValidation(ErrorMessage = "DNI incorrecto")]
      //Usaría un diccionario en lugar de poner literales en los textos
        public string DNI { get; set; }
        [Required]
    
        public string Name { get; set; }
        [Required]
    
        public string Surname { get; set; }
        [Required]
  
        public string Country { get; set; }
   
        [Required]
     
        [EmailAddress(ErrorMessage = "Dirección de correo incorrecta")]
        public string Email { get; set; }
        [Required]
      
        public DateTime Birthday { get; set; }
        [Required]
       
        [DataType(DataType.PhoneNumber)]
      
        public int Tel { get; set; }

        public string CompanyName { get; set; }
        [TwitterValidation(ErrorMessage = "Falta el caracter @")]
        public string Twitter { get; set; }
        
        public string Interest { get; set; }
        public string Genre { get; set; }

        public Clients ToBaseDatos()
        {
            var datos = new Clients()
            {
                id = id,
                Name = Name,
                Surname = Surname,
                Country = Country,
                Birthday= Birthday,
                Email= Email,
                DNI = DNI,
                Tel = Tel,
                CompanyName = CompanyName,
                Twitter = Twitter,
                Interest = Interest,
                Genre = Genre
               

            };
            return datos;
        }

        public void FromBaseDatos(Clients modelo)
        {
            id = modelo.id;
            Name = modelo.Name;
            Surname = modelo.Surname;
            Country = modelo.Country;
            Birthday = modelo.Birthday;
            Email = modelo.Email;
            Tel = modelo.Tel;
            DNI = modelo.DNI;
            CompanyName = modelo.CompanyName;
            Twitter = modelo.Twitter;
            Interest = modelo.Interest;
            Genre = modelo.Genre;
        }

        public void UpdateBaseDatos(Clients modelo)
        {

            modelo.id = id;
            modelo.Name = Name;
            modelo.Surname = Surname;
            modelo.Country = Country;
            modelo.Email = Email;
            modelo.DNI = DNI;
            modelo.Tel = Tel;
            modelo.CompanyName = CompanyName;
            modelo.Twitter = Twitter;
            modelo.Interest = Interest;
            modelo.Genre = Genre;
        }

        public object[] GetKeys()
        {
                return new[] { (object)id };
            
        }
    }
}