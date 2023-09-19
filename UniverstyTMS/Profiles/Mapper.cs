using AutoMapper;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Dtos.AnnounceDtos;
using UniverstyTMS.Dtos.FacultyDtos;
using UniverstyTMS.Dtos.GroupDtos;
using UniverstyTMS.Dtos.SettingDtos;
using UniverstyTMS.Dtos.SpecialtyDtos;
using UniverstyTMS.Dtos.StudentDtos;
using UniverstyTMS.Dtos.TeacherDtos;
using UniverstyTMS.Dtos.TypeDtos;

namespace UniverstyTMS.Profiles
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<Specialty,SpecialtyGetDto>();
            CreateMap<Faculty,FacultyInSpecialtyGetDto>();
            CreateMap<Announce,AnnounceGetDto>();
            CreateMap<Core.Entities.Type, TypeGetDto>();
            CreateMap<TypePostDto, Core.Entities.Type>();
            CreateMap<Faculty,FacultyGetDto>();
            CreateMap<Settings,SettingGetDto>();
            CreateMap<SettingPostDto, Settings>();
            CreateMap<FacultyPostDto, Faculty>();
            CreateMap<AnnouncePostDto, Announce>();
            CreateMap<SpecialtyPostDto, Specialty>();
            CreateMap<TeacherPostDto, Teacher>();
            CreateMap<Teacher,TeacherGetDto>();
            CreateMap<Teacher,TeacherGetByIdDto>();
            CreateMap<Faculty,FacultyInTeacherGetDto>();
            CreateMap<Faculty, FacultyInTeacherGetByIdDto>();
            CreateMap<Core.Entities.Type,TypeInTeacherGetDto>();
            CreateMap<Core.Entities.Type, TypeInTeacherGetByIdDto>();
            CreateMap<Group,GroupGetDto>();
            CreateMap<GroupPostDto,Group>();
            CreateMap<Faculty,FacultyInGroupGetDto>();
            CreateMap<Specialty, SpecialtyInGroupGetDto>();
            //CreateMap<Student, StudentsInGroupGetDto>();
            CreateMap<Student,StudentGetDto>();
            CreateMap<Group,GroupInStudentGetDto>();
            CreateMap<Core.Entities.Type, TypeInStudentGetDto>();
            CreateMap<StudentPostDto, Student>();
            CreateMap<Student, StudentLoginGetDto>();
            CreateMap<Teacher, TeacherLoginGetDto>();
        }
    }
}
