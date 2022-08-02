using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resources.Entities;

namespace DbContextProfi.TableConfigurations
{
    internal class MainPagePresetTableConfig : IEntityTypeConfiguration<MainPagePresetEntity>
    {
        public void Configure(EntityTypeBuilder<MainPagePresetEntity> builder)
        {
            builder
                .HasOne(preset => preset.Text)
                .WithMany(text => text.Presets)
                .HasForeignKey(preset => preset.TextId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(preset => preset.Image)
                .WithMany(image => image.Presets)
                .HasForeignKey(preset => preset.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(preset => preset.Phrase)
                .WithMany(phrase => phrase.Presets)
                .HasForeignKey(preset => preset.PhraseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(preset => preset.Action)
                .WithMany(action => action.Presets)
                .HasForeignKey(preset => preset.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(preset => preset.Button)
                .WithMany(button => button.Presets)
                .HasForeignKey(preset => preset.ButtonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
