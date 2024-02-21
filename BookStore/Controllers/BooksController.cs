
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Business;
using BookStore.Business.Models;
using FluentValidation;
using System;
using FluentValidation.Results;
using static System.Reflection.Metadata.BlobBuilder;
using AutoMapper;
using BookStore.Business.Mapping;
using BookStore.Domain.Entities;



namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        
        readonly private IMapper _mapper;
        readonly private IBookBO _bookBO;
        readonly private IValidator<BooksCountByAuthorandCategoryModel> _validator;
        readonly private IValidator<BookStartingFromId> _validator1;


        public BooksController(IBookBO bookBO, IValidator<BooksCountByAuthorandCategoryModel> validator,IValidator<BookStartingFromId>validator1,IMapper mapper)
        {
            _bookBO = bookBO;
            _validator = validator;
            _validator1 = validator1;
            _mapper = mapper;
           
        }


        [HttpGet]
        public IActionResult GetAllAsync()
        {


            var books = _bookBO.GetAll();
            var bookDtos = _mapper.Map<List<BookModelDto>>(books);
            return Ok(bookDtos);

        }
        [HttpGet("BooksCountByAuthor")]
        public IActionResult BooksCountByAuthor()
        {
            var books = _bookBO.getCountBooksByAuthor();
            return Ok(books);

        }
        [HttpGet("GetBookWithProperties")]
        public IActionResult GetBookWithProperties()
        {


            var books = _bookBO.GetBookWithProperties();
            return Ok(books);

        }

        [HttpGet("GetBookCountsInCategory")]
        public IActionResult GetBookCountsInCategory()
        {

                //select count("category"),category from "Books" group by category
            var books = _bookBO.GetBookCountsInCategory();
            return Ok(books);
           
        }

        [HttpGet("getFindBooksByCategoryAndAuthor")]
        public IActionResult getfindBooksByCategoryAndAuthor(BooksCountByAuthorandCategoryModel model)
        {

            ValidationResult result = _validator.Validate(model);
            if (result.IsValid)
            {
                var books = _bookBO.getFindBooksByCategoryAndAuthor(model.category, model.author);
                return Ok(books);
            }
            else
            {
                return BadRequest();
            }//automapper bak

        }
       
        [HttpGet("idandtake")]
        public IActionResult getbooksStartingFromId(BookStartingFromId models)
        {
            ValidationResult result = _validator1.Validate(models);
            if (result.IsValid) {
                var books = _bookBO.getBooksStartingFromId(models.id, models.take);
                return Ok(books);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet("id/{id}/take/{take}")]
        public IActionResult getbooksStartingFromId(int id, int take)
        {


            var books = _bookBO.getBooksStartingFromId(id, take);
            return Ok(books);

        }
        //[HttpGet("allBookscountbyauthor")]
        //public IActionResult getCountBooksByAuthor()
        //{


        //    var books = _bookBO.getCountBooksByAuthor();
        //    return Ok(books);

        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var books = await _bookBO.GetById(id);
            return Ok(books);

        }
        [HttpPost("create")]
        public async Task<ActionResult<BookModel>> Create(BookModel book)
        {
          

            var books =await _bookBO.create(book);
            return Ok(books);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> deleteById(int id)
        {
            await _bookBO.RemoveAsync(id);
            return Ok(id);
        }



        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(BookModel bookModel)
        {
            await _bookBO.UpdateAsync(bookModel);
            return Ok(bookModel);
        }


    }
}
