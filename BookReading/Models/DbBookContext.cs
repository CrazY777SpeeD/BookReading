﻿using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;

namespace BookReading.Models
{
    public class DbBookContext : IBookContext
    {
        public void AddBook(Book newBook)
        {
            using (var db = new Database())
            {
                db.Insert(newBook);
                // db.InsertWithIdentity()
            }
        }
        public void AddAuthor(Author newAuthor)
        {
            using (var db = new Database())
            {
                db.Insert(newAuthor);
                // db.InsertWithIdentity()
            }
        }

        public void AddReview(Review newReview)
        {
            using (var db = new Database())
            {
                db.InsertWithIdentity(newReview);
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new Database())
            {
                var query = (from b in db.Books
                    select b);
                return query.ToList();
            }
        }
        public List<Author> GetAuthors()
        {
            using (var db = new Database())
            {
                var query = (from b in db.Author
                             select b);
                return query.ToList();
            }
        }

        public Author GetAuthor(int id)
        {
           using (var db = new Database())
            {
                return db.Author.SingleOrDefault(x => x.Id == id);
            }
        }

        public int Count()
        {
            using (var db = new Database())
            {
                var query = (from b in db.Books
                    select b);
                return query.Count();
            }
        }
        public string AuthorNameById(int id){
            using (var db = new Database())
            {
                return db.Author.SingleOrDefault(x => x.Id == id).Name;
            }
        }
        public List<Book> GetRange(int from, int count)
        {
            using (var db = new Database())
            {
                return (from b in db.Books select b).Skip(from).Take(count).ToList();
            }
        }

        public Book GetBook(int bookId)
        {
            using (var db = new Database())
            {
                return db.Books.SingleOrDefault(x => x.Id == bookId);
            }
        }

        public Book Update(Book newBookData)
        {
            if (newBookData == null)
            {
                throw new ArgumentNullException();
            }
            using (var db = new Database())
            {
                var book =
                    db.Books.SingleOrDefault(x => x.Id == newBookData.Id);

                if (book == null)
                    return null;

                db.Update(newBookData);

                book.Update(newBookData);
                return book;
            }

        }

        private class Database : DataConnection
        {
            public Database() : base("Main")
            {

            }

            public ITable<Book> Books { get { return GetTable<Book>(); } }
            public ITable<Author> Author { get { return GetTable<Author>(); } }
        }
    }
}