using AutoMapper;
using Masanori.com.App.ViewModels;
using Masanori.com.Business.Interfaces.Repository;
using Masanori.com.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masanori.com.App.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IEmpresaRepository _EmpresaRepository;
        private readonly IEnderecoRepository _EnderecoRepository;
        private readonly IMapper _Mapper;

        public EmpresasController(IEmpresaRepository empresaRepository, IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _EmpresaRepository = empresaRepository;
            _EnderecoRepository = enderecoRepository;
            _Mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_Mapper.Map<IEnumerable<EmpresaViewComponent>>(await _EmpresaRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var empresaViewModel = await ObterEmpresaEndereco(id);

            if (empresaViewModel == null) return NotFound();

            return View(empresaViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpresaViewComponent empresaViewModel)
        {
            if (!ModelState.IsValid) return View(empresaViewModel);

            var empresa = _Mapper.Map<Empresa>(empresaViewModel);

            await _EmpresaRepository.Adicionar(empresa);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var empresaViewModel = await ObterEmpresaEndereco(id);

            if (empresaViewModel == null) return NotFound();

            return View(empresaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmpresaViewComponent empresaViewModel)
        {
            if (id != empresaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(empresaViewModel);

            var empresa = _Mapper.Map<Empresa>(empresaViewModel);
            await _EmpresaRepository.Atualizar(empresa);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var empresaViewModel = await ObterEmpresaEndereco(id);

            if (empresaViewModel == null) return NotFound();

            return View(empresaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var empresaViewModel = await ObterEmpresaEndereco(id);
            if (empresaViewModel == null) return NotFound();

            await _EmpresaRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<EmpresaViewComponent> ObterEmpresaEndereco(Guid id)
        {
            return _Mapper.Map<EmpresaViewComponent>(await _EmpresaRepository.ObterEmpresaEndereco(id));
        }

        public async Task<IActionResult> ObterEndereco(Guid id)
        {
            var empresaViewComponent = await ObterEmpresaEndereco(id);

            if (empresaViewComponent == null) return NotFound();
            
            return PartialView("_DetalhesEndereco", empresaViewComponent);
        }

        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var enderecoViewComponent = _Mapper.Map<EnderecoViewComponent>(await _EnderecoRepository.ObterEnderecoPorEmpresa(id));

            if (enderecoViewComponent == null) return NotFound();
            
            return PartialView("_AtualizarEndereco", new EmpresaViewComponent { Endereco = enderecoViewComponent });
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarEndereco(EmpresaViewComponent empresaViewComponent)
        {
            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", empresaViewComponent);

            await _EnderecoRepository.Atualizar(_Mapper.Map<Endereco>(empresaViewComponent.Endereco));

            return RedirectToAction("Details", new { id = empresaViewComponent.Id });

            //var url = Url.Action("ObterEndereco", "Empresas", new { id = empresaViewComponent.Endereco.EmpresaId });
            //return Json(new { success = true, url });
        }

    }
}
