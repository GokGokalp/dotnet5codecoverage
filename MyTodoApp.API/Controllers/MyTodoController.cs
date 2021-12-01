using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTodoApp.API.Models.Requests;
using MyTodoApp.API.Models.Responses;
using MyTodoApp.API.Services;

namespace MyTodoApp.API.Controllers
{
    [ApiController]
    [Route("todos")]
    [ExcludeFromCodeCoverage]
    public class MyTodoController : ControllerBase
    {
        private readonly IMyTodoService _myTodoService;

        public MyTodoController(IMyTodoService myTodoService)
        {
            _myTodoService = myTodoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(CreateMyTodoRequest request)
        {
            try
            {
                CreateMyTodoResponse response = await _myTodoService.CreateTodoAsync(request);

                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}