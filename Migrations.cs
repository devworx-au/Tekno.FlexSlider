using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using System.Data;

namespace Tekno.FlexSlider
{
    public class Migrations : DataMigrationImpl
    {

        public int Create()
        {
            // Creating table FlexSliderPartRecord
            SchemaBuilder.CreateTable("FlexSliderPartRecord", table => table
                .ContentPartRecord()
                .Column("Sort", DbType.Byte)
            );

            // Creating table FlexSliderWidgetPartRecord
            SchemaBuilder.CreateTable("FlexSliderWidgetPartRecord", table => table
                .ContentPartRecord()
                .Column("Count", DbType.Byte)
            );

            ContentDefinitionManager.AlterTypeDefinition("FlexSlider", builder => builder
               .DisplayedAs("Flex Slider")
               .WithPart("FlexSliderPart")
               .WithPart("CommonPart",
                 p => p
                     .WithSetting("OwnerEditorSettings.ShowOwnerEditor", "false")
                     .WithSetting("DateEditorSettings.ShowDateEditor", "false"))
               .WithPart("IdentityPart")
               .WithPart("TitlePart")
           );

            ContentDefinitionManager.AlterTypeDefinition("FlexSliderWidget", builder => builder
              .DisplayedAs("Flex Slider Widget")
              .WithPart("FlexSliderWidgetPart")
              .WithPart("CommonPart")
              .WithPart("IdentityPart")
              .WithPart("WidgetPart")
              .WithSetting("Stereotype", "Widget")
          );

            ContentDefinitionManager.AlterPartDefinition("FlexSliderPart", builder => builder
                        .WithField("Picture", cfg => cfg.OfType("MediaLibraryPickerField")
                        .WithSetting("MediaLibraryPickerFieldSettings.DisplayedContentTypes", "Image")
                        .WithSetting("MediaLibraryPickerFieldSettings.Multiple", "False"))
                    );

            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.AlterTable("FlexSliderPartRecord", table => table
                   .AddColumn<int>("GroupId"));

            SchemaBuilder.AlterTable("FlexSliderWidgetPartRecord", table => table
                .AddColumn<int>("GroupId"));

            ContentDefinitionManager.AlterTypeDefinition("FlexSliderGroup", builder => builder
              .DisplayedAs("Flex Slider Group")
              .WithPart("CommonPart",
                p => p
                    .WithSetting("OwnerEditorSettings.ShowOwnerEditor", "false")
                    .WithSetting("DateEditorSettings.ShowDateEditor", "false"))
              .WithPart("IdentityPart")
              .WithPart("TitlePart")
          );

            return 2;
        }
    }
}