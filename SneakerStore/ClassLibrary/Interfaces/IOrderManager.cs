﻿using Logic.DTOs;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IOrderManager
    {
        public void AddAccountOrder(Order order);
        public void AddNoAccountOrder(Order order);
        public List<OrderDTO> GetAllOrdersForUser(int userId);
    }
}
