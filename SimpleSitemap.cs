using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SitemapXML
{
    public class SimpleSitemap
    {
        public XDocument GenerateXDocument(List<string> list)
        {
            try
            {
                // inicia estrutura do arquivo xml
                XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
                XNamespace xsiNs = "http://www.w3.org/2001/XMLSchema-instance";

                XDocument xDoc = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "no"),
                    new XElement(ns + "urlset",
                    new XAttribute(XNamespace.Xmlns + "xsi", xsiNs),
                    new XAttribute(xsiNs + "schemaLocation",
                        "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd")

                ));

                AddListURLs(ns, xDoc, list);

                return xDoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // insere novos elementos <url> no documento
        private void AddListURLs(XNamespace ns, XDocument xDoc, List<string> list)
        {
            foreach (string link in list)
            {
                XElement elem = new XElement(ns + "url",
                    new XElement(ns + "loc", link),
                    new XElement(ns + "changefreq", "daily")
                );

                xDoc.Element(ns + "urlset").Add(elem);
            }

        }
    }
}