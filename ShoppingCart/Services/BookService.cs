using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Services {
    public class BookService : IDisposable {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public List<Book> GetFeatured() {
            return _db.Books
                .Include("Author")
                .Where(b => b.Featured)
                .ToList();
        }
        public List<Book> GetByCategoryId(int categoryId) {
            return _db.Books
                .Include("Author")
                .Where(b => b.CategoryId == categoryId)
                .OrderByDescending(b => b.Featured)
                .ToList();
        }

        public void Dispose() {
            _db.Dispose();
        }
    }
}