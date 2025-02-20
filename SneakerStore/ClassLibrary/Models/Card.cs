﻿using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Card
    {
        private int id;
        private string name;
        private string number;
        private string securityNumber;
        private DateOnly expirationDate;

        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public string Number { get { return number; } }
        public string SecurityNumber { get {  return securityNumber; } }
        public DateOnly ExpirationDate { get { return expirationDate; } }

        public Card()
        {
            id = 0;
            name = string.Empty;
            number = string.Empty;
            securityNumber = string.Empty;
            expirationDate = DateOnly.MinValue;
        }
        public Card(CardDTO dto)
        {
            id = dto.Id;
            name = dto.Name;
            number = dto.Number;
            securityNumber = dto.SecurityNumber;
            expirationDate = dto.ExpirationDate;    
        }
        public CardDTO ToDTO()
        {
            return new CardDTO
            {
                Id = id,
                Name = name,
                Number = number,
                SecurityNumber = securityNumber,
                ExpirationDate = expirationDate,
            };
        }
    }
}
