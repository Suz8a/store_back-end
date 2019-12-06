using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;
        private readonly ClienteService _clienteService;
        private readonly PedidoService _pedidoService;
        private static readonly HttpClient client = new HttpClient();

        public TicketController(TicketService ticketService, ClienteService clienteService, PedidoService pedidoService)
        {
            _ticketService = ticketService;
            _clienteService = clienteService;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public ActionResult<List<Ticket>> Get() =>
            _ticketService.Get();

        [HttpGet("{id:length(24)}", Name = "GetTicket")]
        public ActionResult<Ticket> Get(string id)
        {
            var ticket = _ticketService.Get(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        [HttpPost( "{dest}" )]
        public async System.Threading.Tasks.Task<ActionResult<Ticket>> CreateAsync(string dest ,Ticket ticket)
        {
            _ticketService.Create(ticket);

            var pedido = _pedidoService.Get(ticket.pedido_id) ;
            var cliente = _clienteService.Get(pedido.cliente_id);
            var nomCliente = cliente.nombre + " " + cliente.apellido_paterno + " " + cliente.apellido_materno ; 

            var values = new Dictionary<string, string>
                {
                { "dest", dest },
                { "folio", pedido.folio },
                { "cliente", nomCliente },
                { "correo", cliente.correo },
                { "descripcion", ticket.descripcion }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://us-central1-troquel-bb3de.cloudfunctions.net/sendMail", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return CreatedAtRoute("GetTicket", new { id = ticket.Id.ToString() }, ticket);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Ticket ticketIn)
        {
            var ticket = _ticketService.Get(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _ticketService.Update(id, ticketIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var ticket = _ticketService.Get(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _ticketService.Remove(ticket.Id);

            return NoContent();
        }


    }
}
