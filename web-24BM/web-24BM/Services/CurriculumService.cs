using System.Text.RegularExpressions;
using web_24BM.Data;
using web_24BM.Models;
using web_24BM.Repository;

namespace web_24BM.Services
{
    public class CurriculumService : ICurriculum
    {
        private readonly CurriculumRepository _Repository;

        public CurriculumService(ApplicationDbContext context)
        {
            _Repository = new CurriculumRepository(context);
        }

        public async Task<ResponseHelper> Create(Curriculum model)
        {
            ResponseHelper response = new ResponseHelper();
            try
            {
                int edad = (DateTime.Now.Year - model.FechaNacimiento.Year) - (DateTime.Now.DayOfYear < model.FechaNacimiento.DayOfYear ? 1 : 0);
                if (!(edad >= 18 && edad <= 100))
                {
                    return response;
                }

                string expressionForCURP = @"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z\d]\d$";
                if (!Regex.IsMatch(model.CURP, expressionForCURP))
                {
                    return response;
                }


                string filePath = "";
                string fileName = "";
                if (model.Foto != null && model.Foto.Length > 0)
                {
                    fileName = Path.GetFileName(model.Foto.FileName);
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FotosCurri", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Foto.CopyToAsync(fileStream);
                    }

                }
                model.NombreFoto = fileName;


                var result = await _Repository.Create(model);
                if (result > 0)
                {
                    response.Success = true;
                    response.Message = $"Se agregó el currículum de {model.Nombre} con éxito";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<ResponseHelper> Delete(int IdCurriculum)
        {
			ResponseHelper response = new ResponseHelper();

			try
			{
                Curriculum curriculum = await _Repository.GetById(IdCurriculum);
                
                if (!String.IsNullOrEmpty(curriculum.NombreFoto))
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FotosCurri", curriculum.NombreFoto);

                    File.Delete(filePath);
                }

                if (await _Repository.Delete(IdCurriculum) > 0)
				{
					response.Success = true;
					response.Message = "Se ha eliminado el currículum con éxito.";
				}
			}
			catch (Exception e)
			{
				response.Message = e.Message;
			}

			return response;
		}

        public async Task<List<Curriculum>> GetAll()
        {
            List<Curriculum> list = new List<Curriculum>();
            try
            {
                list = await _Repository.GetAll();
            }
            catch (Exception e)
            {


            }
            return list;
        }

        public async Task<Curriculum> GetById(int IdCurriculum)
        {
            Curriculum curriculum = new Curriculum();
            try
            {
                curriculum = await _Repository.GetById(IdCurriculum);
            }
            catch (Exception e)
            {

            }
            return curriculum;
        }

        public async Task<ResponseHelper> Update(Curriculum model)
        {
			ResponseHelper response = new ResponseHelper();

			try
			{
                int edad = (DateTime.Now.Year - model.FechaNacimiento.Year) - (DateTime.Now.DayOfYear < model.FechaNacimiento.DayOfYear ? 1 : 0);
                if (!(edad >= 18 && edad <= 100))
                {
                    return response;
                }

                string expressionForCURP = @"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z\d]\d$";
                if (!Regex.IsMatch(model.CURP, expressionForCURP))
                {
                    return response;
                }

                if (model.Foto != null && model.Foto.Length > 0)
                {
                    string filePath = "";
                    string fileName = "";

                    fileName = Path.GetFileName(model.Foto.FileName);
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FotosCurri", fileName);

                    File.Delete(filePath);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Foto.CopyToAsync(fileStream);
                    }

                    model.NombreFoto = fileName;
                    if (await _Repository.Update(model) > 0)
                    {
                        response.Success = true;
                        response.Message = $"Se ha actualizado el currículum de {model.Nombre} con éxito.";
                    }
                }
                else
                {
                    if (await _Repository.Update(model) > 0)
                    {
                        response.Success = true;
                        response.Message = $"Se ha actualizado el currículum de {model.Nombre} con éxito.";
                    }
                }
                
			}
			catch (Exception e)
			{
				response.Message = e.Message;

			}

			return response;
		}
    }
}
