using System;
using System.Collections.Generic;

namespace NotificationMartinFowler.Domain.Mocks
{
    public static class Db
    {
        public static List<Policy> Policies
        {
            get
            {
                var list = new List<Policy>
                {
                    new Policy("1", new DateTime(2015, 1, 1)),
                    new Policy("2", new DateTime(2016, 1, 1)),
                    new Policy("3", new DateTime(2017, 1, 1)),
                };
                return list;
            }
        }
    }
}