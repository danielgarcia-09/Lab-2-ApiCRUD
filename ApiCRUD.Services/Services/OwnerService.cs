using ApiCRUD.Bl.Dto;
using ApiCRUD.Context;
using ApiCRUD.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCRUD.Services
{

    public interface IOwnerService : IBaseService<Owner, OwnerDto, VehicleContext>
    {
        Task<List<OwnerDto>> GetAllOwners();

        Task<OwnerDto> GetOwner(int id);
        
        Task<OwnerDto> AddOwner(OwnerDto ownerDto);
        
        Task<bool> UpdateOwner(int id, OwnerDto ownerDto);
        
        Task<bool> DeleteOwner(int id);
    }

    public class OwnerService : BaseService<Owner, OwnerDto, VehicleContext>, IOwnerService
    {

        private readonly IVehicleService _vehicleService;
        
        public OwnerService(IVehicleService service, VehicleContext context, IMapper mapper) : base(context, mapper)
        {
            _vehicleService = service;
        }

        public async Task<List<OwnerDto>> GetAllOwners()
        {
            var listDto = new List<OwnerDto>();

            var ownersDto = await GetAll();

            foreach (var owner in ownersDto)
            {

                var vehiclesDto = await _vehicleService.GetVehiclesByOwnerId(owner.Id);
                owner.Vehicles.AddRange(vehiclesDto);

                listDto.Add(owner);
            }

            return listDto;
        }

        public async Task<OwnerDto> GetOwner(int id)
        {
            var ownerDto = await GetById(id);


            if (ownerDto == null)
            {
                return null;
            }

            var vehiclesDto = await _vehicleService.GetVehiclesByOwnerId(id);

            ownerDto.Vehicles.AddRange(vehiclesDto);

            return ownerDto;
        }


        public async Task<OwnerDto> AddOwner ( OwnerDto  ownerDto )
        {

            var added = await Add(ownerDto);

            if (added == null )
            {
                return null;
            }

            return added;
        }

        public async Task<bool> UpdateOwner (int id, OwnerDto ownerDto )
        {

            var isUpdated = await Update(id, ownerDto);

            if( isUpdated )
            {
                return true;
            } else
            {
                return false;
            }
        }
        
        public async Task<bool> DeleteOwner (int id)
        {
            var isOwnerDeleted = await Delete(id);

            if( isOwnerDeleted )
            {
                await _vehicleService.DeleteWehiclesByOwnerId(id);

                return true;
            }
            return false;
        }
    }
}
