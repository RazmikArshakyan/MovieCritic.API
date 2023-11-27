using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCritic.Data.Entities
{
    // Table which will be created in db after I make migrations
    public class ReqTable
    {
        [Key]
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
