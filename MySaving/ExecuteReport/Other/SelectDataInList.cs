using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySaving.Models;
using MySaving.ExecuteReport.MTS.XML;

namespace MySaving.ExecuteReport.Other
{
    public class SelectDataInList
    {
        DraftToClear clearListClass = new DraftToClear();

        List<SpecificationList> resultSelect = new List<SpecificationList>();
        public List<SpecificationList> ParseSelectInList(string service, string type, DateTime dateFirst,
            DateTime dateLast)
        {
            clearListClass.TransformListInClearList();
            if (type == "Входящий/Исходящий" && service == "Все услуги")
                resultSelect = clearListClass.clearList.Where(x => (
                    x.Date >= dateFirst && x.Date <= dateLast)).Select(n => n).ToList();
            else if (type == "Входящий/Исходящий")
                resultSelect = clearListClass.clearList.Where(x => (x.Service == service &&
                    x.Date >= dateFirst && x.Date <= dateLast)).Select(n => n).ToList();
            else if (service == "Все услуги")
                resultSelect = clearListClass.clearList.Where(x => (
                    x.Date >= dateFirst && x.Date <= dateLast && x.Type == type)).Select(n => n).ToList();
            else
                resultSelect = clearListClass.clearList.Where(x => (x.Service == service &&
                        x.Date >= dateFirst && x.Date <= dateLast && x.Type == type)).Select(n => n).ToList();
            return resultSelect;

        }
    }
}