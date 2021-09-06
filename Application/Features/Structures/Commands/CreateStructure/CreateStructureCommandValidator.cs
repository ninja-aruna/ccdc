using Application.Interfaces.Repositories;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Structures.Commands.CreateStructure
{
    public class CreateStructureCommandValidator : AbstractValidator<CreateStructureCommand>
    {
        private readonly IStructureRepositoryAsync structureRepository;

        public CreateStructureCommandValidator(IStructureRepositoryAsync structureRepository)
        {
            this.structureRepository = structureRepository;

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                
        }

        private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await structureRepository.IsUniqueStructureAsync(barcode);
        }
    }
}
