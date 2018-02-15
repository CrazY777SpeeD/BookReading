﻿using System.Collections.Generic;

namespace BookReading.Models
{
    public interface IBookContext
    {
        void AddBook(Book newBook);
        void AddReview(Review newReview);
        List<Book> GetAll();
        int Count();
        List<Book> GetRange(int from, int to);
        Book GetBook(int bookId);
        Author GetAuthor(int id);
        List<Author> GetAuthors();
        Book Update(Book newBookData);
    }
}