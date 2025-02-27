using Microsoft.AspNetCore.Mvc;
using ProductosTDD.Data;
using ProductosTDD.Models;

namespace ProductosTDD.Controllers
{
    public class ClienteController : Controller
    {

        ClienteDataAccessLayer objClienteDAL = new ClienteDataAccessLayer();
        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objClienteDAL.getAllCliente().ToList();
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente objCliente)
        {
            if (ModelState.IsValid)
            {
                objClienteDAL.AddClient(objCliente);
                return RedirectToAction("Index");
            }
            return View("Crear");
        }

        public IActionResult Edit(int id)
        {
            Cliente cliente = objClienteDAL.getAllCliente().FirstOrDefault(c => c.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Cliente objCliente)
        {
            if (id != objCliente.Codigo)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    objClienteDAL.UpdateClient(objCliente);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al actualizar el cliente: " + ex.Message);
                }
            }
            return View(objCliente);
        }

        // GET: Cliente/Delete/5
        public IActionResult Delete(int id)
        {
            Cliente cliente = objClienteDAL.getAllCliente().FirstOrDefault(c => c.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (objClienteDAL.DeleteClient(id))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error al eliminar el cliente.");
            return View();
        }

    }

}
