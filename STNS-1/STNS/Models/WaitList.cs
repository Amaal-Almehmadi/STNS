using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WaitList
    {
        [Key]
        public int Request_num { get; set; }
      
        public int Child_Id { get; set; }
        public string Child_Fullname { get; set; }
        public string Child_Gender { get; set; }
        public Nullable<System.DateTime> Child_BirthDate { get; set; }
        public Nullable<int> Monthly_Age { get; set; }
        public Nullable<int> Years_Age { get; set; }
        public string Child_Nationality { get; set; }
        public string Mother_Name { get; set; }
        public string Mother_Nationality { get; set; }
        public Nullable<int> Mother_Nationad_ID { get; set; }
        public Nullable<int> Mother_Phone { get; set; }
        public string Mother_Email { get; set; }
        public string branch { get; set; }
        public bool age_type { get; set; }
        public Nullable<System.DateTime> Start_date { get; set; }
        public string Other { get; set; }
        public string Mother_state { get; set; }
        public string role { get; set; }
        public string College { get; set; }
    }
}