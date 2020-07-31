using AutoMapper;
using Masanori.com.App.ViewModels;
using Masanori.com.Business.Interfaces.Repository;
using Masanori.com.Business.Interfaces.Services;
using Masanori.com.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masanori.com.App.Controllers
{
    public class ComprasController : Controller
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;

        public ComprasController(ICompraRepository compraRepository,
                                 IProdutoRepository produtoRepository,
                                 IEmpresaRepository empresaRepository,
                                 ICompraService compraService,
                                 IMapper mapper)
        {
            _compraRepository = compraRepository;
            _compraService = compraService;
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var comprasViewModel = _mapper.Map<IEnumerable<CompraViewComponent>>(await _compraRepository.ObterTodasComprasEmpresas());
            return View(comprasViewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var empresaViewComponent = _mapper.Map<EmpresaViewComponent>(await _empresaRepository.ObterEmpresaPorCompra(id));
            var compraViewComponent = _mapper.Map<CompraViewComponent>(await _compraRepository.ObterPorId(id));

            compraViewComponent.Empresa = empresaViewComponent;

            if (compraViewComponent == null) return NotFound();
            
            return View(compraViewComponent);
        }

        public async Task<IActionResult> Create()
        {
            var empresas = _mapper.Map<IEnumerable<EmpresaViewComponent>>(await _compraService.ListaEmpresas());

            if (empresas == null) return NotFound();

            return View("create", new CompraViewComponent { Empresas = empresas });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompraViewComponent compraViewComponent)
        {
            if (!ModelState.IsValid) return View(compraViewComponent);

            var compra = _mapper.Map<Compra>(compraViewComponent);

            await _compraRepository.Adicionar(compra);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var compraViewModel = _mapper.Map<CompraViewComponent>(await _compraRepository.ObterPorId(id));

            return View(compraViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CompraViewComponent compraViewComponent)
        {
            if (id != compraViewComponent.Id) return NotFound();

            if (!ModelState.IsValid) return View(compraViewComponent);

            var compraAtualizada = _mapper.Map<Compra>(await _compraRepository.ObterPorId(id));
            compraAtualizada.Nome = compraViewComponent.Nome;
            await _compraRepository.Atualizar(compraAtualizada);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var compraViewModel = _mapper.Map<CompraViewComponent>(await _compraRepository.ObterPorId(id));

            return View(compraViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _compraRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AtualizarEmpresa()
        {
            var comprasViewModels = await _compraRepository.ObterTodasComprasEmpresas();

            if (comprasViewModels == null)
            {
                return NotFound();
            }

            return PartialView("_ListaDeEmpresas", comprasViewModels );
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarEmpresa(EmpresaViewComponent empresa)
        {
            var comprasViewModels = await _compraRepository.ObterTodasComprasEmpresas();

            if (comprasViewModels == null)
            {
                return NotFound();
            }

            return PartialView("_ListaDeEmpresas", comprasViewModels);
        }
    }
}
