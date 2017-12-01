using System;
using System.Collections.Generic;

namespace NotificationsMartinFowler.Domain.Mocks
{
    public static class Db
    {
        public static List<Policy> Policies
        {
            get
            {
                var list = new List<Policy>
                {
                    new Policy("1", new DateTime(1, 1, 2015)),
                    new Policy("2", new DateTime(1, 1, 2016)),
                    new Policy("3", new DateTime(1, 1, 2017)),
                };
                return list;
            }
        }
    }
}