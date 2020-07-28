using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Redis_POC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private IDatabase _database;

        public CacheController(IDatabase database)
        {
            _database = database;
        }
        
        [HttpGet]
        [Route("dados/{key}")]
        public string ObterValor(string key)
        {
            return _database.StringGet(key);
        }

        [HttpPost]
        [Route("dados")]
        public void AtribuirValor([FromBody] KeyValuePair<string, string> keyValue)
        {
            _database.StringSet(keyValue.Key, keyValue.Value);
        }
        
    }
}