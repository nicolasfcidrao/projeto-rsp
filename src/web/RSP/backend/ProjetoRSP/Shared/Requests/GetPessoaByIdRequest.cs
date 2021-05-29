using Microsoft.AspNetCore.Mvc;

namespace ProjectRSP.Shared.Requests
{
    public class GetPessoaByIdRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}