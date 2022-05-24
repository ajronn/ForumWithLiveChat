﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Transfer.Shared
{
    public class PageListDto<T>
    {
        public List<T> Items { get; set; }

        public int Count { get; set; }

        public int Total { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
