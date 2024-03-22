using Equipment_Placing_Service.DAL.Entities;

namespace Equipment_Placing_Service.DAL.Repositories.Interfaces {
    public interface IEquipmentPlacementContractRepository : IQueryable {
        public Task<EquipmentPlacementContract> GetByIdAsync(int id);
        public Task<List<EquipmentPlacementContract>> GetAllAsync();
        public Task AddAsync(EquipmentPlacementContract equipmentPlacementContract);
        public Task UpdateAsync(EquipmentPlacementContract equipmentPlacementContract);
        public Task DeleteAsync(EquipmentPlacementContract equipmentPlacementContract);
        public Task DeleteAllAsync();
    }
}
