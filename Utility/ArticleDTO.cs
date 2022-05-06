using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToArticuloParserV2
{
    public class ArticleDTO
    {
        public int Fila { get; set; }
        public string CodArt { get; set; }
        public string DescArt { get; set; }
        public string PrcVenta { get; set; }
        public string PrcCompra { get; set; }
        public string TipIva { get; set; }
        public ArticleStatusEnum ArticleStatus { get; set; }

        public ArticleDTO(int fila, string codArt, string descArt, string prcVenta, string prcCompra, string tipIva)
        {
            this.Fila = fila;
            this.CodArt = codArt;
            this.DescArt = descArt;
            this.PrcVenta = prcVenta;
            this.PrcCompra = prcCompra;
            this.TipIva = tipIva;
            this.ArticleStatus = ArticleStatusEnum.WAITING;
        }

        public ArticleDTO() : this(-1, "", "", "", "", "")
        {
            ArticleStatus = ArticleStatusEnum.FORMAT_ERROR;
        }

        public enum ArticleStatusEnum
        {
            WAITING,
            CREATED,
            UPDATED,
            UPLOAD_ERROR,
            FORMAT_ERROR
        }

    }
}
