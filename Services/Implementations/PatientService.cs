using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class PatientService : IPatientService
	{
        private readonly IGeneralRepository<Patient> _patientRepository;



        public PatientService(IGeneralRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }



        public IBaseResponse<Patient> Add(Patient patient)
        {
            var baseResponse = new BaseResponse<Patient>();
            _patientRepository.Add(patient);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = patient;
            return baseResponse;
        }



        public IBaseResponse<Patient> Delete(int id)
        {
            var baseResponse = new BaseResponse<Patient>();
            Patient patient = new Patient() { Id = id };
            _patientRepository.Delete(patient);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = patient;
            return baseResponse;
        }

        public IBaseResponse<Patient> Delete(Patient patient)
        {
            var baseResponse = new BaseResponse<Patient>();
            _patientRepository.Delete(patient);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = patient;
            return baseResponse;
        }

        public async Task<IBaseResponse<Patient>> Get(int id)
        {
            var baseResponse = new BaseResponse<Patient>();
            try
            {
                var patient = await _patientRepository.Get(id);
                if (patient == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = patient;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Patient>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Patient>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Patient>>();
            try
            {
                var patient = await _patientRepository.GetAll();
                if (patient == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = patient;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Patient>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Patient>> Update(int id, Patient obj)
        {
            var baseResponse = new BaseResponse<Patient>();
            try
            {
                var patient = await _patientRepository.Get(id);
                if (patient == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                patient.Age = obj.Age;
                patient.IsPrivilege = obj.IsPrivilege;
                patient.MainDiagnosis = obj.MainDiagnosis;
                patient.Name = obj.Name;
                patient.SubDiagnosis = obj.SubDiagnosis;
                patient.Surname = obj.Surname;

                await  _patientRepository.Update(patient);

                baseResponse.Data = patient;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Patient>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

