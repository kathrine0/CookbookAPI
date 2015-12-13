using Cookbook.Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Services.DTO
{
    public class StepDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int StepNo { get; set; }
    }
}