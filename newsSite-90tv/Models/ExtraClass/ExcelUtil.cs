using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.XlsIO;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.PublicClass;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.Services;

namespace newsSite90tv.Models.ExtraClass
{
    public class ExcelUtil : IExcelUtil
    {

        private  readonly IUnitOfWork _context;

        public ExcelUtil(IUnitOfWork context)
        {
            _context = context;
        }


         
        public  async Task<FileStreamResult> CreateExcel(List<PayaModel> model)
        {
            long totalprice = 0;
            int row = 2;

            var adminbank = await _context.AppsettingRepositoryUW.GetSingleAsync();

            //Create an instance of ExcelEngine
            try
            {
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;

                    application.DefaultVersion = ExcelVersion.Excel2016;
                    IWorkbook workbook = application.Workbooks.Create(3);


                    IWorksheet worksheetheader = workbook.Worksheets[0];
                    worksheetheader.Name = "GrpHdr";

                    IWorksheet worksheetmid = workbook.Worksheets[1];
                    worksheetmid.Name = "PmtInf";

                    IWorksheet worksheetcontent = workbook.Worksheets[2];
                    worksheetcontent.Name = "CdtTrfTxInf";



                    // content page of transaction 
                    worksheetcontent.Range["A1"].Text = "InstrId";
                    worksheetcontent.Range["B1"].Text = "EndToEndId";
                    worksheetcontent.Range["C1"].Text = "Amt";
                    worksheetcontent.Range["D1"].Text = "Cdtr";
                    worksheetcontent.Range["E1"].Text = "CdtrAcct";
                    worksheetcontent.Range["F1"].Text = "RmtInf";


                    for (int i = 0; i < model.Count; i++)
                    {
                        worksheetcontent.Range["A" + row].Text = "Empty";
                        worksheetcontent.Range["B" + row].Text = "Empty";
                        worksheetcontent.Range["C" + row].Number = model[i].amount;
                        worksheetcontent.Range["D" + row].Text =  model[i].name;
                        worksheetcontent.Range["E" + row].Text = model[i].shabaNom;
                        worksheetcontent.Range["F" + row].Text = "فروش محصول";

                        row++;

                        totalprice += model[i].amount;
                    }

                    //end content


                    // make headrrt page
                    worksheetheader.Range["A1"].Text = "MsgId";
                    worksheetheader.Range["B1"].Text = "CreDtTm";
                    worksheetheader.Range["C1"].Text = "NbOfTxs";
                    worksheetheader.Range["D1"].Text = "CtrlSum";
                    worksheetheader.Range["E1"].Text = "InitgPty";


                    worksheetheader.Range["A2"].Text = adminbank.shabacode;
                    worksheetheader.Range["B2"].Text = Utility.Payadateformat();
                    worksheetheader.Range["C2"].Number = model.Count();
                    worksheetheader.Range["D2"].Number = totalprice;
                    worksheetheader.Range["E2"].Text = adminbank.ownername;

                    // end header


                    //middle page
                    worksheetmid.Range["A1"].Text = "PmtInfId";
                    worksheetmid.Range["B1"].Text = "PmtMtd";
                    worksheetmid.Range["C1"].Text = "NbOfTxs";
                    worksheetmid.Range["D1"].Text = "CtrlSum";
                    worksheetmid.Range["E1"].Text = "ReqdExctnDt";
                    worksheetmid.Range["F1"].Text = "Dbtr";
                    worksheetmid.Range["G1"].Text = "DbtrAcct";
                    worksheetmid.Range["H1"].Text = "DbtrAgt";


                    worksheetmid.Range["A2"].Text = "1";
                    worksheetmid.Range["B2"].Text = "TRF";
                    worksheetmid.Range["C2"].Number = model.Count();
                    worksheetmid.Range["D2"].Number = totalprice;
                    worksheetmid.Range["E2"].Text = DateAndTimeShamsi.DateTimeShamsiPayaFormat();
                    worksheetmid.Range["F2"].Text = adminbank.ownername;
                    worksheetmid.Range["G2"].Text = adminbank.shabacode;
                    worksheetmid.Range["H2"].Text = "test";


                    //end middle









                    //Saving the Excel to the MemoryStream 
                    MemoryStream stream = new MemoryStream();

                    workbook.SaveAs(stream);

                    //Set the position as '0'.
                    stream.Position = 0;

                    //Download the Excel file in the browser
                    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/excel");

                    fileStreamResult.FileDownloadName = "payabank.xls";


                    return fileStreamResult;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



       
    }
}
