using Equipment_Placing_Service.DAL.Entities;

namespace Equipment_Placing_Service.DAL.Repositories.Interfaces {
    public interface IManufacturingSpaceRepository : IQueryable {
        public Task<ManufacturingSpace> GetByCodeAsync(string code);
        public Task<ManufacturingSpace> GetByIdAsync(int id);
        public Task<List<ManufacturingSpace>> GetAllAsync();
        public Task AddAsync(ManufacturingSpace manufacturingSpace);
        public Task UpdateAsync(ManufacturingSpace manufacturingSpace);
        public Task DeleteAsync(ManufacturingSpace manufacturingSpace);
        public Task DeleteAllAsync();
    }
}
