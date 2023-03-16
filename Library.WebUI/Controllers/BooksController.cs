using Library.Application.Books.Queries.AllBooks;
using Library.Application.Books.Queries.BookByTitle;
using Library.Application.Books.Queries.SearchBook;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Contracts.BookContracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers;

public class BooksController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IBookRepository _repository;

    public BooksController(IMediator mediator, IMapper mapper, IBookRepository repository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _repository = repository;
    }

    [Route("/")]
    public IActionResult Index()
    {
        var pages = Math.Ceiling((float)_repository.BookCount / 20);
        return View(pages);
    }

    [Route("/{title}")]
    public async Task<IActionResult> BookPage(string title)
    {
        GetBookByTitleQueryResponse response;

        try
        {
            response = await _mediator.Send(new GetBookByTitleQuery(title));
        }
        catch (BookNotFoundException)
        {
            return NotFound();
        }

        return View(_mapper.Map<GetBookByTitleRequest>(response));
    }
    
    [Route("/BooksList")]
    public async Task<IActionResult> BooksListPartial(string sort, int page = 1)
    {
        var response = await _mediator.Send(new GetAllBooksQuery(page, sort));

        return PartialView("_BooksListPartial", _mapper.Map<GetAllBookResponse>(response));
    }

    [Route("/SearchBooks")]
    public async Task<IActionResult> SearchBooksPartial(string search)
    {
        var response = await _mediator.Send(new SearchBookQuery(search));

        return PartialView("_SearchBooksPartial", _mapper.Map<SearchBookResponse>(response));
    }
}
