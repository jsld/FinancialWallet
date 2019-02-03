﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWallet.Messages
{
    [Serializable]
    public class ResponseBase
    {
        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; }
    }
}
