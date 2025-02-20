﻿using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class ShoppingCartItem
    {
        private Product product;
        private string size;
        private int quantity;

        public Product Product { get { return product; } }
        public string Size { get { return size; } }
        public int Quantity { get { return quantity; } }

        public ShoppingCartItem(Product product, string productSize, int productQuantity)
        {
            this.product = product;
            this.size = productSize;
            this.quantity = productQuantity;
        }
        public ShoppingCartItem(ShoppingCartItemDTO dto)
        {
            this.product = new Product(dto.Product);
            this.size = dto.Size;
            this.quantity = dto.Quantity;
        }
        public ShoppingCartItemDTO ToDTO()
        {
            return new ShoppingCartItemDTO()
            {
                Product = product.ProductToProductDTO(),
                Size = size,
                Quantity = quantity
            };
        }
    }
    
}
