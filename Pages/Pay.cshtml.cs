using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Infrastructure;
using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment5.Pages
{
    public class PayModel : PageModel
    {
        private ICharityRepository repository;

        //Constructor
        public PayModel(ICharityRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = ReturnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long BookId, string returnUrl)
        {
            Book book = repository.Books
                .FirstOrDefault(p => p.BookId == BookId);
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(book, 1);
            //HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //Below is the functionality to remove items from the cart
        public IActionResult OnPostRemove(long BookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Book.BookId == BookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
