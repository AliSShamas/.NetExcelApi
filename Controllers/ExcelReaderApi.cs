namespace ExcelReaderApi;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;



[ApiController]
[Route("api/[controller]")]
public class ExcelReaderApi : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IExcelReaderService _excelReaderService;

    public ExcelReaderApi(IConfiguration config, IExcelReaderService excelReaderService)
        {
            _excelReaderService = excelReaderService;
            _config = config;
        }

    [HttpGet]
    [Route("Data")]
    public IActionResult ReadExcelFile()
    {
        var filePath = _config["ExcelSettings:FilePath"];
        var people = _excelReaderService.ReadExcelData(filePath);
        return Ok(people);

    }

    
        
    }

