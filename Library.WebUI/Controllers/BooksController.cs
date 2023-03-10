﻿using Library.Application.Books.Queries.AllBooks;
using Library.Application.Books.Queries.BookByTitle;
using Library.Application.Common.Exceptions;
using Library.Contracts.BookContracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    public async Task<IActionResult> Index(string sort, int page = 1)
    {
        var response = await _mediator.Send(new GetAllBooksQuery(page, sort));

        return View(_mapper.Map<GetAllBookRequest>(response));
    }

    [Route("/{title}")]
    public async Task<IActionResult> BookPage(string title)
    {
        GetBookByTitleResponse response;

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

        return PartialView("_BooksListPartial", _mapper.Map<GetAllBookRequest>(response));
    }
}
