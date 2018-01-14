using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDtos
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool isSubscribedToNewsLetter { get; set; }

        [Display(Name = "MemberShip Type")]
        public byte MembershipTypeId { get; set; }


        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? birthdate { get; set; }
    }
}