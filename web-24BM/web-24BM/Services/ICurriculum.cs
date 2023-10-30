using web_24BM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_24BM.Services
{
    public interface ICurriculum
    {
        Task<List<Curriculum>> GetAll();
        Task<ResponseHelper> Create(Curriculum model);
        Task<ResponseHelper> Update(Curriculum model);
        Task<Curriculum> GetById(int IdCurriculum);
        Task<ResponseHelper> Delete(int IdCurriculum);
    }
}
