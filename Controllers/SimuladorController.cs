using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using OfficeOpenXml;
using prj.data;
using prj.Models;
using System.Data;

namespace prj.Controllers
{
    public class SimuladorController : Controller
    {


        readonly private ApplicationDbContext _db;
        public SimuladorController(ApplicationDbContext db)
        {
            _db = db;
        }

      public IActionResult TabelaSimulador()
        {
            IEnumerable<SimuladorModels> simulador = _db.Simulador;
            return View(simulador);
        }

        public IActionResult Simulador()


        {
            return View();

        }

    

        [HttpPost]
         public IActionResult TabelaSimulador(SimuladorModels Simulador)
        {
          
            _db.Simulador.Add(Simulador);
            _db.SaveChanges();
            return RedirectToAction("TabelaSimulador");




        }

        [HttpGet]
        public IActionResult Excluir()
        {
            var Simulador = _db.Simulador.ToList();

            _db.Simulador.RemoveRange(Simulador);

            _db.SaveChanges(); //salva as mudanças no banco de dados

            return RedirectToAction("TabelaSimulador");
        }




        public IActionResult ExportarParaExcel()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DataTable dataTable = GetDataTable(); 

            byte[] fileContents;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Dados");
                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                fileContents = package.GetAsByteArray();
            }


            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "dados.xlsx";


            return File(fileContents, contentType, fileName);
        }



        private DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CARGO");
            dataTable.Columns.Add("SETOR");
            dataTable.Columns.Add("CATEGORIA");
            dataTable.Columns.Add("LEITOS");
            dataTable.Columns.Add("ALA");
            dataTable.Columns.Add("SALAS");
            dataTable.Columns.Add("DIMENSIONAMENTO");
            dataTable.Columns.Add("CARGA");
            dataTable.Columns.Add("ESCALA");
            dataTable.Columns.Add("EQUIPE MINIMA");
            dataTable.Columns.Add("RH MINIMO");
            dataTable.Columns.Add("RH MINIMO NOTURNO ");
            dataTable.Columns.Add("VALOR");

            var data = _db.Simulador.ToList();

            foreach (var item in data)
            {
                dataTable.Rows.Add(item.cargo, item.setor, item.categoria, item.leitos, item.ala,item.salas, item.dimensionamento, item.carga, item.escala,item.equipemin,item.rhminimo,item.rhminimoturno,item.valor );
            }

            return dataTable;
        }


    }
    }

