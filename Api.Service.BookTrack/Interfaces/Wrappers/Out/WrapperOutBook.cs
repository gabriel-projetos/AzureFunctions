using Interfaces.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Wrappers.Out
{
    public class WrapperOutBook : WrapperBase<IBook, WrapperOutBook>
    {
        public WrapperOutBook() : base(null) { }

        public WrapperOutBook(IBook book) : base(book) { }

        [JsonProperty("uid")]
        public Guid Uid
        {
            get => Data.Uid;
            set => Data.Uid = value;
        }

        [JsonProperty("title")]
        public string Title
        {
            get => Data.Title;
            set => Data.Title = value;
        }

        [JsonProperty("authors")]
        public List<string> Authors
        {
            get => Data.Authors;
            set => Data.Authors = value;
        }

        [JsonProperty("isbn")]
        public string ISBN
        {
            get => Data.ISBN;
            set => Data.ISBN = value;
        }

        [JsonProperty("publisher")]
        public string Publisher
        {
            get => Data.Publisher;
            set => Data.Publisher = value;
        }

        [JsonProperty("publication")]
        public DateTime? Publication
        {
            get => Data.Publication;
            set => Data.Publication = value;
        }

        [JsonProperty("genre")]
        public string Genre
        {
            get => Data.Genre;
            set => Data.Genre = value;
        }

        [JsonProperty("synopsis")]
        public string Synopsis
        {
            get => Data.Synopsis;
            set => Data.Synopsis = value;
        }

        [JsonProperty("total_pages")]
        public int TotalPages
        {
            get => Data.TotalPages;
            set => Data.TotalPages = value;
        }

        [JsonProperty("language")]
        public string Language
        {
            get => Data.Language;
            set => Data.Language = value;
        }

        [JsonProperty("location")]
        public string Location
        {
            get => Data.Location;
            set => Data.Location = value;
        }

        [JsonProperty("status")]
        public EStatusType Status
        {
            get => Data.Status;
            set => Data.Status = value;
        }

        [JsonProperty("acquisition")]
        public DateTime Acquisition
        {
            get => Data.Acquisition;
            set => Data.Acquisition = value;
        }

        [JsonProperty("total_copies")]
        public int TotalCopies
        {
            get => Data.TotalCopies;
            set => Data.TotalCopies = value;
        }

        [JsonProperty("copies_rented")]
        public int CopiesRented
        {
            get => Data.CopiesRented;
            set => Data.CopiesRented = value;
        }

        [JsonProperty("book_cover")]
        public byte[] BookCover
        {
            get => Data.BookCover;
            set => Data.BookCover = value;
        }

        [JsonProperty("created_at")]
        public DateTime CreatedAt
        {
            get => Data.CreatedAt;
            set => Data.CreatedAt = value;
        }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt
        {
            get => Data.UpdatedAt;
            set => Data.UpdatedAt = value;
        }
    }
}
