using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public static class Status
    {
        public const string sheduledStatus = "Запланирована";
        public const string performedStatus = "Выполняется";
        public const string notPerformedStatus = "Не выполнена";
        public const string closeStatus = "Выполнена";

        public static List<string> getStatuses(string status)
        {
            //первое знаечение статуса - текущее
            List<string> result = new List<string>() { status };

            switch (status)
            {
                case sheduledStatus: // Запланирована
                    {
                        result.Add(Status.performedStatus);
                        result.Add(Status.notPerformedStatus);
                        break;
                    }
                case performedStatus: // Выполняется
                    {
                        result.Add(Status.closeStatus);
                        break;
                    }
                case notPerformedStatus: // Не выполнена
                    {
                        break;
                    }
                case closeStatus: // Выполнена
                    {
                        break;
                    }
            }

            return result;
        }
    }
}