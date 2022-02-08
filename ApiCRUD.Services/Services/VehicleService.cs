using ApiCRUD.Bl.Dto;
using ApiCRUD.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCRUD.Services
{
    public interface IVehicleService : IBaseService<Vehicle, VehicleDto, VehicleContext>
    {
        Task<List<VehicleDto>> GetAllVehicles();

        Task<List<VehicleDto>> GetVehiclesByOwnerId(int id);

        Task<VehicleDto> GetVehicle(int id);

        Task<VehicleDto> AddVehicle(VehicleDto vehicleDto);

        Task<bool> UpdateVehicle(int id, VehicleDto vehicleDto);

        Task<bool> DeleteWehiclesByOwnerId(int id);

        Task<bool> TurnOnOrOff(int id);
    }
    public class VehicleService : BaseService<Vehicle, VehicleDto , VehicleContext>, IVehicleService
    {
        public VehicleService(VehicleContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<VehicleDto>> GetAllVehicles()
        {
            var vehicles = await GetAll();

            var vehiclesDto = _mapper.Map<List<VehicleDto>>(vehicles);

            return vehiclesDto;
        }

        public async Task<List<VehicleDto>> GetVehiclesByOwnerId ( int id )
        {
            var vehicles = await _context.Vehicles.Where(x => x.OwnerId == id).ToListAsync();

            var vehiclesDto = _mapper.Map<List<VehicleDto>>(vehicles);

            return vehiclesDto;
        }

        public async Task<VehicleDto> GetVehicle(int id)
        {
            var vehicle = await GetById(id);

            var vehicleDto = _mapper.Map<VehicleDto>(vehicle);

            return vehicleDto;
        }

        public async Task<VehicleDto> AddVehicle( VehicleDto vehicleDto )
        {
            var added = await Add(vehicleDto);

            if (added == null)
            {
                return null;
            }

            return added;
        }

        public async Task<bool> UpdateVehicle ( int id, VehicleDto vehicleDto)
        {
            var vehicle = await GetById(id);

            vehicleDto.OwnerId = vehicle.OwnerId;

            var isUpdated = await Update(id, vehicleDto);

            if( isUpdated )
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> DeleteVehicle( int id )
        {
            var isVehicleDeleted = await Delete(id);

            if (isVehicleDeleted)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteWehiclesByOwnerId(int id)
        {
            var vehiclesDto = await _context.Vehicles.Where(x => x.OwnerId == id).ToListAsync();

            _context.RemoveRange(vehiclesDto);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> TurnOnOrOff ( int id )
        {
            var vehicleDto = await GetById(id);

            if (vehicleDto == null ) { return false; }

            vehicleDto.TurnOnOff();

            await UpdateVehicle(id, vehicleDto);

            await _context.SaveChangesAsync();

            return true;
            
        }
    }
}
