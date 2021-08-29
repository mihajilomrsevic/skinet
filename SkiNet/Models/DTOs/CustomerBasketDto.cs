using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SkiNet.WebAPI.Core.Models;

namespace SkiNet.WebAPI.Models.DTOs
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }

        public List<BasketItemDto> Items { get; set; }
    }
}
