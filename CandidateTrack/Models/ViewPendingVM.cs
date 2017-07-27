using CandidateTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandidateTrack.Models
{
    public class ViewPendingVM
    {
        public IEnumerable<CandidateDB> candidate { get; set; }
    }
}