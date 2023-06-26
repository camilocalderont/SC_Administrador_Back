using System.Numerics;

namespace WebApi.Requests
{
    public class UsuarioCreateRequest
    {
        public String VcPrimerNombre { get; set; }
        public String VcPrimerApellido { get; set; }

        public String VcSegundoNombre { get; set; }
        public String VcSegundoApellido { get; set; }        
        public String VcCorreo { get; set; }
        public String VcIdAzure { get; set; }
        public String? VcIdpAzure { get; set; }
        


    }
}
