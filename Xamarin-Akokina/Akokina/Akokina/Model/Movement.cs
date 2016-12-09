using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akokina.Model
{
    public class Movement
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ValueDate { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public User User { get; set; }
    }
}
