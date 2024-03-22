using Equipment_Placing_Service.DAL.Context;
using Equipment_Placing_Service.DAL.Entities;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace Equipment_Placing_Service.DAL.Repositories {
    public class EquipmentTypeRepository : IEquipmentTypeRepository {

        private readonly EquipmentPlacingContext _equipmentPlacingContext;
        private readonly DbSet<EquipmentType> _equipmentTypes;
        public Type ElementType => ((IQueryable)_equipmentTypes).ElementType;

        public Expression Expression => ((IQueryable)_equipmentTypes).Expression;

        public IQueryProvider Provider => ((IQueryable)_equipmentTypes).Provider;

        public EquipmentTypeRepository(EquipmentPlacingContext equipmentPlacingContext) {
            _equipmentPlacingContext = equipmentPlacingContext;
            _equipmentTypes = _equipmentPlacingContext.Set<EquipmentType>();
        }
        public async Task<EquipmentType> GetByCodeAsync(string code) {
            return await _equipmentTypes.FirstOrDefaultAsync(et => et.Code == code);
        }

        public async Task AddAsync(EquipmentType equipmentType) {
            await _equipmentTypes.AddAsync(equipmentType);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync() {
            var allEquipmentPlacementContracts = await _equipmentTypes.ToListAsync();
            _equipmentTypes.RemoveRange(allEquipmentPlacementContracts);

            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(EquipmentType equipmentType) {
            _equipmentTypes.Remove(equipmentType);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task<EquipmentType> GetByIdAsync(int id) {
            return await _equipmentTypes.FindAsync(id);
        }

        public IEnumerator GetEnumerator() {
            return ((IQueryable)_equipmentTypes).GetEnumerator();
        }

        public async Task UpdateAsync(EquipmentType equipmentType) {
            _equipmentTypes.Update(equipmentType);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task<List<EquipmentType>> GetAllAsync() {
            return await _equipmentTypes.ToListAsync();
        }
    }
}
