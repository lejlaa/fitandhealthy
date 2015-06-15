using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitAndHealthyAPI.Models;

namespace FitAndHealthyAPI.Services
{
    public interface IfandhIdentity
    {
        UserModel currentUser { get; }

    }
}
