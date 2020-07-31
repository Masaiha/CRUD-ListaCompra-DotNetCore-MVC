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
    public class ProdutosController : Controller
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;

        public ProdutosController(ICompraRepository compraRepository,
                                 IProdutoRepository produtoRepository,
                                 IEmpresaRepository empresaRepository,
                                 ICompraService compraService,
                                 IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _compraRepository = compraRepository;
            _compraService = compraService;
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var produtoViewModel = _mapper.Map<IEnumerable<ProdutoViewComponent>>(await _produtoRepository.ObterTodos());
            return View(produtoViewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewComponent = _mapper.Map<ProdutoViewComponent>(await _produtoRepository.ObterPorId(id));

            return View(produtoViewComponent);
        }

        public async Task<IActionResult> Create()
        {
            var compras = _mapper.Map<IEnumerable<CompraViewComponent>>(await _compraRepository.ObterTodos());

            if (compras == null) return NotFound();

            return View(new ProdutoViewComponent { Compras = compras });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewComponent produtoViewComponent)
        {
            if (!ModelState.IsValid) return View(produtoViewComponent);

            var produto = _mapper.Map<Produto>(produtoViewComponent);
            await _produtoRepository.Adicionar(produto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewComponent = _mapper.Map<ProdutoViewComponent>(await _produtoRepository.ObterPorId(id));
            var compra = _mapper.Map<CompraViewComponent>(await _compraRepository.ObterPorId(produtoViewComponent.CompraId));

            if (compra == null) return NotFound();

            produtoViewComponent.Compra = compra;

            return View(produtoViewComponent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewComponent produtoViewComponent)
        {
            if (id != produtoViewComponent.Id) return NotFound();

            if (!ModelState.IsValid) return View(produtoViewComponent);

            await _produtoRepository.Atualizar(_mapper.Map<Produto>(produtoViewComponent));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var produtoViewComponent = _mapper.Map<ProdutoViewComponent>(await _produtoRepository.ObterPorId(id));

            return View(produtoViewComponent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            if (produto == null) NotFound();

            await _produtoRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }      
    }
}
