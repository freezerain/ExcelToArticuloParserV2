using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using a3ERPActiveX;

namespace ExcelToArticuloParserV2.BackgroundWorker
{
    public class DBLoader
    {
        public static void UploadToDB(BindingSource articlesBinding, Enlace enlace, IProgress<int> progress)
        {
            IList<ArticleDTO> list = articlesBinding.List.OfType<ArticleDTO>().ToList();
            for (var i = 0; i < articlesBinding.Count; i++)
            {
                progress.Report(i);
                ArticleDTO article = list[i];
                if (article.ArticleStatus != ArticleDTO.ArticleStatusEnum.WAITING &&
                    article.ArticleStatus != ArticleDTO.ArticleStatusEnum.UPLOAD_ERROR) continue;
                UploadArticle(article, enlace);
                articlesBinding.ResetItem(i);
                Thread.Sleep(1000);
            }
        }

        private static void UploadArticle(ArticleDTO article, Enlace enlace)
        {
            Maestro articleMaestro = new Maestro();
            try
            {
                article.CodArt = SearchAlternaByCodAlt(article.CodArt);
                articleMaestro.Iniciar("Articulo");
                bool isFound = articleMaestro.Buscar(article.CodArt);
                if (isFound)
                {
                    articleMaestro.Edita();
                    article.ArticleStatus = ArticleDTO.ArticleStatusEnum.UPDATED;
                }
                else
                {
                    articleMaestro.Nuevo();
                    article.ArticleStatus = ArticleDTO.ArticleStatusEnum.CREATED;
                }
                articleMaestro.AsString["CodArt"] = article.CodArt;
                articleMaestro.AsString["DescArt"] = article.DescArt;
                double prcCompra;
                double prcVenta;
                if (Double.TryParse(article.PrcCompra, out prcCompra))
                    articleMaestro.AsFloat["PrcCompra"] = prcCompra;
                if (Double.TryParse(article.PrcVenta, out prcVenta))
                    articleMaestro.AsFloat["PrcVenta"] = prcVenta;
                articleMaestro.AsString["TipIva"] = string.IsNullOrEmpty(article.TipIva) ? "ORD21" : article.TipIva;
                articleMaestro.Guarda(true);
                if (!isFound) AddToAlterna(article.CodArt);
            }
            catch (Exception e)
            {
                article.ArticleStatus = ArticleDTO.ArticleStatusEnum.UPLOAD_ERROR;
                articleMaestro.Cancelar();
            }
            finally
            {
                articleMaestro.Acabar();
            }
        }

        private static void AddToAlterna(string codArt)
        {
            Maestro alternaMaestro = new Maestro();
            try
            {
                alternaMaestro.Iniciar("Alterna");
                alternaMaestro.Nuevo();
                alternaMaestro.AsString["CodArt"] = codArt;
                alternaMaestro.AsString["CodAlt"] = codArt;
                alternaMaestro.Guarda(true);
            }
            finally
            {
                alternaMaestro.Acabar();
            }
        }

        private static string SearchAlternaByCodAlt(string codAlt)
        {
            Maestro alternaMaestro = new Maestro();
            try
            {
                alternaMaestro.Iniciar("Alterna");
                return alternaMaestro.Buscar(codAlt) ? alternaMaestro.AsString["CodArt"] : codAlt;
            }
            finally
            {
                alternaMaestro.Acabar();
            }
        }
    }
}