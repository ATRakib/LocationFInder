﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LocationFInderApp.Models
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
