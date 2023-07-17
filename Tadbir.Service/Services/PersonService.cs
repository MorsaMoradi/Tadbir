//using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Domain.Core;
using Tadbir.Domain.Domain;
using Tadbir.Domain.Dto;
using Tadbir.Domain.Repositories;
using Tadbir.Domain.Service;
namespace Tadbir.Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository repository;
        private readonly IEntityMapper<Person, PersonDto> _mapper;
        private readonly ICacheService _cacheService;
        private readonly ILogger<PersonService> _logger;
        public PersonService(IPersonRepository repository, IEntityMapper<Person, PersonDto> mapper, ICacheService cacheService, ILogger<PersonService> logger)
        {
            this.repository = repository;
            _mapper = mapper;
            _cacheService = cacheService;
            _logger = logger;
        }
        private void AddInChache(Person person)
        {
            DateTimeOffset date = DateTimeOffset.Now.AddMinutes(20);
            _cacheService.SetData(person.Id.ToString(), person,date);
        }
        public async Task<PersonDto> SaveAsync(PersonDto person)
        {
            try
            {
                var domain = _mapper.MapFrom(person);
                if (domain.Id == default)
                {
                    domain.SetId(Guid.NewGuid());
                    await repository.InsertAsync(domain);
                    AddInChache(domain);
                }
                else
                    await repository.UpdateAsync(domain);

                _logger.LogInformation("person saved {0}", Newtonsoft.Json.JsonConvert.SerializeObject(domain));

                return _mapper.MapTo(domain);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("person saved {0}", ex);
                throw;
            }
        }
        public async Task<bool> AfterReadMessageAsync(PersonDto Message)
        {
            await SaveAsync(Message);
            return true;
        }
    }
}
