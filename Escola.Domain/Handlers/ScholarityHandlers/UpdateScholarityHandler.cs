using Escola.Domain.Commands.ScholarityCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.ScholarityHandlers
{
    public class UpdateScholarityHandler : IHandler<UpdateScholarityCommand>
    {
        private readonly IScholarityRepository<Scholarity> _scholarityRepository;

        public UpdateScholarityHandler(IScholarityRepository<Scholarity> scholarityRepository)
        {
            _scholarityRepository = scholarityRepository;
        }

        public async Task<ICommandResult> Handle(UpdateScholarityCommand command)
        {
            command.Validate();
            if (!command.IsValid())
                return new GenericCommandResult(false, "Ocorreu um problema ao tentar executar a tarefa.", command.Notifications);

            var scholarity = await _scholarityRepository.Get(command.Id);
            if (scholarity == null)
                return new GenericCommandResult(false, "Falha ao encontrar a escolaridade.", null);

            scholarity.ChangeDescripton(command.Description);
            scholarity.ChangeModificationDate();

            await _scholarityRepository.Update(scholarity);
            return new GenericCommandResult(true, "Escolaridade atualizada com sucesso.", new GenericOutput(scholarity.Id, command));
        }
    }
}
