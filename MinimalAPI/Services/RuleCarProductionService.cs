using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Entities;

namespace MinimalAPI.Services
{
    public class RuleCarProductionService
    {
        private SQLiteDbContext _context;

        public RuleCarProductionService(SQLiteDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionCarProduction> CalculateProductAsync(List<RuleCarProduction> model)
        {
            try
            {
                var ListRuleCarProduction = model.OrderBy(x => x.Priority).ThenBy(x => x.SequenceDay).ToList();

                // set maximal jumlah produksi per harinya
                int MaxNum = 5;

                // get jumlah total rencana produksi mobil dalam 5 hari
                int TotalProductionNum = ListRuleCarProduction.Sum(x => Convert.ToInt32(x.TotalProduction));
                ListRuleCarProduction.ForEach(x => x.TotalProduction = 0);
                // mulai pembagian rencana produksi
                int n = TotalProductionNum;
                while (n > 0)
                {
                    foreach (var item in ListRuleCarProduction)
                    {
                        if (item.TotalProduction <= MaxNum && item.Priority != 0)
                        {
                            item.TotalProduction += 1;
                            n--;
                        }
                        if (n == 0)
                        {
                            break;
                        }
                        continue;
                    }
                }

                // urutkan list kembali ke semula dengan sequence day
                ListRuleCarProduction = ListRuleCarProduction.OrderBy(x => x.SequenceDay).ToList();

                // save hasil
                TransactionCarProduction obj = new TransactionCarProduction();
                obj.Senin = ListRuleCarProduction[0].TotalProduction;
                obj.Selasa = ListRuleCarProduction[1].TotalProduction;
                obj.Rabu = ListRuleCarProduction[2].TotalProduction;
                obj.Kamis = ListRuleCarProduction[3].TotalProduction;
                obj.Jumat = ListRuleCarProduction[4].TotalProduction;
                obj.Sabtu = ListRuleCarProduction[5].TotalProduction;
                obj.Minggu = ListRuleCarProduction[6].TotalProduction;
                _context.TransactionCarProductions.Add(obj);

                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TransactionCarProduction>> GetTransactionCarProductionAsync()
        {
            return await _context.TransactionCarProductions.ToListAsync();
        }

        public async Task<IEnumerable<RuleCarProduction>> GetProductsAsync()
        {
            return await _context.RuleCarProductions.ToListAsync();
        }

        public async Task<RuleCarProduction> GetProductAsync(int id)
        {
            return await _context.RuleCarProductions.Where(_ => _.Id == id).FirstAsync();
        }

        public async Task<RuleCarProduction> AddProductAsync(RuleCarProduction model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<RuleCarProduction> UpdateProduct(RuleCarProduction model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<RuleCarProduction> DeleteProductAsync(int id)
        {
            var model = await _context.RuleCarProductions.Where(_ => _.Id == id).FirstAsync();
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

    }
}
