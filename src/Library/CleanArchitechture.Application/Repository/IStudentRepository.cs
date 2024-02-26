using CleanArchitechture.Application.Service;
using CleanArchitechture.Application.ViewModel;
using CleanArchitechture.Domain.Models;

namespace CleanArchitechture.Application.Repository;

public interface IStudentRepository:IRepositryService<Student,StudentVm>
{
}
