namespace ServicoDePagamento.Interface
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();

        Task RollBack();
    }
}
