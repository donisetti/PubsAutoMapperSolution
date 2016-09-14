using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PubsDomainLibrary.Concrete;
using PubsDomainLibrary.Entities;
using PubsDomainLibrary.Abstract;
using PubsAutoMapperMVCApp.Models;
using AutoMapper;

namespace PubsAutoMapperMVCApp.Controllers
{
    public class BookController : Controller
    {
        IBookRepository _bookRepository;
        IAuthorRepository _authorRepository;
        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            Mapper.Initialize(cfg => { cfg.CreateMap<Book, BookAuthorViewModel>(); });
            Mapper.Initialize(cfg => { cfg.CreateMap<Book, BookAuthorViewModel>().ReverseMap(); });
        }

        public ActionResult Index()
        {
            

            var bookList = _bookRepository.Books.Include(a => a.Authors).ToList();

            //Using Projection
            var bookAuthorVMList = Mapper.Map<IEnumerable<BookAuthorViewModel>>(bookList);

            //var bookAuthorVMList = new List<BookAuthorViewModel>();
            //foreach (var item in bookList)
            //{
            //    var bookAuthorVM = Mapper.Map<Book, BookAuthorViewModel>(item);
            //    bookAuthorVMList.Add(bookAuthorVM);
            //}
            return View(bookAuthorVMList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bookRepository.Books.FirstOrDefault(b=>b.BookId == id.Value);
            var bookAuthorVM = Mapper.Map<Book, BookAuthorViewModel>(book);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthorVM);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bookRepository.Books.Include(b=>b.Authors).FirstOrDefault(b=>b.BookId == id.Value);
            var bookAuthorVM = Mapper.Map<Book, BookAuthorViewModel>(book);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthorVM);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,Price,Category,Authors")] BookAuthorViewModel book)
        {
            if (ModelState.IsValid)
            {
                var authorList = book.Authors.Select(a => a).ToList();

                var bookAuthorVM = Mapper.Map<BookAuthorViewModel, Book>(book);
                if (authorList.Count == 1)
                {
                    _authorRepository.Update(authorList[0]);
                }
                else
                {
                    _authorRepository.Update(authorList);
                }
                _bookRepository.Update(bookAuthorVM);
                return RedirectToAction("Index");
            }
            return View(book);
        }


        public ActionResult Create()
        {
            //var bookAuthorVM = new BookAuthorViewModel { Authors = _authorRepository.Authors.ToList() };
            ViewBag.AuthorsList = new MultiSelectList(_authorRepository.Authors
                .Select(a => new { AuthorId = a.AuthorId, AuthorName = (a.FirstName + " " + a.LastName) } ).ToList(), "AuthorId", "AuthorName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BookId,Title,Price,Category")] Book book)
        public ActionResult Create([Bind(Include = "BookId,Title,Price,Category,Authors")] BookAuthorViewModel book, int[] AuthorId)
        {
            if (ModelState.IsValid)
            {
                #region When Using 2 different context objects it causes the error when Adding a record
                //var result = _authorRepository.Authors.ToList();
                //var authorList = new List<Author>();
                //var bookAuthorVM = Mapper.Map<BookAuthorViewModel, Book>(book);
                ////book.Authors = new List<Author>();
                ////bookAuthorVM.Authors = new List<Author>();
                //for (int i = 0; i < AuthorId.Length; i++)
                //{
                //    authorList.Add(result.Where(a=>a.AuthorId == AuthorId[i]).FirstOrDefault());
                //    //book.Authors.Add(result.Where(a => a.AuthorId == AuthorId[i]).FirstOrDefault());
                //    //bookAuthorVM.Authors.Add(result.Where(a => a.AuthorId == AuthorId[i]).FirstOrDefault());

                //}
                //bookAuthorVM.Authors = authorList;
                //_bookRepository.Add(bookAuthorVM);
                //return RedirectToAction("Index");
                #endregion

                #region Use only one context object
                var bookAuthorVM = Mapper.Map<BookAuthorViewModel, Book>(book);
                _bookRepository.Add(bookAuthorVM, AuthorId);
                return RedirectToAction("Index");
                #endregion
            }

            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bookRepository.Books.FirstOrDefault(b=>b.BookId == id.Value) ;
            var bookAuthorsVM = Mapper.Map<Book, BookAuthorViewModel>(book);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthorsVM);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = _bookRepository.Books.FirstOrDefault(b => b.BookId == id);
            var bookAuthorsVM = Mapper.Map<Book, BookAuthorViewModel>(book);
            _bookRepository.Delete(book);
            return RedirectToAction("Index");
        }
    }
}
