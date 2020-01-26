using FluentValidation;
using NzbDrone.Core.Annotations;

namespace NzbDrone.Core.NetImport.Trakt.Popular
{
    public class TraktPopularSettingsValidator : TraktSettingsBaseValidator<TraktPopularSettings>
    {
        public TraktPopularSettingsValidator()
        : base()
        {
            RuleFor(c => c.TraktListType).NotEmpty();
        }
    }

    public class TraktPopularSettings : TraktSettingsBase<TraktPopularSettings>
    {
        protected override AbstractValidator<TraktPopularSettings> Validator => new TraktPopularSettingsValidator();

        public TraktPopularSettings()
        {
            TraktListType = (int)TraktPopularListType.Popular;
        }

        [FieldDefinition(1, Label = "List Type", Type = FieldType.Select, SelectOptions = typeof(TraktPopularListType), HelpText = "Type of list your seeking to import from")]
        public int TraktListType { get; set; }
    }
}
