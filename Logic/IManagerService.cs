using Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IManagerService
    {
        Task<List<Celebrity>> GetAllCelebritiesAsync();

        Task<List<Celebrity>> RemoveCelebrityAsync(Celebrity celebrity);


    }
}
