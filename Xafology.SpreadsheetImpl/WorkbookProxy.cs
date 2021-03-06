﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace Xafology.SpreadsheetImpl
{
    public class WorkbookProxy : Xafology.Spreadsheet.IWorkbook, IDisposable
    {
        private readonly ExcelPackage _package;

        public WorkbookProxy(Stream stream)
        {
            _package = new ExcelPackage(stream);
        }

        public Xafology.Spreadsheet.IWorksheet GetWorksheet(string sheetName)
        {
            var ws = _package.Workbook.Worksheets[sheetName];
            var wsProxy = new Xafology.SpreadsheetImpl.WorksheetProxy(ws);
            return wsProxy;
        }

        public Stream Stream
        {
            get { return _package.Stream; }
        }

        public void Save()
        {
            _package.Save();
        }

        public void Dispose()
        {
            if (_package != null)
            _package.Dispose();
        }
    }
}
