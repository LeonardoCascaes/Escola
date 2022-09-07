using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Handlers.ScholarityHandlers
{
    public class DeleteScholarityHandler
    {
        private readonly IScholarityRepository<Scholarity> _scholarityRepository;

        public DeleteScholarityHandler(IScholarityRepository<Scholarity> scholarityRepository)
        {
            _scholarityRepository = scholarityRepository;
        }

        public async Task<ICommandResult> Handle(int scholarityId)
        {
            var scholarity = await _scholarityRepository.Get(scholarityId);
            if (scholarity == null)
                return new GenericCommandResult(false, "Falha ao encontrar a escolaridade.", null);

            await _scholarityRepository.Delete(scholarity);
            return new GenericCommandResult(true, "Escolaridade deletada com sucesso.", scholarity.Id);
        }
    }
}
