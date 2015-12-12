using Cookbook.Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Database.Entity
{
    public class Ingredient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}