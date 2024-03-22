using Equipment_Placing_Service.DAL.Context;
using Equipment_Placing_Service.DAL.Entities;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace Equipment_Placing_Service.DAL.Repositories {
    public class EquipmentPlacementContractRepository : IEquipmentPlacementContractRepository {

        private readonly EquipmentPlacingContext _equipmentPlacingContext;
        private readonly DbSet<EquipmentPlacementContract> _equipmentPlacementContracts;
        public Type ElementType => ((IQueryable)_equipmentPlacementContracts).ElementType;

        public Expression Expression => ((IQueryable)_equipmentPlacementContracts).Expression;

        public IQueryProvider Provider => ((IQueryable)_equipmentPlacementContracts).Provider;
        public EquipmentPlacementContractRepository(EquipmentPlacingContext equipmentPlacingContext) {
            _equipmentPlacingContext = equipmentPlacingContext;
            _equipmentPlacementContracts = _equipmentPlacingContext.Set<EquipmentPlacementContract>();
        }

        public async Task AddAsync(EquipmentPlacementContract equipmentPlacementContract) {
            await _equipmentPlacementContracts.AddAsync(equipmentPlacementContract);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync() {
            var allEquipmentPlacementContracts = await _equipmentPlacementContracts.ToListAsync();
            _equipmentPlacementContracts.RemoveRange(allEquipmentPlacementContracts);

            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(EquipmentPlacementContract equipmentPlacementContract) {
            _equipmentPlacementContracts.Remove(equipmentPlacementContract);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task<EquipmentPlacementContract> GetByIdAsync(int id) {
            return await _equipmentPlacementContracts.FindAsync(id);
        }

        public IEnumerator GetEnumerator() {
            return ((IQueryable)_equipmentPlacementContracts).GetEnumerator();
        }

        public async Task UpdateAsync(EquipmentPlacementContract equipmentPlacementContract) {
            _equipmentPlacementContracts.Update(equipmentPlacementContract);
            await _equipmentPlacingContext.SaveChangesAsync();
        }

        public async Task<List<EquipmentPlacementContract>> GetAllAsync() {
            return await _equipmentPlacementContracts.ToListAsync();
        }
    }
}
