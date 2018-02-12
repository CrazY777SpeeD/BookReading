using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Razor;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace BookReading.Models
{
    public class Author
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Display(Name = "Имя"), LinqToDB.Mapping.Column]
        public string Name { get; set; }

        [Display(Name = "Возраст"), LinqToDB.Mapping.Column]
        public int Age { get; set; }
    }
}