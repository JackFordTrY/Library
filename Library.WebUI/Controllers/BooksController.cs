using Library.Application.Books.Queries.AllBooks;
using Library.Application.Books.Queries.BookByTitle;
using Library.Application.Books.Queries.SearchBook;
using Library.Application.Common.Exceptions;
using Library.Contracts.BookContracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers;

public class BooksController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BooksController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Route("/")]
    public IActionResult Index()
    {
        return View();
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

    [Route("/list")]
    public async Task<IActionResult> BookList(GetAllBooksQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(_mapper.Map<GetAllBookResponse>(response));
    }

    [Route("/search")]
    public async Task<IActionResult> SearchList(SearchBookQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(_mapper.Map<SearchBookResponse>(response));
    }
}
