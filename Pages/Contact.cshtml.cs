﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task2_v2_0_0.Pages {
    public class ContactModel : PageModel {
        public string Message { get; set; }

        public void OnGet() {
            Message = "Your contact page.";
        }
    }
}
