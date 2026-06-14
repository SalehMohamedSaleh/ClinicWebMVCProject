using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
        void Delete();
    }
}
