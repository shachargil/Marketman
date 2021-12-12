using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Celebrity : IEquatable<Celebrity>, IEntity
    {
        
        public string name { get; set; }
        public DateTime? birthDate { get; set; }
        public string gender { get; set; }
        public List<string> jobTitle { get; set; }
        public string image { get; set; }

        public bool Equals(Celebrity other)
        {
            if (other == null)
                return false;
            if ( name != other.name || gender != other.gender || !jobTitle.SequenceEqual (other.jobTitle) || birthDate.GetValueOrDefault().CompareTo(other.birthDate.GetValueOrDefault()) != 0)
                return false;
            return true;
        }
    }
}
