using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Services.Graficos;

namespace SistemaEstoque.Controllers
{
    public class GraficoController : Controller
    {
        private readonly IGraficoInterface _graficoInterface;

        public GraficoController(IGraficoInterface graficoInterface)
        {
            _graficoInterface = graficoInterface;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ProdutosMenorEstoque(int limite = 3)
        {
            var dados = _graficoInterface.ObterProdutosComMenorEstoque(limite);
            return Json(dados);
        }

        [HttpGet]
        public JsonResult EntradasVsSaidasPorMes()
        {
            var dados = _graficoInterface.ObterEntradasVsSaidasPorMes();
            return Json(dados);
        }

        [HttpGet]
        public JsonResult MovimentacoesPorPeriodo(DateTime? inicio, DateTime? fim, string tipo, int? categoriaId)
        {
            var dados = _graficoInterface.ObterMovimentacoesPorPeriodo(inicio, fim, tipo, categoriaId);
            return Json(dados);
        }
    }
}
