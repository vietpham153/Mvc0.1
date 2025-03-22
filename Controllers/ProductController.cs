﻿using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);
        }
    }
}
