using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Produtos;

namespace PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository
{
    public class InsumosRepository : IInsumosRepository
    {
        private readonly IDataRepository<Insumo> insumosDataRepository;
        public void AtualizarInsumo(Insumo insumo)
        {
            insumosDataRepository.Update(insumo);
            insumosDataRepository.SaveChanges();
        }

        public void CadastrarNovoInsumo(Insumo insumo)
        {
            insumosDataRepository.Add(insumo);
        }

        public void Deletar(int id)
        {
            var insumo = insumosDataRepository.GetById(id);
            insumosDataRepository.Delete(insumo);
        }

        public Insumo? ProcurarInsumoPorId(int id)
        {
            return insumosDataRepository.GetById(id);
        }

        public IQueryable<Insumo> QueryInsumos()
        {
            r
        }
    }
}
