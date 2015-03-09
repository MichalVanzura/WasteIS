using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteIS.DAL;
using WasteIS.Models;

namespace WasteIS.Controllers
{
    public class ImportController : Controller
    {
        private WasteISContext db = new WasteISContext();

        // GET: Import
        public ActionResult ZujOrp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ZujOrp(HttpPostedFileBase file)
        {
            string extension = Path.GetExtension(file.FileName);

            if (file != null && file.ContentLength > 0 && file.ContentType == "application/vnd.ms-excel" || file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                IExcelDataReader reader;

                if (extension == ".xlsx")
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
                }
                else
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(file.InputStream);
                }

                reader.IsFirstRowAsColumnNames = false;

                Dictionary<Orp, HashSet<Zuj>> data = new Dictionary<Orp, HashSet<Zuj>>();

                var count = 0;
                while (reader.Read())
                {
                    try
                    {
                        count++;
                        Orp orp = new Orp
                        {
                            Name = reader.GetString(2),
                            ORP = reader.GetInt32(3),
                        };

                        if (!data.ContainsKey(orp)) 
                        {
                            data.Add(orp, new HashSet<Zuj>());
                        }

                        Zuj zuj = new Zuj
                        {
                            City = reader.GetString(0),
                            ZUJ = reader.GetInt32(1),
                        };

                        data[orp].Add(zuj);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                reader.Close();

                var orps = data.Select(o => o.Key.ORP);
                var orpsInDb = db.Orps
                    .Where(o => orps.Contains(o.ORP))
                    .ToList(); // single DB query

                foreach (var orp in data)
                {
                    var orpInDb = orpsInDb
                        .SingleOrDefault(o => o.ORP == orp.Key.ORP);
                    if (orpInDb == null)
                    {
                        db.Orps.Add(orp.Key);
                    }
                    //foreach (var zuj in orp.Value)
                    //{
                    //    zuj.Orp = orp.Key;
                    //    db.Zujs.Add(zuj);
                    //}
                }
                db.SaveChanges();

            }

            return RedirectToAction("ZujOrp");
        }
    }
}