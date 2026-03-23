using PizzaFlow.Intranet.Models.Produtos;

namespace PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;

public interface IInsumosRepository
{
    Insumo? ProcurarInsumoPorId(int id);
    IQueryable<Insumo> QueryInsumos();
    void AtualizarInsumo(Insumo insumo);
    void CadastrarNovoInsumo(Insumo insumo);
    void Deletar(int id);
}