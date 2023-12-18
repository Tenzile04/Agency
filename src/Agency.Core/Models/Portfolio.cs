using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Models
{
    public class Portfolio:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Description { get; set; }
        public string? ImageUrl {  get; set; }
        [NotMapped]
        public IFormFile? ImageFile {  get; set; }
        public int CategoryId {  get; set; }
        public Category? Category { get; set; }
        public string Client {  get; set; }
        public string RedirectText {  get; set; }
        public string? RedirectUrl { get; set;}

    }
}
