using AutoMapper;
using FileHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeNet.Interfaces.DAO;
using ValeNet.Models;
using ValeNet.ModelsImports;
using ValeNet.Util;

namespace ValeNet.Controllers
{
    public class UploadsController : Controller
    {
        private readonly IDadoDAO _dadoDAO;
        //Define uma instância de IHostingEnvironment
        private readonly IWebHostEnvironment _hostingEnvironment;
        IMapper _mapper;
        public UploadsController(IWebHostEnvironment hostingEnvironment, IDadoDAO dadoDAO, IMapper mapper)
        {
            _hostingEnvironment = hostingEnvironment;
            _dadoDAO = dadoDAO;
            _mapper = mapper;
        }

        // GET: UploadsController
        public async Task<IActionResult> Index()
        {
            var DadosDb = (await _dadoDAO.GetAllAsync()).OrderBy(x => x.NomeArquivo).ToList();
            return View(DadosDb);
        }

        // GET: UploadsController/Details/5

        // GET: UploadsController/Create
        public ActionResult Create()
        {
            List<DadosModelImports> lstDadosModelImports = new List<DadosModelImports>();
            return View(lstDadosModelImports);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile arquivo)
        {
            try
            {
                var retornoUpLoad = Arquivos.UploadedFile(arquivo, _hostingEnvironment.WebRootPath, "UpLoadDados");

                //Normatizar os dados (Teste de validações)
                var engine = new FileHelperEngine<DadosModelImports>();
                var records = engine.ReadFile(retornoUpLoad);

                var ReturnDados = _mapper.Map<List<Dado>>(records);

                //return RedirectToAction(Create, new { id = clienteUsuario.ClienteId }).WithSuccess("Sucesso! Usuário cadastrado.");

                //Gravar

                var DadosDb = await _dadoDAO.InsertListAsync(ReturnDados, retornoUpLoad);
                
                if (DadosDb.Count>0)
                {
                    // Ir para a view de sucesso passando como paramentos o Guid
                    return RedirectToAction("CreateSuccess", new { Guid = DadosDb[0].Guid.ToString() });
                }
                else
                {
                    // Ir para view de Error
                    return View("CreateFail");
                }


            }
            catch (Exception e)
            {
                return View("CreateFail");
            }
           // return View();
        }

        public async Task<IActionResult> CreateSuccess(string Guid)
        {
            if (Guid.Trim().Length<=0)
            {
                NotFound();
            }
            //Dado
            var dadosDB = await _dadoDAO.GetGuidAsync(Guid);

            return View(dadosDB);
        }


        public ActionResult CreateFail()
        {
            return View();
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            if (recordLine.Length == 0)
                return null;

            return typeof(DadosModelImports);

        }

    }
}
