﻿using AutoMapper;
using Bank.Application.Common.Mapping;
using Bank.Domain.Client;

namespace Bank.Application.Clients.Commands.CreateClient
{
	public class ClientCreateDto : IMapWith<Client>
	{
		public string Firstname { get; set; } = null!;

		public string Lastname { get; set; } = null!;

		public string Patronymic { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public string PassportSeries { get; set; } = null!;

		public string PassportNumber { get; set; } = null!;

		public decimal TotalIncomePerMounth { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Client, ClientCreateDto>()
				.ForMember(clientDto => clientDto.Firstname,
					opt => opt.MapFrom(client => client.Firstname))
				.ForMember(clientDto => clientDto.Lastname,
					opt => opt.MapFrom(client => client.Lastname))
				.ForMember(clientDto => clientDto.Patronymic,
					opt => opt.MapFrom(client => client.Patronymic))
				.ForMember(clientDto => clientDto.PhoneNumber,
					opt => opt.MapFrom(client => client.PhoneNumber.Number))
				.ForMember(clientDto => clientDto.PassportSeries,
					opt => opt.MapFrom(client => client.PassportSeries.Series))
				.ForMember(clientDto => clientDto.PassportNumber,
					opt => opt.MapFrom(client => client.PassportNumber.Number))
				.ForMember(clientDto => clientDto.TotalIncomePerMounth,
					opt => opt.MapFrom(client => client.TotalIncomePerMounth.Income));
		}
	}
}
