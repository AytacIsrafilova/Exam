using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IServicessService
    {
        void AddServicess (Servicess servicess);
        void DeleteServicess(int id);
        void UpdateServicess (int id,Servicess servicess);
        Servicess GetServicess ( Func<Servicess,bool>?func=null);
        List<Servicess > GetAllServicess(Func<Servicess, bool>? func = null);

    }
}
