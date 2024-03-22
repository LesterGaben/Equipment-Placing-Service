using Equipment_Placing_Service.DAL.Context;
using Equipment_Placing_Service.DAL.Entities;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace Equipment_Placing_Service.DAL.Repositories {
    public class ManufacturingSpaceRepository : IManufacturingSpaceRepository {

        private readonly EquipmentPlacingContext _equipmentPlacingContext;
        private readonly DbSet<ManufacturingSpace> _manufacturingSpaces;
        public Type ElementType => ((IQueryable)_manufacturingSpaces).ElementType;

        public Expression Expression => ((IQueryable)_manufacturingSpaces).Expression;

        public IQueryProvider Provider => ((IQueryable)_manufacturingSpaces).Provider;

        public ManufacturingSpaceRepository(EquipmentPlacingContext equipmentPlacingContext) {
            _equipmentPlacingContext = equipmentPlacingContext;
            _manufacturingSpaces = _equipmentPlacingContext.Set<ManufacturingSpace>();
        }

        public async Task<ManufacturingSpace> GetByCodeAsync(string code) {
            return await _manufacturingSpaces.FirstOrDefaultAsync(ms => ms.Code == code);
        }

        public async Task AddAsync(ManufacturingSpace manufacturingSpace) {
            await _manufacturingSpaces.AddAsync(manufacturingSpace);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync() {
            var allEquipmentPlacementContracts = await _manufacturingSpaces.ToListAsync();
            _manufacturingSpaces.RemoveRange(allEquipmentPlacementContracts);

            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ManufacturingSpace manufacturingSpace) {
            _manufacturingSpaces.Remove(manufacturingSpace);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task<ManufacturingSpace> GetByIdAsync(int id) {
            return await _manufacturingSpaces.FindAsync(id);
        }

        public IEnumerator GetEnumerator() {
            return ((IQueryable)_manufacturingSpaces).GetEnumerator();
        }

        public async Task UpdateAsync(ManufacturingSpace manufacturingSpace) {
            _manufacturingSpaces.Update(manufacturingSpace);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task<List<ManufacturingSpace>> GetAllAsync() {
            return await _manufacturingSpaces.ToListAsync();
        }
    }
}
