﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xafology.ExpressApp.Xpo.Import
{
    public class ImportOptions : IImportOptions
    {
        public ImportOptions()
        {
            CreateMembers = false;
            CacheLookupObjects = false;
        }
        public bool CreateMembers { get; set; }
        public bool CacheLookupObjects { get; set; }
    }
}
