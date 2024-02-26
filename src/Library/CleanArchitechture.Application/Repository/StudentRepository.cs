using AutoMapper;
using CleanArchitechture.Application.Service;
using CleanArchitechture.Application.ViewModel;
using CleanArchitechture.Domain.Models;
using CleanArchitechture.Infrastructure.DatabaseContext;

namespace CleanArchitechture.Application.Repository;

public class StudentRepository : RepositryService<Student, StudentVm>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
