// ******************************************************************************
//  © 2019 Sebastiaan Dammann | damsteen.nl
// 
//  File:           : BaseDataSeeder.cs
//  Project         : Return.Application
// ******************************************************************************

namespace Return.Application.App.Commands.SeedBaseData {
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Abstractions;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    internal sealed class BaseDataSeeder {
        private readonly IReturnDbContext _returnDbContext;

        public BaseDataSeeder(IReturnDbContext returnDbContext) {
            this._returnDbContext = returnDbContext;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken) {
            await this.SeedNoteLanes(cancellationToken);
            await this.SeedPredefinedParticipantColor(cancellationToken);

            await this._returnDbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedNoteLanes(CancellationToken cancellationToken) {
            if (await this._returnDbContext.NoteLanes.AnyAsync(cancellationToken)) {
                return;
            }

            // Seed note lanes
            this._returnDbContext.NoteLanes.AddRange(
                new NoteLane { Id = KnownNoteLane.Start, Name = "Start \U0001F680" },
                new NoteLane { Id = KnownNoteLane.Stop, Name = "Stop \U000026D4" },
                new NoteLane { Id = KnownNoteLane.Continue, Name = "Continue \U0001F44D" }
            );
        }

        private async Task SeedPredefinedParticipantColor(CancellationToken cancellationToken) {
            if (await this._returnDbContext.PredefinedParticipantColors.AnyAsync(cancellationToken)) {
                return;
            }

            // Seed note lanes
            this._returnDbContext.PredefinedParticipantColors.AddRange(
                new PredefinedParticipantColor("Driver red", Color.OrangeRed),
                new PredefinedParticipantColor("Analytic blue", Color.Blue),
                new PredefinedParticipantColor("Amiable green", Color.ForestGreen),
                //new PredefinedParticipantColor("Expressive yellow", Color.Yellow),
                new PredefinedParticipantColor("Juicy orange", Color.DarkOrange),
                new PredefinedParticipantColor("Participator purple", Color.DarkOrchid),
                new PredefinedParticipantColor("Boring blue-gray", Color.DarkSlateGray),
                new PredefinedParticipantColor("Adapting aquatic", Color.DodgerBlue),
                new PredefinedParticipantColor("Fresh lime", Color.LimeGreen),
                new PredefinedParticipantColor("Tomàto tomató", Color.IndianRed),
                new PredefinedParticipantColor("Goldie the bird", Color.Goldenrod),
                new PredefinedParticipantColor("Farmer wheat", Color.Peru)
            );
        }
    }
}
