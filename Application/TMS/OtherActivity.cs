using Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TMS
{
    public class OtherActivity
    {
        public OtherActivity()
        {
            IsActive = true;
        }
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? Users { get; set; }
        public long SubjectId { get; set; }
        public string? Subject { get; set; }
        public decimal Hours { get; set; }
        public bool IsActive { get; set; }
    }
}
