using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    //this is the Cart class, this is where some of the magic happens to  add, delete, and find the total for the customer that added things to the cart
    public class Cart
    {

        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Book boo, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == boo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = boo,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public virtual void RemoveLine(Book proj) =>
            Lines.RemoveAll(x => x.Book.BookId == proj.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);
        //Price is hard coded here 
        // e.Project.ProjectPrice

        public class CartLine //class used to store information in one bundle
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }

        internal void RemoveItem(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
