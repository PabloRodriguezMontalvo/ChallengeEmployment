using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeEmployment;
using ChallengeEmployment.Controllers;
using ChallengeEmployment.Models;
using ChallengeEmployment.Models.ViewModel;
using ChallengeEmployment.Repositorio;
using ChallengeEmployment.Tests.Dummys;
using ChallengeEmployment.UnitofWork;

namespace ChallengeEmployment.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest 
    {
        ClientViewModel User1 = null;
        ClientViewModel User2 = null;
        List<ClientViewModel> Clientes = null;
        UnitOfWork uow = null;
        DummyRepository ClientRepository = null;
        HomeController controller = null;
    
        public HomeControllerTest()
        {

            User1 = new ClientViewModel { id = 1, Name = "Pablo", Surname = "Rodriguez", DNI = "49012348S", Birthday = DateTime.Now, Country = "Spain", Email = "paulrodmont@gmail.com",Tel = 630761825};
            User2 = new ClientViewModel { id = 1, Name = "Pablo2", Surname = "Rodriguez2", DNI = "49012348T", Birthday = DateTime.Now, Country = "Spaina", Email = "pablo.rodriguez@gmail.com",Tel = 630761824};
         

            Clientes = new List<ClientViewModel>
        {
            User1,
            User2
    
        };

            ClientRepository = new DummyRepository(Clientes);

            uow = new UnitOfWork(ClientRepository);


            controller = new HomeController(uow);
        }
        [TestMethod]
        public void Index()
        {
       
            ViewResult result = controller.Index() as ViewResult;
            var model = (List<ClientViewModel>)result.ViewData.Model;
         
            CollectionAssert.Contains(model, User1);
            CollectionAssert.Contains(model, User2);

         
        }

        [TestMethod]
        public void Details()
        {
            ViewResult result = controller.Details(1) as ViewResult;

            Assert.AreEqual(result.Model, User1);
        }
        [TestMethod]
        public void Create()
        {
          
            Clients newUser = new Clients { id = 1, Name = "Pablo7", Surname = "Rodriguez7", DNI = "49012348V", Birthday = DateTime.Now, Country = "Spaina", Email = "pablo.rodriguez@gmail.com", Tel = 630761824 };

            ClientViewModel NUser= new ClientViewModel();
            NUser.FromBaseDatos(newUser);

            controller.Create(NUser);

          
            List<ClientViewModel> clientes = ClientRepository.Get().ToList();

            CollectionAssert.Contains(clientes, NUser);
        }

        [TestMethod]
        public void Edit()
        {
            ViewResult result = controller.Edit(1) as ViewResult;


            Assert.AreEqual(result.Model, User1);
        }
    }
}
