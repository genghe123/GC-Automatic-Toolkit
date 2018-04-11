using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace GC_Automatic_ToolKit
{
    public class ExcelHandle
    {
        private string path, filename;
        private Application app;
        private Workbook workbook;
        private Worksheet worksheet;

        public Worksheet Worksheet { get => worksheet; }
        public Workbook Workbook { get => workbook; }

        public ExcelHandle()
        {
            path = Path.GetTempPath();
            filename = DateTime.Now.ToString();
        }
        public ExcelHandle(string path,string filename)
        {
            this.path = path;
            this.filename = CheckFileName(filename);
        }

        private string CheckFileName(string filename)
        {
            string p = null;
            for(var i=0;i<100;i++)
            {
                if (File.Exists(String.Concat(path,filename,".xlsx")))
                { filename = String.Concat(filename, "_GC"); }
                else { break; }
            }
            return p;
        }

        public void CreateExcel()
        {
            var nothing = System.Reflection.Missing.Value;
            app = new Application();
            app.Visible = true;
            workbook = app.Workbooks.Add(nothing);
            worksheet = (Worksheet)workbook.Sheets[1];
            worksheet.Name = DateTime.Today.ToString("yyyy.MM.dd");
        }
        public void SaveExcel()
        {
            //workbook.SaveAs(String.Concat(path, filename, ".xlsx"));
        }

        public void CloseExcel(bool i)
        {
            if (i)  { SaveExcel(); }
            worksheet = null;
            workbook = null;
            app.Quit();
            app = null;
        }

        public void AddStringDoublePair(IEnumerable<KeyValuePair<string, double>> pair,int x,int y)
        {
            worksheet.Cells[x, y++] = DateTime.Now;
            foreach(var data in pair)
            {
                worksheet.Cells[x, y++] = data.Value;
            }
        }

    }
}
