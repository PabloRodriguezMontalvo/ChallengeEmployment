using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ChallengeEmployment.Models.ViewModel;
using ChallengeEmployment.UnitofWork;


namespace ChallengeEmployment.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork uow = null;
        public HomeController(): this(new UnitOfWork())
         {

        }
        public HomeController(UnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var users = uow.RepoClient.Get().ToList();

                return View(users);
            }
        }


        public ActionResult Details(int id)
        {
         
                var users = uow.RepoClient.Get(id);
                return View(users);
         

        }

        //
        // GET: /Usuarios/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuarios/Create

        [HttpPost]
        public ActionResult Create(ClientViewModel NewClient)
        {
            try
            {
          
                    uow.RepoClient.Add(NewClient);
                uow.Commit();
            

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    
        public async Task<ActionResult> MoreDetails(int id)
        {
            var user = uow.RepoClient.Get(id);
            var link = "http://localhost:51935/Home/EditAdvanced/" + user.DNI;
            var body = "<p>Email From: Sistema</p><p>Message:</p><p>Por favor, entre en este link: "+link+"</p>";
            var message = new MailMessage();
        
            message.To.Add(new MailAddress(user.Email));  
            message.From = new MailAddress("algun_correo@valido.com");  
            message.Subject = "Se requieren más datos tuyos";
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "algun_correo@valido.com", 
                    Password = "password" 
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com"; //Hosting que se use
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Sent");

            }
        }

        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {

            var users = uow.RepoClient.Get(id);
            return View(users);

        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        public ActionResult EditAdvanced(int id, ClientViewModel Client)
        {
            try
            {

                uow.RepoClient.Actualizar(Client);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Usuarios/Edit/5

        public ActionResult EditAdvanced(string dni)
        {
            // Usamos DNI obviamente para meter "algo" de seguridad y no una simple ID
         
                   var users = uow.RepoClient.Get().First(o => o.DNI==dni);
            ViewBag.G = LoadComboSex(users.Genre);
            ViewBag.I = LoadComboInterests(users.Interest);

            return View(users);
          
        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, ClientViewModel Client)
        {
            try
            {

                uow.RepoClient.Actualizar(Client);
            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuarios/Delete/5

        public ActionResult Delete(int id)
        {
          
                var user = uow.RepoClient.Get(id);
                return View(user);
          
        }

        //
        // POST: /Usuarios/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, ClientViewModel client)
        {
            try
            {


                uow.RepoClient.Borrar(client);
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private SelectList LoadComboSex(string valorSeleccionado)
        {
            var datosCombo = new List<string>();
            datosCombo.Add("H");
            datosCombo.Add("M");
            datosCombo.Add("Otros");

            //   datosCombo.Add(new EstadoViewModel { id = -1, descripcion = "-Selecciona Perfil-" });

            //datosCombo = datosCombo.OrderBy(o => o.id).ToList();

            var combo = new SelectList(datosCombo, valorSeleccionado);


            return combo;
        }
        private SelectList LoadComboInterests(string valorSeleccionado)
        {
            var datosCombo = new List<string>();
            datosCombo.Add("Deportes");
            datosCombo.Add("Literatura");
            datosCombo.Add("Cine");
            datosCombo.Add("Juegos");
            datosCombo.Add("Formación");

            //   datosCombo.Add(new EstadoViewModel { id = -1, descripcion = "-Selecciona Perfil-" });

            //datosCombo = datosCombo.OrderBy(o => o.id).ToList();

            var combo = new SelectList(datosCombo, valorSeleccionado);


            return combo;
        }
    }
}