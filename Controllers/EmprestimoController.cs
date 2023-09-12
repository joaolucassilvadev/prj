
using Microsoft.AspNetCore.Mvc;
using prj.data;
using prj.Models;
using System.Data;
using OfficeOpenXml;
using System.Data;


namespace prj.Controllers
{
    public class EmprestimoController : Controller

    { readonly private ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {


            return View();

        }


        public IActionResult Ambulatorio()
        {

            IEnumerable<EmprestimoModel> emprestimos = _db.Emprestimo;
            return View(emprestimos);
        }

        public IActionResult Cadastra()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Editar(int? id)
        {

            EmprestimoModel emprestimo=_db.Emprestimo.FirstOrDefault(X =>X.Id == id);

            return View(emprestimo);
        }
        [HttpGet]

        public IActionResult Excluir(int? id)
        {
            EmprestimoModel emprestimo= _db.Emprestimo.FirstOrDefault(x => x.Id == id);
            return View(emprestimo);
        }

      

        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModel emprestimos)
        {

            _db.Emprestimo.Add(emprestimos);
            _db.SaveChanges();

            return RedirectToAction("Ambulatorio");

        }

        [HttpPost]

        public IActionResult Editar(EmprestimoModel emprestimo)
        {

            if (ModelState.IsValid)
            {
                _db.Emprestimo.Update(emprestimo);
                _db.SaveChanges();
                return RedirectToAction("Ambulatorio");
            }

            

            return View(emprestimo);
        }

        [HttpPost]

        public IActionResult Excluir(EmprestimoModel emprestimo)
        {
            _db.Emprestimo.Remove(emprestimo);
            _db.SaveChanges();

            return RedirectToAction("Ambulatorio");
        }



        public IActionResult ExportarParaExcel()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DataTable dataTable = GetDataTable(); // Obtenha os dados que deseja exportar

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
            dataTable.Columns.Add("Setor");
            dataTable.Columns.Add("CH");
            dataTable.Columns.Add("RH Real");
            dataTable.Columns.Add("RH Ideal");
            dataTable.Columns.Add("Comparativo");
        
            var data = _db.Emprestimo.ToList(); 

            foreach (var item in data)
            {
                dataTable.Rows.Add(item.setor, item.ch, item.rhreal, item.rhideal, item.comporativo); // Adicione as linhas com os dados
            }

            return dataTable;
        }
    }

}



