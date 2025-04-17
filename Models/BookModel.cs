using System.Xml.Linq;

namespace Books.Models
{
    public class BookModel
    {
        public BookModel(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }

        public Guid Id { get; init; }
        public string Title { get; private set; }

        public void ChangeTitle(string title)
        {
            Title = title;
        }

        public void SetInactive()
        {
            Title = "desativado";
        }
    }
}