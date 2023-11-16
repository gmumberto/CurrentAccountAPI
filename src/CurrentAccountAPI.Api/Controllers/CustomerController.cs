using AutoMapper;
using CurrentAccountAPI.Api.Model;
using CurrentAccountAPI.Domain.DTOs;
using CurrentAccountAPI.Domain.Interface;
using CurrentAccountAPI.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;  

namespace CurrentAccountAPI.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : MainController
    {
        private readonly ICustomerService _customerService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public CustomerController(
            INotifier notifier,
            IMapper mapper,
            ICustomerService customerService,
            ITransactionService transactionService) : base(notifier)
        {
            this._customerService = customerService;
            this._mapper = mapper;
            this._transactionService = transactionService;
        }

        [AllowAnonymous, HttpGet, ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel)),
        ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerDTO>> Get([FromQuery] int customerId)
        {
            var resultCustomer = _mapper.Map<ActionResult<CustomerDTO>>(await _customerService.GetByIdAllClass(customerId));
            resultCustomer.Value.Transactions.AddRange(_mapper.Map<List<TransactionDTO>>(await _transactionService.Get(customerId)));
            return resultCustomer;
        }

        [HttpPost, ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel)),
        ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(int customerId, decimal initialCredit)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _customerService.PostIfUserNotExists(customerId, initialCredit);

            return Ok();

        }
    }
}
