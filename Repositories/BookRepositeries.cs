using System;
using System.Collections.Generic;
using System.Linq;
using BookwormsHaven.Models;
using BookwormsHaven.Repositories;

namespace BookwormsHaven.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            // Initialize with some sample data for demonstration
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Genre 1", Year = 2020 },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", Genre = "Genre 2", Year = 2019 },
                new Book { Id = 3, Title = "Book 3", Author = "Author 3", Genre = "Genre 3", Year = 2021 }
            };
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books; // Correct return type
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id); // Correct return type
        }

        public void AddBook(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1; // Generate a new ID
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title ?? existingBook.Title; // If new title is null, keep the existing one
                existingBook.Author = book.Author ?? existingBook.Author; // If new author is null, keep the existing one
                existingBook.Genre = book.Genre ?? existingBook.Genre; // If new genre is null, keep the existing one
                existingBook.Year = book.Year;
            }
            else
            {
                throw new InvalidOperationException("Book not found");
            }
        }

        public void DeleteBook(int id)
        {
            var bookToRemove = _books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }
            else
            {
                throw new InvalidOperationException("Book not found");
            }
        }
    }
}