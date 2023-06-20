using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IBook : IBaseModel
    {
        /// <summary>
        /// O título do livro.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// O nome do autor ou autores do livro.
        /// </summary>
        List<string> Authors { get; set; }

        /// <summary>
        /// O International Standard Book Number (ISBN) é um código único que identifica o livro.
        /// </summary>
        string ISBN { get; set; }

        /// <summary>
        /// O nome da editora responsável pela publicação do livro.
        /// </summary>
        string Publisher { get; set; }

        /// <summary>
        /// O ano em que o livro foi publicado.
        /// </summary>
        DateTime Publication { get; set; }

        /// <summary>
        /// O gênero literário do livro, como ficção, não ficção, romance, fantasia, etc.
        /// </summary>
        string Genre { get; set; }

        /// <summary>
        /// Uma breve descrição ou resumo do conteúdo do livro.
        /// </summary>
        string Synopsis { get; set; }

        /// <summary>
        /// Total de paginas do livro
        /// </summary>
        int TotalPages { get; set; }

        /// <summary>
        /// O idioma em que o livro foi escrito.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// A localização física do livro na biblioteca, como uma estante ou prateleira específica.
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Indica se o livro está disponível, emprestado, reservado ou perdido.
        /// </summary>
        EStatusType Status { get; set; }

        /// <summary>
        /// Data que o livro foi adquirido pela biblioteca
        /// </summary>
        DateTime Acquisition { get; set; }

        /// <summary>
        /// total de copias
        /// </summary>
        int TotalCopies { get; set; }

        /// <summary>
        /// Copias alugadas
        /// </summary>
        int CopiesRented { get; set; }

        /// <summary>
        /// capa do livro
        /// </summary>
        byte[] BookCover { get; set; }
    }

    public enum EStatusType
    {
        Available, //disponivel
        Borrowed, //emprestado
        Reserved, //reservado
        Lost //perdido
    }
}
