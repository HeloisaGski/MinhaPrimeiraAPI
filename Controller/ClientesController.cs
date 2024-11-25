using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private static List<Cliente> clientes = new List<Cliente>();

    [HttpGet]
    public ActionResult<List<Cliente>> Get()
    {
        return clientes;
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> Get(int id)
    {
        Cliente? clienteEncontrado = null; 

        foreach (var c in clientes)
        {
            if (c.Id == id) 
            {
                clienteEncontrado = c;
                break;
            }
        }

        if (clienteEncontrado == null)
        {
            return NotFound(); 
        }

        return clienteEncontrado; 
    }

    [HttpPost]
    public ActionResult Post(Cliente cliente)
    {
        cliente.Id = clientes.Count + 1; 
        clientes.Add(cliente); 
        return Created($"/clientes/{cliente.Id}", cliente); 
    }
}