
namespace Interfaces.Models
{
    public interface ILoan : IBaseModel
    {
        Guid BookUid { get; set; }
        Guid UserUid { get; set; }
        DateTime LoansAt { get; set; }
        DateTime ReturnAt { get; set; }
        LoanStatus LoansStatus { get; set; }
    }

    /// <summary>
    /// Pending: representa um empréstimo que está aguardando processamento ou confirmação.
    /// InProgress: representa um empréstimo ativo, onde o livro ainda não foi devolvido.
    /// Completed: representa um empréstimo que foi concluído com sucesso, onde o livro foi devolvido dentro do prazo.
    /// Overdue: representa um empréstimo que está atrasado, ou seja, o livro não foi devolvido dentro do prazo estabelecido.
    /// </summary>
    public enum LoanStatus
    {
        Pending,
        InProgress,
        Completed,
        Overdue
    }
}
