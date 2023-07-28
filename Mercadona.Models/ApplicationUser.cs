using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadona.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public string Role { get; set; }
    }
}
