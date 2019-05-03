using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Api.Controllers
{
    /// <summary>
    /// Controller de Curriculums
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ImportacionController : ControllerBase
    {
        /// <summary>
        /// Importar un archivo de curriculums
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        [HttpPost("curriculums")]

        public async Task<ActionResult<string>> ImportarCurriculums(IFormFile archivo)
        {
            // Copiar el archivo a una ubicación temporal.
            var filePath = Path.GetTempFileName();

            if (archivo.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }
            }

            // Procesar el archivo
            

            return Ok("Archivo procesado correctamente");
        }

    }
}
