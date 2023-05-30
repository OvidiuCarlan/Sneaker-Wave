using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICardDataHandler
    {
        public int SaveCard(Card card);
        public Card GetCard(int id);
    }
}
