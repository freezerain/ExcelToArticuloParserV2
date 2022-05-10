using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ExcelToArticuloParserV2.BackgroundWorker
{
    public class ExcelParser
    {
        private SharedStringTable _stringTable;
        private List<Row> _rows;
        public ExcelParser(string filePath)
        {
            using (SpreadsheetDocument ssd = SpreadsheetDocument.Open(filePath, false))
            {
                _stringTable = ssd.WorkbookPart.SharedStringTablePart.SharedStringTable;
                var sheetId = ssd.WorkbookPart.Workbook.Descendants<Sheet>().First().Id;
                WorksheetPart wsp = ssd.WorkbookPart.GetPartById(sheetId) as WorksheetPart;
                _rows = wsp.Worksheet.Elements<SheetData>().First().Elements<Row>().ToList();
                /*
                _rows = ssd.WorkbookPart.WorksheetParts.First()
                    .Worksheet.Elements<SheetData>().First().Elements<Row>().ToList();
                    */
                ValidateHeaders();
            }
        }

        public async Task<List<ArticleDTO>> GetArticleListAsync(CancellationToken token)
        {
            return await Task.FromResult(_rows.Skip(1).AsParallel().AsOrdered().WithCancellation(token).Select<Row, ArticleDTO>(r => ParseRowToArticleDTO(r))
                .ToList());
        }

        public List<ArticleDTO> GetArticleList()
        {
            return _rows.Skip(1).Select<Row, ArticleDTO>(r => ParseRowToArticleDTO(r)).ToList();
        }

        private void ValidateHeaders()
        {
            List<Cell> headerCells = _rows.First().Elements<Cell>().ToList<Cell>();
            if (headerCells.Count < 5) throw new FormatException("Header row is shorter then 5 columns");
            else if (!GetCellValue(headerCells[0]).Equals("CodArt", StringComparison.OrdinalIgnoreCase))
                throw new FormatException("First column should be \"Codart\"");
            else if (!GetCellValue(headerCells[1]).Equals("DescArt", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Second column should be \"DescArt\"");
            else if (!GetCellValue(headerCells[2]).Equals("PrcVenta", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Third column should be \"PrcVenta\"");
            else if (!GetCellValue(headerCells[3]).Equals("PrcCompra", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Fourth column should be \"PrcCompra\"");
            else if (!GetCellValue(headerCells[4]).Equals("TipIva", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Fivth column should be \"TipIva\"");
        }

        private string GetCellValue(Cell cell)
        {
            if (cell == null || cell.CellValue == null || cell.CellValue.InnerText == null) return null;
            string value = cell.CellValue.InnerText;
            if (_stringTable != null && cell.DataType != null
                && cell.DataType.Value == CellValues.SharedString)
                return _stringTable.ChildElements[(Int32.Parse(value))].InnerText;
            else return value;
        }

        private ArticleDTO ParseRowToArticleDTO(Row r) 
        {
            try
            {
                int rowIndex = -1;
                string CodArt = "";
                string DescArt = "";
                string PrcVenta = "";
                string PrcCompra = "";
                string TipIva = "ORD21";
                List<Cell> cells = r.Elements<Cell>().ToList<Cell>();
                foreach (Cell cell in cells)
                {
                    string cellReference = cell.CellReference.ToString().ToLower();
                    // converting char to ASCII int value
                    if (rowIndex < 0) rowIndex = Int32.Parse(Regex.Replace(cellReference, @"[^\d]", ""));
                    int columnIndex = Regex.Replace(cellReference, @"[\d]*", "").ToCharArray().First() - 97;
                    string value = GetCellValue(cell);
                    switch (columnIndex)
                    {
                        case 0:
                            CodArt = value;
                            break;
                        case 1:
                            DescArt = value;
                            break;
                        case 2:
                            PrcVenta = value;
                            break;
                        case 3:
                            PrcCompra = value;
                            break;
                        case 4:
                            TipIva = value;
                            break;
                    }
                }
                var article = new ArticleDTO(rowIndex, CodArt, DescArt, PrcVenta, PrcCompra, TipIva);
                if (String.IsNullOrEmpty(CodArt)
                || String.IsNullOrEmpty(DescArt)
                || String.IsNullOrEmpty(PrcVenta))
                    article.ArticleStatus = ArticleDTO.ArticleStatusEnum.FORMAT_ERROR;
                return article;
            }
            catch { return new ArticleDTO(); }
        }

    }
}
