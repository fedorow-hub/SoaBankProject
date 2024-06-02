using AutoMapper;
using Bank.Application.Clients.Commands.CreateClient;
using Bank.Application.Common.Mapping;

namespace SoaBankProject.Models
{
	public class CreateClientDTO : IMapWith<CreateClientCommand>
	{
		public string Firstname { get; set; } = null!;

		public string Lastname { get; set; } = null!;

		public string Patronymic { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public string PassportSeries { get; set; } = null!;

		public string PassportNumber { get; set; } = null!;

		public string TotalIncomePerMounth { get; set; } = null!;
		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateClientDTO, CreateClientCommand>()
				.ForMember(noteCommand => noteCommand.Firstname,
					opt => opt.MapFrom(noteDto => noteDto.Firstname))
				.ForMember(noteCommand => noteCommand.Lastname,
					opt => opt.MapFrom(noteDto => noteDto.Lastname))
				.ForMember(noteCommand => noteCommand.Patronymic,
					opt => opt.MapFrom(noteDto => noteDto.Patronymic))
				.ForMember(noteCommand => noteCommand.PhoneNumber,
					opt => opt.MapFrom(noteDto => noteDto.PhoneNumber))
				.ForMember(noteCommand => noteCommand.PassportSeries,
					opt => opt.MapFrom(noteDto => noteDto.PassportSeries))
				.ForMember(noteCommand => noteCommand.PassportNumber,
					opt => opt.MapFrom(noteDto => noteDto.PassportNumber))
				.ForMember(noteCommand => noteCommand.TotalIncomePerMounth,
					opt => opt.MapFrom(noteDto => noteDto.TotalIncomePerMounth));
		}
	}
}
