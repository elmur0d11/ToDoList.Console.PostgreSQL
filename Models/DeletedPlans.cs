using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmurod.ToDoList.Models
{
    public class DeletedPlans
    {
        public int Id { get; set; }
        public string Reason { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
