using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace GC_Automatic_ToolKit.Handler
{
    public class ExcelHandle
    {
        private string _path, _filename;
        private Application _app;
        private Workbook _workbook;
        private Worksheet _worksheet;

        public ExcelHandle()
        {
            _path = Path.GetTempPath();
            _filename = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }
        public ExcelHandle(string path,string filename)
        {
            this._path = path;
            _filename = CheckFileName(filename);
        }

        private string CheckFileName(string filename)
        {
            if (filename == null) return null;
            for(var i=0;i<100;i++)
            {
                if (File.Exists(string.Concat(_path,filename,".xlsx")))
                { filename = string.Concat(filename, "_GC"); }
                else { break; }
            }
            return filename;
        }

        public void CreateExcel()
        {
            var nothing = Missing.Value;
            _app = new Application {Visible = true};
            _workbook = _app.Workbooks.Add(nothing);
            _worksheet = (Worksheet)_workbook.Sheets[1];
            _worksheet.Name = DateTime.Today.ToString("yyyy.MM.dd");
        }

        public void CreateExcel(String worksheetName)
        {
            CreateExcel();
            _worksheet.Name = @"Config";

            String[] title = {"No","周期", "运行次数", "下次运行前等待时间", "进入下一阶段前等待时间" };

            for(int col = 1; col <= title.Length; col++)
            {
                _worksheet.Cells[1, col] = title[col - 1];
            }
        }

        public void SaveExcel()
        {
            //workbook.SaveAs(String.Concat(path, filename, ".xlsx"));
        }

        public void CloseExcel(bool i)
        {
            if (i)  { SaveExcel(); }
            _worksheet = null;
            _workbook = null;
            _app.Quit();
            _app = null;
        }

        public void AddStringDoublePair(IEnumerable<KeyValuePair<string, double>> pair,int x,int y)
        {
            _worksheet.Cells[x, y++] = DateTime.Now;
            foreach(var data in pair)
            {
                _worksheet.Cells[x, y++] = data.Value;
            }
        }
    }
}
