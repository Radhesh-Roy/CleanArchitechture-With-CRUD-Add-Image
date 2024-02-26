﻿using AutoMapper;
using CleanArchitechture.Domain.Models;

namespace CleanArchitechture.Application.ViewModel;

[AutoMap(typeof(Student),ReverseMap = true)]    
public class StudentVm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Images { get; set; } = string.Empty;
}
