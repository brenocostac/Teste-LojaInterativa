using LojaInterativa.Models.ViewModel;
using LojaInterativa.Models;
using LojaInterativa.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaInterativa.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly FabricanteService _fabricanteService;

        public ProdutosController(ProdutoService produtoService, FabricanteService fabricanteService)
        {
            _produtoService = produtoService;
            _fabricanteService = fabricanteService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _produtoService.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var fabricantes = await _fabricanteService.FindAllAsync();
            var viewModel = new ProdutoFormViewModel { Fabricantes = fabricantes };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {

            await _produtoService.InsertAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _produtoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Produto produto)
        {

            await _produtoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var obj = await _produtoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Fabricante> fabricantes = await _fabricanteService.FindAllAsync();
            ProdutoFormViewModel viewModel = new ProdutoFormViewModel { Produto = obj, Fabricantes = fabricantes };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _produtoService.UpdateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
