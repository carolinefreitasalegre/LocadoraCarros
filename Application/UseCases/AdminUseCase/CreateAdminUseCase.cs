using Application.Contratos.AdminInterfaceUseCase;
using Application.Dtos.Request.RequestAdmin;
using Application.Dtos.Response.ResponseAdmin;
using AutoMapper;
using Domain.Contratos.AdminInterface;
using Domain.Entities.Admin;

namespace Application.UseCases.AdminUseCase
{
    public class CreateAdminUseCase : ICreateAdminUseCase
    {

        private readonly ICreateAdminRepository _repository;
        private readonly IMapper _mapper;

        public CreateAdminUseCase(ICreateAdminRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Admin> CreateAdmin(CreateAdminRequest request)
        {

            var newAdmin = new Admin(request.Name.ToLower(), request.JobDescription.ToLower(), request.Email.ToLower(), request.Password)
            {
                Id = Guid.NewGuid(),
                RegisterTime = DateTime.UtcNow
            };

            await _repository.CreateAdmin(newAdmin);
            return newAdmin;
        }

        public async Task<List<CreateAdmiResponse>> GetAllAdmin()
        {
            var lista = await _repository.GetAllAdmin();
            return _mapper.Map<List<CreateAdmiResponse>>(lista);
        }


        public async Task<Admin> GetAdmin(Guid Id)
        {
            var admin = await _repository.GetAdmin(Id);
            var listResponse = _mapper.Map<Admin>(admin);

            return listResponse;
        }


        public async Task<Admin> EditAdmin(Guid Id, CreateAdminRequest request)
        {

            var admin = await GetAdmin(Id);

            if (admin == null)
            {
                throw new KeyNotFoundException("Admin não enconrado");
            }

            admin.Name = request.Name.ToLower();
            admin.JobDescription = request.JobDescription.ToLower();
            admin.Email = request.Email.ToLower();
            admin.Password = request.Password;


            return await _repository.EditAdmin(admin);


        }


        public async Task<Admin> DeleteAdmin(Guid Id)
        {
            var admin = await _repository.GetAdmin(Id);

            if (admin == null)
            {
                throw new KeyNotFoundException("Administrador não encontrado");
            }

            return await _repository.DeleteAdmin(Id);
        }

    }
}
