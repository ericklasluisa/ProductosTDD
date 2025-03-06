using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosTDD.Data;
using ProductosTDD.Models;

namespace ProductosTDD.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidosDataAccessLayer _pedidoDAL = new PedidosDataAccessLayer();

        public IActionResult Index()
        {
            List<Pedido> pedidos = _pedidoDAL.GetAllPedidos().ToList();
            return View(pedidos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Pedido objPedido)
        {
            if (ModelState.IsValid)
            {
                _pedidoDAL.AddPedido(objPedido);
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public IActionResult Edit(int id)
        {
            Pedido pedido = _pedidoDAL.GetAllPedidos().FirstOrDefault(p => p.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Pedido objPedido)
        {
            if (id != objPedido.PedidoID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _pedidoDAL.UpdatePedido(objPedido);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al actualizar el pedido: " + ex.Message);
                }
            }
            return View(objPedido);
        }

        public IActionResult Delete(int id)
        {
            Pedido pedido = _pedidoDAL.GetAllPedidos().FirstOrDefault(p => p.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_pedidoDAL.DeletePedido(id))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error al eliminar el pedido.");
            return View();
        }
    }
}
