using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Microsoft.AspNetCore.Hosting.Internal;

namespace MySaving.ExecuteReport.MTS.XML
{
    public class XmlToDraft
    {

        public List<SpecificationString> columsMts;
        public List<SpecificationString> ResultXmlToList()
        {
            //читаем документ xml
            XDocument xd = XDocument.Load(HostingEnvironment.MapPath("~/Files/MTSDet.xml"));
            //создаем список тип которого будет ColumsListMts
            //и создаем linq запрос отбирающий необходимые атрибуты из элемента i
            columsMts = xd.Root.Descendants("i").Where(x => x.Attribute("s").Value == "sms i" || x.Attribute("s").Value == "Телеф." || x.Attribute("s").Value == "HSDPA (3G)").Select(x => new SpecificationString
            {
                Number = x.Attribute("n").Value,
                Date = x.Attribute("d").Value,
                Service = x.Attribute("s").Value,
                Duration = x.Attribute("du").Value
            }).ToList();
            return columsMts;
        }
    }
}
